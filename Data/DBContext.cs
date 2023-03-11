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

        public DbSet<Song> Song { get; set; } = default!;
        public DbSet<Artist> Artist { get; set; } = default!;
        public DbSet<Album> Album { get; set; } = default!;
        public DbSet<Playlist> Playlist { get; set; } = default!;
        public DbSet<PlaylistSong> PlaylistSong { get; set; } = default!;
        public DbSet<SongContributor> SongContributor { get; set; } = default!;
    }
}
