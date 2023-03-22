using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicSystem.Models.ViewModels
{
    public class PodcastListenerListVM
    {
        public HashSet<SelectListItem> ListenerLists { get; set; } = new HashSet<SelectListItem>();
        public int ListenerListId { get; set; }
        public Podcast Podcast { get; set; }
        public int PodcastId { get; set; }
        public void PopulateList(IEnumerable<ListenerList> listenerList)
        {
            foreach (ListenerList ll in listenerList)
            {
                ListenerLists.Add(new SelectListItem($"{ll.Description}", ll.Id.ToString()));
            }
        }

        public PodcastListenerListVM(IEnumerable<ListenerList> listenerLists, Podcast podcast)
        {
            PopulateList(listenerLists);
            Podcast = podcast;
            PodcastId = podcast.Id;
        }

        public PodcastListenerListVM() { }
    }
}
