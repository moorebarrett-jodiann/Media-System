namespace MusicSystem.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();
        public Playlist() { }
        public Playlist(string name)
        {
            Name = name;
        }
    }
}
