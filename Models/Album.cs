using System.ComponentModel.DataAnnotations;

namespace MusicSystem.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Display(Name = "Album Title")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Album Title must be between 10 and 100 characters in length.")]
        [Required(ErrorMessage = "Please enter Album Title")]
        public string Title { get; set; }
        public HashSet<Song> Songs { get; set; } = new HashSet<Song>();
        public Album() { }
        public Album(string title)
        {
            Title = title;
        }
    }
}
