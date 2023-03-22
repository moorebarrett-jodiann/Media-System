using System.ComponentModel.DataAnnotations;

namespace MusicSystem.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters in length.")]
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        public HashSet<SongContributor> SongContributors { get; set; } = new HashSet<SongContributor>();
        public HashSet<EpisodeArtist> EpisodeArtists { get; set; } = new HashSet<EpisodeArtist>();
        public HashSet<PodcastArtist> PodcastArtists { get; set; } = new HashSet<PodcastArtist>();
        public Artist() { }
        public Artist(string name)
        {
            Name = name;
        }
    }
}
