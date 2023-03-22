namespace MusicSystem.Models
{
    public class ListenerListPodcast
    {
        public int Id { get; set; }
        public virtual ListenerList ListenerList { get; set; } = new ListenerList();
        public int ListenerListId { get; set; }
        public virtual Podcast Podcast { get; set; }
        public int PodcastId { get; set; }
        public ListenerListPodcast() { }
        public ListenerListPodcast(ListenerList list, Podcast podcast)
        {
            ListenerList = list;
            ListenerListId = list.Id;
            Podcast = podcast;
            PodcastId = podcast.Id;
        }
    }
}
