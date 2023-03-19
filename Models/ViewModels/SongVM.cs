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
        [Display(Name = "Song Title")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Song Title must be between 2 and 200 characters in length.")]
        [Required(ErrorMessage = "Please enter Song Title")]
        public string Title { get; set; }

        [Display(Name = "Song Duration (in seconds)")]
        [Range(30, 1200, ErrorMessage = "Song Duration must be between 30 and 1200 seconds.")]
        [Required(ErrorMessage = "Please enter Song Duration")]
        public int DurationSeconds { get; set; }

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
