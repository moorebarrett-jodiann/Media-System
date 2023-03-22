namespace MusicSystem.Models
{
    public class PodcastArtist
    {
        public int Id { get; set; }
        public virtual Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public virtual Podcast Podcast { get; set; }
        public int PodcastId { get; set; }
        public PodcastArtist() { }

        public PodcastArtist(Artist artist, Podcast podcast)
        {
            Artist = artist;
            ArtistId = artist.Id;
            Podcast = podcast;
            PodcastId = podcast.Id;
        }
    }
}
