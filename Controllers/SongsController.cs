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
    public class SongsController : Controller
    {
        private readonly DBContext _context;

        public SongsController(DBContext context)
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
                    .Where(s => s.MediaCollectionId == albumid)
                    .OrderBy(s => s.TrackNumber)
                    .ToListAsync<Song>();

                if (songs == null)
                {
                    return NotFound();
                }

                int sum = 0;
                foreach (Song s in songs)
                {
                    sum += s.DurationInSeconds;
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

        [HttpGet]
        public IActionResult Create()
        {
            SongVM vm = new SongVM(_context.Artist.ToList(), _context.Album.ToList());
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("AlbumId", "ArtistId", "Title", "TrackNumber", "DurationSeconds")] SongVM vm)
        {
            try
            {
                // verify album and artist
                Album album = _context.Album.FirstOrDefault(a => a.Id == vm.AlbumId);
                Artist artist = _context.Artist.FirstOrDefault(ar => ar.Id == vm.ArtistId);

                if (album == null)
                {
                    ViewBag.Message = "Error saving song: Album does not exist.";
                    vm.PopulateArtistsAndAlbums(_context.Artist.ToList(), _context.Album.ToList());
                    return View(vm);
                }
                if (artist == null)
                {
                    ViewBag.Message = "Error saving song: Artist does not exist.";
                    vm.PopulateArtistsAndAlbums(_context.Artist.ToList(), _context.Album.ToList());
                    return View(vm);
                }

                // save song to context
                Song song = new Song(vm.Title, vm.DurationSeconds, vm.TrackNumber, album);
                album.Songs.Add(song);
                _context.Song.Add(song);
                await _context.SaveChangesAsync();

                // add artist to song
                SongContributor sc = new SongContributor(artist, song);
                artist.SongContributors.Add(sc);
                song.SongContributors.Add(sc);
                _context.SongContributor.Add(sc);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddToPlaylist(int songid)
        {
            Song song = _context.Song.FirstOrDefault(s => s.Id == songid);
            PlaylistSongVM vm = new PlaylistSongVM(_context.Playlist.ToList(), song);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddToPlaylist([Bind("PlaylistId", "SongId")] PlaylistSongVM vm)
        {
            try
            {
                Song song = _context.Song.FirstOrDefault(s => s.Id == vm.SongId);

                if (!_context.PlaylistSong.Any(ps => ps.SongId == vm.SongId && ps.PlaylistId == vm.PlaylistId))
                {
                    Playlist playlist = _context.Playlist.FirstOrDefault(p => p.Id == vm.PlaylistId);

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
    }
}
