using System.ComponentModel.DataAnnotations;

namespace MusicSystem.Models
{
    public class MediaCollection
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters in length.")]
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }
    }

    public class Album : MediaCollection
    {
        public HashSet<Song> Songs { get; set; } = new HashSet<Song>();
        public Album() : base() 
        {

        }
        public Album(string title)
        {
            Title = title;
        }
    }

    public class Podcast : MediaCollection
    {
        public HashSet<Episode> Episodes { get; set; } = new HashSet<Episode>();
        public HashSet<PodcastArtist> MainCast { get; set; } = new HashSet<PodcastArtist>();
        public HashSet<ListenerListPodcast> ListenerListPodcasts { get; set; } = new HashSet<ListenerListPodcast>();
        public Podcast() : base()
        {

        }
        public Podcast(string title)
        {
            Title = title;
        }
    }
}
