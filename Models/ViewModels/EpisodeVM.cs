using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MusicSystem.Models.ViewModels
{
    public class EpisodeVM
    {
        // List of Artists
        public HashSet<SelectListItem>? Artists = new HashSet<SelectListItem>();

        [Display(Name = "Artist Name")]
        public int? ArtistId { get; set; }

        // List of Podcasts
        public HashSet<SelectListItem> Podcasts = new HashSet<SelectListItem>();

        [Display(Name = "Podcast Title")]
        [Required(ErrorMessage = "Please select a Podcast")]
        public int PodcastId { get; set; }

        // Episode Properties
        [Display(Name = "Title")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters in length.")]
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }

        [Display(Name = "Duration (in seconds)")]
        [Range(30, Int32.MaxValue, ErrorMessage = "Duration must have a minimum duration of 30 seconds.")]
        [Required(ErrorMessage = "Please enter Duration")]
        public int DurationSeconds { get; set; }

        [Display(Name = "Air Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Required(ErrorMessage = "Please enter Air Date")]
        public DateTime AirDate { get; set; }

        public void PopulatePodcastsAndArtists(IEnumerable<Artist> artists, IEnumerable<Podcast> podcasts)
        {
            Artists.Add(new SelectListItem { Text = "-- Select Artists --", Value = "" });
            Podcasts.Add(new SelectListItem { Text = "-- Select Podcast --", Value = "" });
            foreach (Artist a in artists)
            {
                Artists.Add(new SelectListItem(a.Name, a.Id.ToString()));
            }            
            foreach (Podcast p in podcasts)
            {
                Podcasts.Add(new SelectListItem(p.Title, p.Id.ToString()));
            }
        }

        public EpisodeVM(IEnumerable<Artist> artists, IEnumerable<Podcast> podcasts)
        {
            PopulatePodcastsAndArtists(artists, podcasts);
        }

        public EpisodeVM()
        {

        }
    }
}
