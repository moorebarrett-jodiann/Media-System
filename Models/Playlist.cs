using System.ComponentModel.DataAnnotations;

namespace MusicSystem.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters in length.")]
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        public HashSet<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();
        public Playlist() { }
        public Playlist(string name)
        {
            Name = name;
        }
    }
}
