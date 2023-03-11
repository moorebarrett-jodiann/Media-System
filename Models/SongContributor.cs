namespace MusicSystem.Models
{
    public class SongContributor
    {
        public int Id { get; set; }
        public virtual Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public virtual Song Song { get; set; }
        public int SongId { get; set; }
        public SongContributor() { }

        public SongContributor(Artist artist, Song song)
        {
            Artist = artist;
            ArtistId = artist.Id;
            Song = song;
            SongId = song.Id;
        }
    }
}
