using System.ComponentModel.DataAnnotations;

namespace MusicSystem.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        [Display(Name = "Playlist Name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Playlist Name must be between 2 and 100 characters in length.")]
        [Required(ErrorMessage = "Please enter Playlist Name")]
        public string Name { get; set; }
        public HashSet<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();
        public Playlist() { }
        public Playlist(string name)
        {
            Name = name;
        }
    }
}
