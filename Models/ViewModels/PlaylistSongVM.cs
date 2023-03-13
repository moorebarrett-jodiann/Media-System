using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace MusicSystem.Models.ViewModels
{
    public class PlaylistSongVM
    {
        public HashSet<SelectListItem> Playlists { get; set; } = new HashSet<SelectListItem>();
        public int PlaylistId { get; set; }
        public Song Song { get; set; }
        public int SongId { get; set; }
        public bool IsAdded { get; set; } = false;

        public void PopulateList(IEnumerable<Playlist> playlists)
        {
            Playlists.Add(new SelectListItem { Text = "-- Select Playlist --", Value = "" });

            foreach (Playlist p in playlists)
            {
                Playlists.Add(new SelectListItem($"{p.Name}", p.Id.ToString()));
            }
        }

        public PlaylistSongVM(IEnumerable<Playlist> playlists, Song song)
        {
            PopulateList(playlists);
            Song = song;
            SongId = song.Id;
        }

        public PlaylistSongVM() { }
    }
}
