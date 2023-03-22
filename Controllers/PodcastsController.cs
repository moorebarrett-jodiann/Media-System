using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSystem.Data;
using MusicSystem.Models;
using MusicSystem.Models.ViewModels;

namespace MusicSystem.Controllers
{
    public class PodcastsController : Controller
    {
        private readonly DBContext _context;

        public PodcastsController(DBContext context)
        {
            _context = context;
        }

        // GET: Podcasts
        public async Task<IActionResult> Index(int? listenerlistid)
        {
            if (listenerlistid == null || listenerlistid < 1)
            {
                return View(await _context.Podcast.ToListAsync());
            }
            else
            {
                var podcasts = await _context.Podcast
                    .Where(p => p.ListenerListPodcasts
                    .Any(llp => llp.ListenerListId
                    .Equals(listenerlistid)))
                    .ToListAsync<Podcast>();

                if (podcasts == null)
                {
                    return NotFound();
                }

                ViewBag.ListenerListName = _context.ListenerList.Where(ll => ll.Id == listenerlistid).Select(ll => ll.Description).FirstOrDefault();
                return View(podcasts);
            }

        }

        // GET: Podcasts/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Podcast == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcast
                .Include(p => p.Episodes)
                .ThenInclude(e => e.GuestArtists)
                .ThenInclude(ga => ga.Artist)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync<Podcast>();

            if (podcast == null)
            {
                return NotFound();
            }

            int sum = 0;
            foreach (Episode e in podcast.Episodes)
            {
                sum += e.DurationInSeconds;
            }

            ViewBag.TotalTime = sum;
            ViewBag.TotalCount = podcast.Episodes.Count;

            return View(podcast);
        }

        [HttpPost]
        public async Task<IActionResult> Details([Bind("Id", "SortOrder")] int Id, SortOrder SortOrder)
        {
            Podcast? podcast = null;

            if (SortOrder == SortOrder.DurationAscending)
            {
                podcast = await _context.Podcast
                .Include(p => p.Episodes.OrderBy(p => p.DurationInSeconds))
                .ThenInclude(e => e.GuestArtists)
                .ThenInclude(ga => ga.Artist)
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync<Podcast>();
            }
            else if (SortOrder == SortOrder.DurationDescending)
            {
                podcast = await _context.Podcast
                    .Include(p => p.Episodes.OrderByDescending(p => p.DurationInSeconds))
                    .ThenInclude(e => e.GuestArtists)
                    .ThenInclude(ga => ga.Artist)
                    .Where(p => p.Id == Id)
                    .FirstOrDefaultAsync<Podcast>();
            }
            else if (SortOrder == SortOrder.AirDateAscending)
            {
                podcast = await _context.Podcast
                    .Include(p => p.Episodes.OrderBy(p => p.AirDate))
                    .ThenInclude(e => e.GuestArtists)
                    .ThenInclude(ga => ga.Artist)
                    .Where(p => p.Id == Id)
                    .FirstOrDefaultAsync<Podcast>();
            }
            else
            {
                podcast = await _context.Podcast
                    .Include(p => p.Episodes.OrderByDescending(p => p.AirDate))
                    .ThenInclude(e => e.GuestArtists)
                    .ThenInclude(ga => ga.Artist)
                    .Where(p => p.Id == Id)
                    .FirstOrDefaultAsync<Podcast>();
            }

            if (podcast == null)
            {
                return NotFound();
            }

            int sum = 0;
            foreach (Episode e in podcast.Episodes)
            {
                sum += e.DurationInSeconds;
            }

            ViewBag.TotalTime = sum;
            ViewBag.TotalCount = podcast.Episodes.Count;

            return View(podcast);
        }

        [HttpGet]
        public async Task<IActionResult> AddToListenerList(int podcastid)
        {
            Podcast podcast = _context.Podcast.FirstOrDefault(p => p.Id == podcastid);

            // get all listener lists that do not have this podcast already linked
            List<ListenerList> list = _context.ListenerList
                .Where(ll => !ll.ListenerListPodcasts
                .Any(llp => llp.PodcastId
                .Equals(podcastid)))
                .ToList();

            if (list.Count == 0)
            {
                ViewBag.ErrorMessage = "Podcast already exists for all Listener Lists";
            }

            PodcastListenerListVM vm = new PodcastListenerListVM(list, podcast);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddToListenerList([Bind("ListenerListId", "PodcastId")] PodcastListenerListVM vm)
        {
            try
            {
                Podcast podcast = _context.Podcast.FirstOrDefault(p => p.Id == vm.PodcastId);

                ListenerList listenerList = _context.ListenerList.FirstOrDefault(ll => ll.Id == vm.ListenerListId);

                // create new listenerlist podcast relationship
                ListenerListPodcast listenerListPodcast = new ListenerListPodcast();
                listenerListPodcast.ListenerList = listenerList;
                listenerListPodcast.Podcast = podcast;

                _context.ListenerListPodcast.Add(listenerListPodcast);
                _context.SaveChanges();

                ViewBag.Message = $"Successfully added Podcast: {podcast.Title} to Listener List: {listenerList.Description}";


                // get all listener lists that do not have this podcast already linked
                List<ListenerList> list = _context.ListenerList
                    .Where(ll => !ll.ListenerListPodcasts
                    .Any(llp => llp.PodcastId
                    .Equals(podcast.Id)))
                    .ToList();

                if (list.Count == 0)
                {
                    ViewBag.ErrorMessage = "Podcast already exists for all Listener Lists";
                }
                vm.Podcast = podcast;
                vm.PopulateList(list);
                return View(vm);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // GET: Podcasts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Podcasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] Podcast podcast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podcast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(podcast);
        }

        // GET: Podcasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Podcast == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcast.FindAsync(id);
            if (podcast == null)
            {
                return NotFound();
            }
            return View(podcast);
        }

        // POST: Podcasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Podcast podcast)
        {
            if (id != podcast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podcast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodcastExists(podcast.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(podcast);
        }

        // GET: Podcasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Podcast == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcast
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podcast == null)
            {
                return NotFound();
            }

            return View(podcast);
        }

        // POST: Podcasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Podcast == null)
            {
                return Problem("Entity set 'DBContext.Podcast'  is null.");
            }
            var podcast = await _context.Podcast.FindAsync(id);
            if (podcast != null)
            {
                _context.Podcast.Remove(podcast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodcastExists(int id)
        {
          return (_context.Podcast?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
