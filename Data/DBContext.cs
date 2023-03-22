using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicSystem.Models;

namespace MusicSystem.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>()
                .HasDiscriminator<string>("MediaType")
                .HasValue<Song>("Song")
                .HasValue<Episode>("Episode");

            modelBuilder.Entity<Media>()
                .HasKey(k => k.Id)
                .IsClustered(false);

            modelBuilder.Entity<MediaCollection>()
                .HasDiscriminator<string>("MediaCollectionType")
                .HasValue<Album>("Album")
                .HasValue<Podcast>("Podcast");

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(a => a.MediaCollectionId);

            modelBuilder.Entity<Podcast>()
                .HasMany(p => p.Episodes)
                .WithOne(e => e.Podcast)
                .HasForeignKey(p => p.MediaCollectionId);

            modelBuilder.Entity<Song>()
                .HasMany(s => s.SongContributors)
                .WithOne(sc => sc.Song)
                .HasForeignKey(sc => sc.SongId);

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.SongContributors)
                .WithOne(sc => sc.Artist)
                .HasForeignKey(sc => sc.ArtistId);

            modelBuilder.Entity<Episode>()
                .HasMany(e => e.GuestArtists)
                .WithOne(ea => ea.Episode)
                .HasForeignKey(ea => ea.EpisodeId);

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.EpisodeArtists)
                .WithOne(ea => ea.Artist)
                .HasForeignKey(ea => ea.ArtistId);

            modelBuilder.Entity<Podcast>()
                .HasMany(p => p.MainCast)
                .WithOne(mc => mc.Podcast)
                .HasForeignKey(mc => mc.PodcastId);

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.PodcastArtists)
                .WithOne(pa => pa.Artist)
                .HasForeignKey(pa => pa.ArtistId);

            modelBuilder.Entity<Podcast>()
                .HasMany(p => p.ListenerListPodcasts)
                .WithOne(llp => llp.Podcast)
                .HasForeignKey(llp => llp.PodcastId);

            modelBuilder.Entity<ListenerList>()
                .HasMany(ll => ll.ListenerListPodcasts)
                .WithOne(llp => llp.ListenerList)
                .HasForeignKey(llp => llp.ListenerListId);

            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.PlaylistSongs)
                .WithOne(ps => ps.Playlist)
                .HasForeignKey(ps => ps.PlaylistId);

            modelBuilder.Entity<Song>()
                .HasMany(s => s.PlaylistSongs)
                .WithOne(ps => ps.Song)
                .HasForeignKey(ps => ps.SongId);

        }

        public DbSet<Artist> Artist { get; set; } = default!;
        public DbSet<Album> Album { get; set; } = default!;
        public DbSet<Podcast> Podcast { get; set; } = default!;
        public DbSet<Song> Song { get; set; } = default!;
        public DbSet<Episode> Episode { get; set; } = default!;
        public DbSet<Playlist> Playlist { get; set; } = default!;
        public DbSet<PlaylistSong> PlaylistSong { get; set; } = default!;
        public DbSet<SongContributor> SongContributor { get; set; } = default!;
        public DbSet<EpisodeArtist> EpisodeArtist { get; set; } = default!;
        public DbSet<PodcastArtist> PodcastArtist { get; set; } = default!;
        public DbSet<ListenerList> ListenerList { get; set; } = default!;
        public DbSet<ListenerListPodcast> ListenerListPodcast { get; set; } = default!;
    }
}
