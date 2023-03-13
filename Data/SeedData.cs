using Microsoft.EntityFrameworkCore;
using MusicSystem.Models;

namespace MusicSystem.Data
{
    public static class SeedData
    {
        public async static Task Initialize (IServiceProvider serviceProvider)
        {
            DBContext context = new DBContext(serviceProvider.GetRequiredService<DbContextOptions<DBContext>>());

            // set db initialization strategies
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            // seed artists
            Artist artist1 = new Artist("Author & Punisher");
            Artist artist2 = new Artist("Vytear");
            Artist artist3 = new Artist("Eminem");
            Artist artist4 = new Artist("Myrkur");
            Artist artist5 = new Artist("Green Day");
            Artist artist6 = new Artist("Chelsea Wolfe");
            Artist artist7 = new Artist("Metallica");
            Artist artist8 = new Artist("Saudade");
            Artist artist9 = new Artist("Chino Moreno");
            Artist artist10 = new Artist("Pink Floyd");
            Artist artist11 = new Artist("Jessie Reyez");

            // add new artists to the context
            if (!context.Artist.Any())
            {
                context.Artist.Add(artist1);
                context.Artist.Add(artist2);
                context.Artist.Add(artist3);
                context.Artist.Add(artist4);
                context.Artist.Add(artist5);
                context.Artist.Add(artist6);
                context.Artist.Add(artist7);
                context.Artist.Add(artist8);
                context.Artist.Add(artist9);
                context.Artist.Add(artist10);
                context.Artist.Add(artist11);
            }

            // seed albums
            Album album1 = new Album("American Idiot");
            Album album2 = new Album("Kruller");
            Album album3 = new Album("Ride the Lightning");
            Album album4 = new Album("Dark Side of the Moon");
            Album album5 = new Album("Women & Children");
            Album album6 = new Album("Shadows & Light");
            Album album7 = new Album("Mareridt (Delux Edition)");
            Album album8 = new Album("Master of Puppets");
            Album album9 = new Album("Kamikaze");
            Album album10 = new Album("Warning");

            // add new albums to the context
            if(!context.Album.Any())
            {
                context.Album.Add(album1);
                context.Album.Add(album2);
                context.Album.Add(album3);
                context.Album.Add(album4);
                context.Album.Add(album5);
                context.Album.Add(album6);
                context.Album.Add(album7);
                context.Album.Add(album8);
                context.Album.Add(album9);
                context.Album.Add(album10);
            }

            // seed playlists
            Playlist playlist1 = new Playlist("Workout Songs");
            Playlist playlist2 = new Playlist("My Focus Playlist");
            Playlist playlist3 = new Playlist("Saturday Jam");

            // add new playlists to the context
            if (!context.Playlist.Any())
            {
                context.Playlist.Add(playlist1);
                context.Playlist.Add(playlist2);
                context.Playlist.Add(playlist3);
            }

            // save seeded data to db
            await context.SaveChangesAsync();

            // seed songs
            Song song1 = new Song("Blacksmith", 240, album2);
            album2.Songs.Add(song1);
            Song song2 = new Song("In Remorse", 357, album5);
            album5.Songs.Add(song2);
            Song song3 = new Song("Funeral", 180, album7);
            album7.Songs.Add(song3);
            Song song4 = new Song("Shadows & Light", 259, album6);
            album6.Songs.Add(song4);
            Song song5 = new Song("Maiden Star", 413, album2);
            album2.Songs.Add(song5);
            Song song6 = new Song("Wake Me Up When September Ends", 285, album1);
            album1.Songs.Add(song6);
            Song song7 = new Song("Eclipse", 130, album4);
            album4.Songs.Add(song7);
            Song song8 = new Song("Master of Puppets", 515, album8);
            album8.Songs.Add(song8);
            Song song9 = new Song("The Ringer", 337, album9);
            album9.Songs.Add(song9);
            Song song10 = new Song("Church on Sunday", 198, album10);
            album10.Songs.Add(song10);
            Song song11 = new Song("Escape", 264, album3);
            album3.Songs.Add(song11);
            Song song12 = new Song("Holiday / Boulevard of Broken Dreams", 493, album1);
            album1.Songs.Add(song12);
            Song song13 = new Song("Stepping Stone", 309, album9);
            album9.Songs.Add(song13);
            Song song14 = new Song("Miles From Home", 407, album5);
            album5.Songs.Add(song14);
            Song song15 = new Song("Orion", 507, album8);
            album8.Songs.Add(song15);
            Song song16 = new Song("Whatshername", 257, album1);
            album1.Songs.Add(song16);
            Song song17 = new Song("Fight Fire With Fire", 285, album3);
            album3.Songs.Add(song17);
            Song song18 = new Song("The Thing That Should Not Be", 396, album8);
            album8.Songs.Add(song18);
            Song song19 = new Song("Any Color You Like", 206, album4);
            album4.Songs.Add(song19);
            Song song20 = new Song("On The Run", 225, album4);
            album4.Songs.Add(song20);
            Song song21 = new Song("Misery", 289, album2);
            album2.Songs.Add(song21);
            Song song22 = new Song("Crown", 296, album7);
            album7.Songs.Add(song22);
            Song song23 = new Song("Homecoming", 558, album1);
            album1.Songs.Add(song23);
            Song song24 = new Song("Fall", 262, album9);
            album9.Songs.Add(song24);
            Song song25 = new Song("Fearce", 254, album5);
            album5.Songs.Add(song25);
            Song song26 = new Song("Hold On", 117, album10);
            album10.Songs.Add(song26);
            Song song27 = new Song("Fade to Black", 417, album3);
            album3.Songs.Add(song27);
            Song song28 = new Song("Us And Them", 469, album4);
            album4.Songs.Add(song28);
            Song song29 = new Song("Normal", 222, album9);
            album9.Songs.Add(song29);
            Song song30 = new Song("Nice Guy (with Jesse Reyez)", 150, album9);
            album9.Songs.Add(song30);

            // add new songs to the context
            if (!context.Song.Any())
            {
                context.Song.Add(song1);
                context.Song.Add(song2);
                context.Song.Add(song3);
                context.Song.Add(song4);
                context.Song.Add(song5);
                context.Song.Add(song6);
                context.Song.Add(song7);
                context.Song.Add(song8);
                context.Song.Add(song9);
                context.Song.Add(song10);
                context.Song.Add(song11);
                context.Song.Add(song12);
                context.Song.Add(song13);
                context.Song.Add(song14);
                context.Song.Add(song15);
                context.Song.Add(song16);
                context.Song.Add(song17);
                context.Song.Add(song18);
                context.Song.Add(song19);
                context.Song.Add(song20);
                context.Song.Add(song21);
                context.Song.Add(song22);
                context.Song.Add(song23);
                context.Song.Add(song24);
                context.Song.Add(song25);
                context.Song.Add(song26);
                context.Song.Add(song27);
                context.Song.Add(song28);
                context.Song.Add(song29);
                context.Song.Add(song30);
            }

            // seed playlist songs and middle relationships with songs and playlists
            PlaylistSong ps1 = new PlaylistSong(new DateTime(2023, 02, 28, 00, 01, 00), song1, playlist1);
            song1.PlaylistSongs.Add(ps1);
            playlist1.PlaylistSongs.Add(ps1);
            PlaylistSong ps2 = new PlaylistSong(new DateTime(2023, 02, 28, 22, 00, 00), song4, playlist1);
            song4.PlaylistSongs.Add(ps2);
            playlist1.PlaylistSongs.Add(ps2);
            PlaylistSong ps3 = new PlaylistSong(new DateTime(2023, 02, 28, 11, 16, 00), song6, playlist1);
            song6.PlaylistSongs.Add(ps3);
            playlist1.PlaylistSongs.Add(ps3);
            PlaylistSong ps4 = new PlaylistSong(new DateTime(2023, 03, 01, 09, 10, 00), song9, playlist1);
            song9.PlaylistSongs.Add(ps4);
            playlist1.PlaylistSongs.Add(ps4);

            PlaylistSong ps5 = new PlaylistSong(new DateTime(2023, 02, 28, 13, 00, 00), song2, playlist2);
            song2.PlaylistSongs.Add(ps5);
            playlist2.PlaylistSongs.Add(ps5);
            PlaylistSong ps6 = new PlaylistSong(new DateTime(2023, 02, 28, 12, 04, 00), song5, playlist2);
            song5.PlaylistSongs.Add(ps6);
            playlist2.PlaylistSongs.Add(ps6);
            PlaylistSong ps7 = new PlaylistSong(new DateTime(2023, 03, 01, 00, 22, 00), song26, playlist2);
            song26.PlaylistSongs.Add(ps7);
            playlist2.PlaylistSongs.Add(ps7);
            PlaylistSong ps8 = new PlaylistSong(new DateTime(2023, 02, 28, 19, 19, 19), song7, playlist2);
            song7.PlaylistSongs.Add(ps8);
            playlist2.PlaylistSongs.Add(ps8);

            PlaylistSong ps9 = new PlaylistSong(new DateTime(2023, 02, 28, 00, 30, 00), song3, playlist3);
            song3.PlaylistSongs.Add(ps9);
            playlist3.PlaylistSongs.Add(ps9);
            PlaylistSong ps10 = new PlaylistSong(new DateTime(2023, 02, 28, 10, 16, 00), song6, playlist3);
            song6.PlaylistSongs.Add(ps10);
            playlist3.PlaylistSongs.Add(ps10);
            PlaylistSong ps11 = new PlaylistSong(new DateTime(2023, 02, 28, 00, 00, 28), song8, playlist3);
            song8.PlaylistSongs.Add(ps11);
            playlist3.PlaylistSongs.Add(ps11);
            PlaylistSong ps12 = new PlaylistSong(new DateTime(2023, 03, 01, 09, 00, 00), song16, playlist3);
            song16.PlaylistSongs.Add(ps12);
            playlist3.PlaylistSongs.Add(ps12);
            PlaylistSong ps13 = new PlaylistSong(new DateTime(2023, 03, 01, 22, 00, 00), song24, playlist3);
            song24.PlaylistSongs.Add(ps13);
            playlist3.PlaylistSongs.Add(ps13);            

            // add new playlist songs to the context
            context.PlaylistSong.Add(ps1);
            context.PlaylistSong.Add(ps2);
            context.PlaylistSong.Add(ps3);
            context.PlaylistSong.Add(ps4);
            context.PlaylistSong.Add(ps5);
            context.PlaylistSong.Add(ps6);
            context.PlaylistSong.Add(ps7);
            context.PlaylistSong.Add(ps8);
            context.PlaylistSong.Add(ps9);
            context.PlaylistSong.Add(ps10);
            context.PlaylistSong.Add(ps11);
            context.PlaylistSong.Add(ps12);
            context.PlaylistSong.Add(ps13);

            // seed song contributors
            SongContributor sc1 = new SongContributor(artist1, song1);
            artist1.SongContributors.Add(sc1);
            song1.SongContributors.Add(sc1);
            SongContributor sc2 = new SongContributor(artist2, song1);
            artist2.SongContributors.Add(sc2);
            song1.SongContributors.Add(sc2);
            SongContributor sc3 = new SongContributor(artist1, song2);
            artist1.SongContributors.Add(sc3);
            song2.SongContributors.Add(sc3);
            SongContributor sc4 = new SongContributor(artist7, song3);
            artist7.SongContributors.Add(sc4);
            song3.SongContributors.Add(sc4);
            SongContributor sc5 = new SongContributor(artist8, song4);
            artist8.SongContributors.Add(sc5);
            song4.SongContributors.Add(sc5);
            SongContributor sc6 = new SongContributor(artist6, song4);
            artist6.SongContributors.Add(sc6);
            song4.SongContributors.Add(sc6);
            SongContributor sc7 = new SongContributor(artist9, song4);
            artist9.SongContributors.Add(sc7);
            song4.SongContributors.Add(sc7);
            SongContributor sc8 = new SongContributor(artist1, song5);
            artist1.SongContributors.Add(sc8);
            song5.SongContributors.Add(sc8);
            SongContributor sc9 = new SongContributor(artist5, song6);
            artist5.SongContributors.Add(sc9);
            song6.SongContributors.Add(sc9);
            SongContributor sc10 = new SongContributor(artist10, song7);
            artist10.SongContributors.Add(sc10);
            song7.SongContributors.Add(sc10);
            SongContributor sc11 = new SongContributor(artist7, song8);
            artist7.SongContributors.Add(sc11);
            song8.SongContributors.Add(sc11);
            SongContributor sc12 = new SongContributor(artist3, song9);
            artist3.SongContributors.Add(sc12);
            song9.SongContributors.Add(sc12);
            SongContributor sc13 = new SongContributor(artist5, song10);
            artist5.SongContributors.Add(sc13);
            song10.SongContributors.Add(sc13);
            SongContributor sc14 = new SongContributor(artist7, song11);
            artist7.SongContributors.Add(sc14);
            song11.SongContributors.Add(sc14);
            SongContributor sc15 = new SongContributor(artist5, song12);
            artist5.SongContributors.Add(sc15);
            song12.SongContributors.Add(sc15);
            SongContributor sc16 = new SongContributor(artist3, song13);
            artist3.SongContributors.Add(sc16);
            song13.SongContributors.Add(sc16);
            SongContributor sc17 = new SongContributor(artist1, song14);
            artist1.SongContributors.Add(sc17);
            song14.SongContributors.Add(sc17);
            SongContributor sc18 = new SongContributor(artist7, song15);
            artist7.SongContributors.Add(sc18);
            song15.SongContributors.Add(sc18);
            SongContributor sc19 = new SongContributor(artist5, song16);
            artist5.SongContributors.Add(sc19);
            song16.SongContributors.Add(sc19);
            SongContributor sc20 = new SongContributor(artist7, song17);
            artist7.SongContributors.Add(sc20);
            song17.SongContributors.Add(sc20);
            SongContributor sc21 = new SongContributor(artist7, song18);
            artist7.SongContributors.Add(sc21);
            song18.SongContributors.Add(sc21);
            SongContributor sc22 = new SongContributor(artist10, song19);
            artist10.SongContributors.Add(sc22);
            song19.SongContributors.Add(sc22);
            SongContributor sc23 = new SongContributor(artist10, song20);
            artist10.SongContributors.Add(sc23);
            song20.SongContributors.Add(sc23);
            SongContributor sc24 = new SongContributor(artist1, song21);
            artist1.SongContributors.Add(sc24);
            song21.SongContributors.Add(sc24);
            SongContributor sc25 = new SongContributor(artist4, song22);
            artist4.SongContributors.Add(sc25);
            song22.SongContributors.Add(sc25);
            SongContributor sc26 = new SongContributor(artist5, song23);
            artist5.SongContributors.Add(sc26);
            song23.SongContributors.Add(sc26);
            SongContributor sc27 = new SongContributor(artist3, song24);
            artist3.SongContributors.Add(sc27);
            song24.SongContributors.Add(sc27);
            SongContributor sc28 = new SongContributor(artist1, song25);
            artist1.SongContributors.Add(sc28);
            song25.SongContributors.Add(sc28);
            SongContributor sc29 = new SongContributor(artist5, song26);
            artist5.SongContributors.Add(sc29);
            song26.SongContributors.Add(sc29);
            SongContributor sc30 = new SongContributor(artist7, song27);
            artist7.SongContributors.Add(sc30);
            song27.SongContributors.Add(sc30);
            SongContributor sc31 = new SongContributor(artist10, song28);
            artist10.SongContributors.Add(sc31);
            song28.SongContributors.Add(sc31);
            SongContributor sc32 = new SongContributor(artist3, song29);
            artist3.SongContributors.Add(sc32);
            song29.SongContributors.Add(sc32);
            SongContributor sc33 = new SongContributor(artist3, song30);
            artist3.SongContributors.Add(sc33);
            song30.SongContributors.Add(sc33);
            SongContributor sc34 = new SongContributor(artist11, song30);
            artist11.SongContributors.Add(sc34);
            song30.SongContributors.Add(sc34);

            // add new song contributors to the context
            context.SongContributor.Add(sc1);
            context.SongContributor.Add(sc2);
            context.SongContributor.Add(sc3);
            context.SongContributor.Add(sc4);
            context.SongContributor.Add(sc5);
            context.SongContributor.Add(sc6);
            context.SongContributor.Add(sc7);
            context.SongContributor.Add(sc8);
            context.SongContributor.Add(sc9);
            context.SongContributor.Add(sc10);
            context.SongContributor.Add(sc11);
            context.SongContributor.Add(sc12);
            context.SongContributor.Add(sc13);
            context.SongContributor.Add(sc14);
            context.SongContributor.Add(sc15);
            context.SongContributor.Add(sc16);
            context.SongContributor.Add(sc17);
            context.SongContributor.Add(sc18);
            context.SongContributor.Add(sc19);
            context.SongContributor.Add(sc20);
            context.SongContributor.Add(sc21);
            context.SongContributor.Add(sc22);
            context.SongContributor.Add(sc23);
            context.SongContributor.Add(sc24);
            context.SongContributor.Add(sc25);
            context.SongContributor.Add(sc27);
            context.SongContributor.Add(sc28);
            context.SongContributor.Add(sc29);
            context.SongContributor.Add(sc30);
            context.SongContributor.Add(sc31);
            context.SongContributor.Add(sc32);
            context.SongContributor.Add(sc33);
            context.SongContributor.Add(sc34);

            // save seeded data to db
            await context.SaveChangesAsync();
        }
    }
}
