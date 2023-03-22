using System.ComponentModel.DataAnnotations;

namespace MusicSystem.Models
{
    public class ListenerList
    {
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 2, ErrorMessage = "Description must be between 2 and 200 characters in length.")]
        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }
        public HashSet<ListenerListPodcast> ListenerListPodcasts { get; set; } = new HashSet<ListenerListPodcast>();
        public ListenerList() { }
        public ListenerList(string description)
        {
            Description = description;
        }
    }
}
