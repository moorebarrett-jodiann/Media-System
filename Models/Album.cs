namespace MusicSystem.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public HashSet<Song> Songs { get; set; } = new HashSet<Song>();
        public Album() { }
        public Album(string title)
        {
            Title = title;
        }
    }
}
