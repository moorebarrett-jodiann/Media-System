namespace MusicSystem.Models
{
    public class PlaylistSong
    {
        public int Id { get; set; }
        public DateTime TimeAdded { get; set; }
        public virtual Song Song { get; set; }
        public int SongId { get; set; }
        public virtual Playlist Playlist { get; set; }
        public int PlaylistId { get; set; }
        public PlaylistSong() 
        {
            TimeAdded = DateTime.Now;
        }
        public PlaylistSong(DateTime timeAdded, Song song, Playlist playlist)
        {
            TimeAdded = timeAdded;
            Song = song;
            SongId = song.Id;
            Playlist = playlist;
            PlaylistId = playlist.Id;
        }
    }
}
