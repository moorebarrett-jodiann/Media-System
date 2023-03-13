using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSystem.Data;
using MusicSystem.Models;
using MusicSystem.Models.ViewModels;

namespace MusicSystem.Controllers
{
    public class SongController : Controller
    {
        private readonly DBContext _context;

        public SongController(DBContext context)
        {
            _context = context;
        }

        // GET: Song
        public async Task<IActionResult> Index(int? albumid)
        {
            if (albumid == null || albumid < 1)
            {
                ViewBag.FilterAlbum = false;
                return View(await _context.Song.ToListAsync());
            }
            else
            {
                var songs = await _context.Song
                    .Include(a => a.Album)
                    .Where(s => s.AlbumId == albumid)
                    .ToListAsync<Song>();

                if (songs == null)
                {
                    return NotFound();
                }

                int sum = 0;
                foreach (Song s in songs)
                {
                    sum += s.DurationSeconds;
                }

                ViewBag.FilterAlbum = true;
                ViewBag.TotalTime = sum;
                ViewBag.AlbumTitle = _context.Album.Where(a => a.Id == albumid).Select(a => a.Title).SingleOrDefault().ToString();

                return View(songs);
            }
        }

        // GET: Song/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Song/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Set<Album>(), "Id", "Id");
            return View();
        }

        // POST: Song/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,DurationSeconds,AlbumId")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumId"] = new SelectList(_context.Set<Album>(), "Id", "Id", song.AlbumId);
            return View(song);
        }

        // GET: Song/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            ViewData["AlbumId"] = new SelectList(_context.Set<Album>(), "Id", "Id", song.AlbumId);
            return View(song);
        }

        // POST: Song/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,DurationSeconds,AlbumId")] Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.Id))
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
            ViewData["AlbumId"] = new SelectList(_context.Set<Album>(), "Id", "Id", song.AlbumId);
            return View(song);
        }

        [HttpGet]
        public async Task<IActionResult> AddToPlaylist(int songid)
        {
            Song song = _context.Song.First(s => s.Id == songid);
            PlaylistSongVM vm = new PlaylistSongVM(_context.Playlist.ToList(), song);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddToPlaylist([Bind("PlaylistId", "SongId")] PlaylistSongVM vm)
        {
            try
            {
                Song song = _context.Song.First(s => s.Id == vm.SongId);
                
                if (!_context.PlaylistSong.Any(ps => ps.SongId == vm.SongId  && ps.PlaylistId == vm.PlaylistId))
                {
                    Playlist playlist = _context.Playlist.First(p => p.Id == vm.PlaylistId);

                    // create new playlist song relationship
                    PlaylistSong playlistSong = new PlaylistSong();
                    playlistSong.Playlist = playlist;
                    playlistSong.Song = song;

                    _context.PlaylistSong.Add(playlistSong);
                    _context.SaveChanges();

                    vm.IsAdded = true;
                    ViewBag.Message = $"Successfully added Song: {song.Title} to Playlist: {playlist.Name}";
                }
                else
                {
                    ViewBag.Message = "Song is already added to Playlist";
                }

                vm.Song = song;
                vm.PopulateList(_context.Playlist.ToList());
                return View(vm);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // GET: Song/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Song/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Song == null)
            {
                return Problem("Entity set 'DBContext.Song'  is null.");
            }
            var song = await _context.Song.FindAsync(id);
            if (song != null)
            {
                _context.Song.Remove(song);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
          return _context.Song.Any(e => e.Id == id);
        }
    }
}
