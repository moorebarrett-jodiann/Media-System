using Microsoft.EntityFrameworkCore;
using MusicSystem.Models;

namespace MusicSystem.Data
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
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
            Artist artist12 = new Artist("Joe Rogan");
            Artist artist13 = new Artist("Charlamagne Tha God");
            Artist artist14 = new Artist("The Economist Group");
            Artist artist15 = new Artist("Kendra Adachi");

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
            if (!context.Album.Any())
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
            Song song1 = new Song("Blacksmith", 240, 3, album2);
            album2.Songs.Add(song1);
            Song song2 = new Song("In Remorse", 357, 1, album5);
            album5.Songs.Add(song2);
            Song song3 = new Song("Funeral", 180, 2, album7);
            album7.Songs.Add(song3);
            Song song4 = new Song("Shadows & Light", 259, 3, album6);
            album6.Songs.Add(song4);
            Song song5 = new Song("Maiden Star", 413, 1, album2);
            album2.Songs.Add(song5);
            Song song6 = new Song("Wake Me Up When September Ends", 285, 3, album1);
            album1.Songs.Add(song6);
            Song song7 = new Song("Eclipse", 130, 4, album4);
            album4.Songs.Add(song7);
            Song song8 = new Song("Master of Puppets", 515, 3, album8);
            album8.Songs.Add(song8);
            Song song9 = new Song("The Ringer", 337, 4, album9);
            album9.Songs.Add(song9);
            Song song10 = new Song("Church on Sunday", 198, 2, album10);
            album10.Songs.Add(song10);
            Song song11 = new Song("Escape", 264, 1, album3);
            album3.Songs.Add(song11);
            Song song12 = new Song("Holiday / Boulevard of Broken Dreams", 493, 1, album1);
            album1.Songs.Add(song12);
            Song song13 = new Song("Stepping Stone", 309, 3, album9);
            album9.Songs.Add(song13);
            Song song14 = new Song("Miles From Home", 407, 2, album5);
            album5.Songs.Add(song14);
            Song song15 = new Song("Orion", 507, 1, album8);
            album8.Songs.Add(song15);
            Song song16 = new Song("Whatshername", 257, 4, album1);
            album1.Songs.Add(song16);
            Song song17 = new Song("Fight Fire With Fire", 285, 2, album3);
            album3.Songs.Add(song17);
            Song song18 = new Song("The Thing That Should Not Be", 396, 2, album8);
            album8.Songs.Add(song18);
            Song song19 = new Song("Any Color You Like", 206, 3, album4);
            album4.Songs.Add(song19);
            Song song20 = new Song("On The Run", 225, 2, album4);
            album4.Songs.Add(song20);
            Song song21 = new Song("Misery", 289, 2, album2);
            album2.Songs.Add(song21);
            Song song22 = new Song("Crown", 296, 1, album7);
            album7.Songs.Add(song22);
            Song song23 = new Song("Homecoming", 558, 2, album1);
            album1.Songs.Add(song23);
            Song song24 = new Song("Fall", 262, 5, album9);
            album9.Songs.Add(song24);
            Song song25 = new Song("Fearce", 254, 3, album5);
            album5.Songs.Add(song25);
            Song song26 = new Song("Hold On", 117, 1, album10);
            album10.Songs.Add(song26);
            Song song27 = new Song("Fade to Black", 417, 3, album3);
            album3.Songs.Add(song27);
            Song song28 = new Song("Us And Them", 469, 1, album4);
            album4.Songs.Add(song28);
            Song song29 = new Song("Normal", 222, 1, album9);
            album9.Songs.Add(song29);
            Song song30 = new Song("Nice Guy (with Jesse Reyez)", 150, 2, album9);
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

            // save seeded data to db
            await context.SaveChangesAsync();

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

            // seed podcasts
            Podcast p1 = new Podcast("The Joe Rogan Experience");
            Podcast p2 = new Podcast("The Economist");
            Podcast p3 = new Podcast("The Lazy Genius");
            Podcast p4 = new Podcast("The Breakfast Club");

            // add new podcasts to the context
            if (!context.Podcast.Any())
            {
                context.Podcast.Add(p1);
                context.Podcast.Add(p2);
                context.Podcast.Add(p3);
                context.Podcast.Add(p4);
            }

            //seed podcast artists
            PodcastArtist pa1 = new PodcastArtist(artist12, p1);
            p1.MainCast.Add(pa1);
            artist12.PodcastArtists.Add(pa1);
            PodcastArtist pa2 = new PodcastArtist(artist14, p2);
            p1.MainCast.Add(pa2);
            artist14.PodcastArtists.Add(pa2);
            PodcastArtist pa3 = new PodcastArtist(artist15, p3);
            p3.MainCast.Add(pa3);
            artist15.PodcastArtists.Add(pa3);
            PodcastArtist pa4 = new PodcastArtist(artist13, p4);
            p4.MainCast.Add(pa4);
            artist13.PodcastArtists.Add(pa4);

            // add new podcast artists to the context
            context.PodcastArtist.Add(pa1);
            context.PodcastArtist.Add(pa2);
            context.PodcastArtist.Add(pa3);
            context.PodcastArtist.Add(pa4);

            // seed listener lists
            ListenerList ll1 = new ListenerList("My podcasts for entertainment.");
            ListenerList ll2 = new ListenerList("My podcasts for motivation.");
            ListenerList ll3 = new ListenerList("My podcasts for education.");

            // add new listener lists to the context
            if (!context.ListenerList.Any())
            {
                context.ListenerList.Add(ll1);
                context.ListenerList.Add(ll2);
                context.ListenerList.Add(ll3);
            }

            // save seeded data to db
            await context.SaveChangesAsync();

            // seed listener list podcasts
            ListenerListPodcast llp1 = new ListenerListPodcast(ll1, p1);
            p1.ListenerListPodcasts.Add(llp1);
            ll1.ListenerListPodcasts.Add(llp1);
            ListenerListPodcast llp2 = new ListenerListPodcast(ll1, p4);
            p4.ListenerListPodcasts.Add(llp2);
            ll1.ListenerListPodcasts.Add(llp2);

            // add listener list podcasts to the contect
            context.ListenerListPodcast.Add(llp1);
            context.ListenerListPodcast.Add(llp2);

            // seed episodes
            Episode episode1 = new Episode("Should we have a four day work week in America?", 660, new DateTime(2022, 02, 28), p4);
            Episode episode2 = new Episode("IRS Asking for thieves to report stolen income", 480, new DateTime(2021, 12, 04), p4);
            Episode episode3 = new Episode("How often do you wash your towels?", 780, new DateTime(2023, 01, 01), p4);
            Episode episode4 = new Episode("What are your thoughts on Rhianna's Superbowl performance?", 660, new DateTime(2023, 02, 20), p4);
            p4.Episodes.Add(episode1);
            p4.Episodes.Add(episode2);
            p4.Episodes.Add(episode3);
            p4.Episodes.Add(episode4);

            Episode episode5 = new Episode("The Real Slim Shady", 860, new DateTime(2022, 07, 10), p1);
            Episode episode6 = new Episode("The beginning of Green Day", 520, new DateTime(2021, 10, 01), p1);
            Episode episode7 = new Episode("The Author and Punisher: Claim to Fame", 610, new DateTime(2023, 01, 04), p1);
            Episode episode8 = new Episode("Covid 19", 450, new DateTime(2023, 03, 11), p1);
            p1.Episodes.Add(episode5);
            p1.Episodes.Add(episode6);
            p1.Episodes.Add(episode7);
            p1.Episodes.Add(episode8);

            Episode episode9 = new Episode("Stopping the spread: How to fix the banks.", 1590, new DateTime(2023, 01, 28), p2);
            Episode episode10 = new Episode("Money Talks: Not made in China.", 1280, DateTime.Now, p2);
            Episode episode11 = new Episode("Money Talks: How globalization gave way.", 2121, DateTime.Now, p2);
            Episode episode12 = new Episode("The Economist Asks: Why is history a family affair?", 901, new DateTime(2022, 02, 28), p2);
            p2.Episodes.Add(episode9);
            p2.Episodes.Add(episode10);
            p2.Episodes.Add(episode11);
            p2.Episodes.Add(episode12);

            Episode episode13 = new Episode("What we need to have more fun.", 1203, new DateTime(2022, 12, 30), p3);
            Episode episode14 = new Episode("How to rest when you're caring for everyone else.", 850, DateTime.Now, p3);
            Episode episode15 = new Episode("5 steps for more ease at work.", 1428, new DateTime(2023, 01, 17), p3);
            Episode episode16 = new Episode("How to fix dinner when you're never home.", 619, DateTime.Now, p3);
            p3.Episodes.Add(episode13);
            p3.Episodes.Add(episode14);
            p3.Episodes.Add(episode15);
            p3.Episodes.Add(episode16);

            // add new episodes to the context
            if (!context.Episode.Any())
            {
                context.Episode.Add(episode1);
                context.Episode.Add(episode2);
                context.Episode.Add(episode3);
                context.Episode.Add(episode4);
                context.Episode.Add(episode5);
                context.Episode.Add(episode6);
                context.Episode.Add(episode7);
                context.Episode.Add(episode8);
                context.Episode.Add(episode9);
                context.Episode.Add(episode10);
                context.Episode.Add(episode11);
                context.Episode.Add(episode12);
                context.Episode.Add(episode13);
                context.Episode.Add(episode14);
                context.Episode.Add(episode15);
                context.Episode.Add(episode16);
            }

            // seed episode artists
            EpisodeArtist ea1 = new EpisodeArtist(artist4, episode1);
            episode1.GuestArtists.Add(ea1);
            artist4.EpisodeArtists.Add(ea1);
            EpisodeArtist ea2 = new EpisodeArtist(artist12, episode2);
            episode2.GuestArtists.Add(ea2);
            artist12.EpisodeArtists.Add(ea2);
            EpisodeArtist ea3 = new EpisodeArtist(artist7, episode3);
            episode3.GuestArtists.Add(ea3);
            artist7.EpisodeArtists.Add(ea3);
            EpisodeArtist ea4 = new EpisodeArtist(artist1, episode4);
            episode4.GuestArtists.Add(ea4);
            artist1.EpisodeArtists.Add(ea4);
            EpisodeArtist ea5 = new EpisodeArtist(artist3, episode5);
            episode5.GuestArtists.Add(ea5);
            artist3.EpisodeArtists.Add(ea5);
            EpisodeArtist ea6 = new EpisodeArtist(artist5, episode6);
            episode6.GuestArtists.Add(ea6);
            artist5.EpisodeArtists.Add(ea6);
            EpisodeArtist ea7 = new EpisodeArtist(artist1, episode7);
            episode7.GuestArtists.Add(ea7);
            artist1.EpisodeArtists.Add(ea7);
            EpisodeArtist ea8 = new EpisodeArtist(artist2, episode8);
            episode8.GuestArtists.Add(ea8);
            artist2.EpisodeArtists.Add(ea8);
            EpisodeArtist ea9 = new EpisodeArtist(artist15, episode9);
            episode9.GuestArtists.Add(ea9);
            artist15.EpisodeArtists.Add(ea9);
            EpisodeArtist ea10 = new EpisodeArtist(artist14, episode10);
            episode10.GuestArtists.Add(ea10);
            artist14.EpisodeArtists.Add(ea10);
            EpisodeArtist ea11 = new EpisodeArtist(artist8, episode11);
            episode11.GuestArtists.Add(ea11);
            artist8.EpisodeArtists.Add(ea11);
            EpisodeArtist ea12 = new EpisodeArtist(artist9, episode12);
            episode12.GuestArtists.Add(ea12);
            artist9.EpisodeArtists.Add(ea12);
            EpisodeArtist ea13 = new EpisodeArtist(artist10, episode13);
            episode13.GuestArtists.Add(ea13);
            artist10.EpisodeArtists.Add(ea13);
            EpisodeArtist ea14 = new EpisodeArtist(artist11, episode14);
            episode14.GuestArtists.Add(ea14);
            artist11.EpisodeArtists.Add(ea14);
            EpisodeArtist ea15 = new EpisodeArtist(artist15, episode15);
            episode15.GuestArtists.Add(ea15);
            artist15.EpisodeArtists.Add(ea15);
            EpisodeArtist ea16 = new EpisodeArtist(artist2, episode16);
            episode16.GuestArtists.Add(ea16);
            artist2.EpisodeArtists.Add(ea16);

            // add new episode artists to context
            context.EpisodeArtist.Add(ea1);
            context.EpisodeArtist.Add(ea2);
            context.EpisodeArtist.Add(ea3);
            context.EpisodeArtist.Add(ea4);
            context.EpisodeArtist.Add(ea5);
            context.EpisodeArtist.Add(ea6);
            context.EpisodeArtist.Add(ea7);
            context.EpisodeArtist.Add(ea8);
            context.EpisodeArtist.Add(ea9);
            context.EpisodeArtist.Add(ea10);
            context.EpisodeArtist.Add(ea11);
            context.EpisodeArtist.Add(ea12);
            context.EpisodeArtist.Add(ea13);
            context.EpisodeArtist.Add(ea14);
            context.EpisodeArtist.Add(ea15);
            context.EpisodeArtist.Add(ea16);

            // save seeded data to db
            await context.SaveChangesAsync();
        }
    }
}
