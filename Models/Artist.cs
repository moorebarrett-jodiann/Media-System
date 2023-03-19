using System.ComponentModel.DataAnnotations;

namespace MusicSystem.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Display(Name = "Artist Name")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Artist Name must be between 10 and 100 characters in length.")]
        [Required(ErrorMessage = "Please enter Artist Name")]
        public string Name { get; set; }
        public HashSet<SongContributor> SongContributors { get; set; } = new HashSet<SongContributor>();
        public Artist() { }
        public Artist(string name)
        {
            Name = name;
        }
    }
}
