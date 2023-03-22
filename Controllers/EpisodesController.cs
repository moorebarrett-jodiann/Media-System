using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSystem.Data;
using MusicSystem.Models;
using MusicSystem.Models.ViewModels;

namespace MusicSystem.Controllers
{
    public class EpisodesController : Controller
    {
        private readonly DBContext _context;

        public EpisodesController(DBContext context)
        {
            _context = context;
        }

        // GET: Episodes
        public async Task<IActionResult> Index()
        {
            var episodes = await _context.Episode
                    .Include(e => e.GuestArtists)
                    .ThenInclude(ga => ga.Artist)
                    .ToListAsync<Episode>();

            if (episodes == null)
            {
                return NotFound();
            }

            StringBuilder sb = new StringBuilder();
            foreach (Episode e in episodes)
            {
                foreach (EpisodeArtist ea in e.GuestArtists)
                {
                    sb.Append(ea.Artist.Name.ToString());
                }
            }

            ViewBag.GuestArtists = String.Concat(",", sb.ToString());

            return View(episodes);
        }

        // GET: Episode/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Episode == null)
            {
                return NotFound();
            }

            var episode = await _context.Episode
                .Include(e => e.Podcast)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (episode == null)
            {
                return NotFound();
            }

            return View(episode);
        }

        [HttpGet]
        public IActionResult Create()
        {
            EpisodeVM vm = new EpisodeVM(_context.Podcast.ToList());
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("PodcastId", "Title", "AirDate", "DurationSeconds")] EpisodeVM vm)
        {
            try
            {
                // verify podcast and artist
                Podcast podcast = _context.Podcast.FirstOrDefault(p => p.Id == vm.PodcastId);

                if (podcast == null)
                {
                    ViewBag.Message = "Error saving episode: Podcast does not exist.";
                    vm.PopulatePodcasts(_context.Podcast.ToList());
                    return View(vm);
                }

                // save episode to context
                Episode episode = new Episode(vm.Title, vm.DurationSeconds, vm.AirDate, podcast);
                podcast.Episodes.Add(episode);
                _context.Episode.Add(episode);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
