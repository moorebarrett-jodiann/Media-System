namespace MusicSystem.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<SongContributor> SongContributors { get; set; } = new HashSet<SongContributor>();
        public Artist() { }
        public Artist(string name)
        {
            Name = name;
        }
    }
}
