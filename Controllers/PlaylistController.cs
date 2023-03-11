using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSystem.Data;
using MusicSystem.Models;

namespace MusicSystem.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly DBContext _context;

        public PlaylistController(DBContext context)
        {
            _context = context;
        }

        // GET: Playlist
        public async Task<IActionResult> Index()
        {
              return View(await _context.Playlist.ToListAsync());
        }

        // GET: Playlist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Playlist == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .Include(ps => ps.PlaylistSongs)
                .ThenInclude(s => s.Song)
                .ThenInclude(a => a.Album)
                .Include(ps => ps.PlaylistSongs)
                .ThenInclude(s => s.Song)
                .ThenInclude(sc => sc.SongContributors)
                .ThenInclude(ar => ar.Artist)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync<Playlist>();
                
            if (playlist == null)
            {
                return NotFound();
            }

            int sum = 0;
            foreach(PlaylistSong ps in playlist.PlaylistSongs)
            {
                sum += ps.Song.DurationSeconds;
            }

            ViewBag.TotalTime = sum;
            ViewBag.TotalCount = playlist.PlaylistSongs.Count;

            return View(playlist);
        }

        // GET: Playlist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Playlist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        // GET: Playlist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Playlist == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return View(playlist);
        }

        // POST: Playlist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistExists(playlist.Id))
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
            return View(playlist);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromPlaylist(int songid, int id)
        {
            PlaylistSong playlistSong = _context.PlaylistSong.FirstOrDefault(ps => ps.Song.Id == songid && ps.Playlist.Id == id);
            if (playlistSong != null)
            {
                _context.PlaylistSong.Remove(playlistSong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { Id = id });
        }

        // GET: Playlist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Playlist == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // POST: Playlist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Playlist == null)
            {
                return Problem("Entity set 'DBContext.Playlist'  is null.");
            }
            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist != null)
            {
                _context.Playlist.Remove(playlist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistExists(int id)
        {
          return _context.Playlist.Any(e => e.Id == id);
        }
    }
}
