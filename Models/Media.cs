using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicSystem.Models
{
    public class Media
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters in length.")]
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }

        [Display(Name = "Duration (in seconds)")]
        [Range(30, Int32.MaxValue, ErrorMessage = "Duration must have a minimum duration of 30 seconds.")]
        [Required(ErrorMessage = "Please enter Duration (in seconds)")]
        public int DurationInSeconds { get; set; }
        public int MediaCollectionId { get; set; }
    }

    public class Song : Media
    {
        [Display(Name = "Track Number")]
        [Range(1, 20, ErrorMessage = "Albums must contain between 1 and 20 song tracks.")]
        [Required(ErrorMessage = "Please enter Track Number")]
        public int TrackNumber { get; set; }
        public HashSet<SongContributor> SongContributors { get; set; } = new HashSet<SongContributor>();
        public HashSet<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();
        public virtual Album Album { get; set; }
        public Song() : base() 
        {

        }
        public Song(string title, int duration, int trackNum, Album album)
        {
            Title = title;
            DurationInSeconds = duration;
            TrackNumber = trackNum;
            Album = album;
        }
    }

    public class Episode : Media
    {
        [Display(Name = "Air Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime AirDate { get; set; }
        public HashSet<EpisodeArtist>? GuestArtists { get; set; } = new HashSet<EpisodeArtist>();
        public virtual Podcast Podcast { get; set; }
        public Episode() : base()
        {

        }
        public Episode(string title, int duration, DateTime airDate, Podcast podcast)
        {
            Title = title;
            DurationInSeconds = duration;
            AirDate = airDate;
            Podcast = podcast;
        }
    }

    public enum SortOrder
    {
        [Display(Name = "Duration Ascending")]
        DurationAscending,
        [Display(Name = "Duration Descending")]
        DurationDescending,
        [Display(Name = "Air Date Ascending")]
        AirDateAscending,
        [Display(Name = "Air Date Descending")]
        AirDateDescending
    }
}
