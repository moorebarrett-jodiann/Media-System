namespace MusicSystem.Models
{
    public class EpisodeArtist
    {
        public int Id { get; set; }
        public virtual Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public virtual Episode Episode { get; set; }
        public int EpisodeId { get; set; }
        public EpisodeArtist() { }

        public EpisodeArtist(Artist artist, Episode episode)
        {
            Artist = artist;
            ArtistId = artist.Id;
            Episode = episode;
            EpisodeId = episode.Id;
        }
    }
}
