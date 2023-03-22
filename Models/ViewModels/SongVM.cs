using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MusicSystem.Models.ViewModels
{
    public class SongVM
    {
        // List of Artists
        public HashSet<SelectListItem> Artists = new HashSet<SelectListItem>();

        [Display(Name = "Artist Name")]
        [Required(ErrorMessage = "Please select an Artist")]
        public int ArtistId { get; set; }

        // List of Albums
        public HashSet<SelectListItem> Albums = new HashSet<SelectListItem>();

        [Display(Name = "Album Title")]
        [Required(ErrorMessage = "Please select an Album")]
        public int AlbumId { get; set; }

        // Song Properties
        [Display(Name = "Title")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters in length.")]
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }

        [Display(Name = "Duration (in seconds)")]
        [Range(30, Int32.MaxValue, ErrorMessage = "Duration must have a minimum duration of 30 seconds.")]
        [Required(ErrorMessage = "Please enter Duration (in seconds)")]
        public int DurationSeconds { get; set; }

        [Display(Name = "Track Number")]
        [Range(1, 20, ErrorMessage = "Albums must contain between 1 and 20 song tracks.")]
        [Required(ErrorMessage = "Please enter Track Number")]
        public int TrackNumber { get; set; }

        public void PopulateArtistsAndAlbums(IEnumerable<Artist> artists, IEnumerable<Album> albums)
        {
            Artists.Add(new SelectListItem { Text = "-- Select Artists --", Value = "" });
            Albums.Add(new SelectListItem { Text = "-- Select Album --", Value = "" });
            foreach (Artist a in artists)
            {
                Artists.Add(new SelectListItem(a.Name, a.Id.ToString()));
            }
            foreach (Album al in albums)
            {
                Albums.Add(new SelectListItem(al.Title, al.Id.ToString()));
            }
        }

        public SongVM(IEnumerable<Artist> artists, IEnumerable<Album> albums)
        {
            PopulateArtistsAndAlbums(artists, albums);
        }

        public SongVM()
        {

        }
    }
}
