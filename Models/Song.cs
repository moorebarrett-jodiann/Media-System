namespace MusicSystem.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DurationSeconds { get; set; }
        public HashSet<SongContributor> SongContributors { get; set; } = new HashSet<SongContributor>();
        public HashSet<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();
        public virtual Album Album { get; set; }
        public int AlbumId { get; set; }
        public Song() { }
        public Song (string title, int duration, Album album)
        {
            Title = title;
            DurationSeconds = duration;
            Album = album;
            AlbumId = album.Id;
        }
    }
}
