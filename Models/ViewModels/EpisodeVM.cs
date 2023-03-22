using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MusicSystem.Models.ViewModels
{
    public class EpisodeVM
    {
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

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Required(ErrorMessage = "Please enter Air Date")]
        public DateTime AirDate { get; set; }

        public void PopulatePodcasts(IEnumerable<Podcast> podcasts)
        {
            Podcasts.Add(new SelectListItem { Text = "-- Select Podcast --", Value = "" });
            foreach (Podcast p in podcasts)
            {
                Podcasts.Add(new SelectListItem(p.Title, p.Id.ToString()));
            }
        }

        public EpisodeVM(IEnumerable<Podcast> podcasts)
        {
            PopulatePodcasts(podcasts);
        }

        public EpisodeVM()
        {

        }
    }
}
