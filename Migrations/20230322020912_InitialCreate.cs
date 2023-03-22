using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListenerList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenerList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MediaCollectionType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListenerListPodcast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListenerListId = table.Column<int>(type: "int", nullable: false),
                    PodcastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenerListPodcast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListenerListPodcast_ListenerList_ListenerListId",
                        column: x => x.ListenerListId,
                        principalTable: "ListenerList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListenerListPodcast_MediaCollection_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "MediaCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DurationInSeconds = table.Column<int>(type: "int", nullable: false),
                    MediaCollectionId = table.Column<int>(type: "int", nullable: false),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrackNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Media_MediaCollection_MediaCollectionId",
                        column: x => x.MediaCollectionId,
                        principalTable: "MediaCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastArtist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    PodcastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastArtist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PodcastArtist_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastArtist_MediaCollection_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "MediaCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeArtist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    EpisodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeArtist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EpisodeArtist_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeArtist_Media_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistSong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false),
                    PlaylistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistSong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistSong_Media_SongId",
                        column: x => x.SongId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistSong_Playlist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongContributor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongContributor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongContributor_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongContributor_Media_SongId",
                        column: x => x.SongId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeArtist_ArtistId",
                table: "EpisodeArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeArtist_EpisodeId",
                table: "EpisodeArtist",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListenerListPodcast_ListenerListId",
                table: "ListenerListPodcast",
                column: "ListenerListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListenerListPodcast_PodcastId",
                table: "ListenerListPodcast",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_MediaCollectionId",
                table: "Media",
                column: "MediaCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSong_PlaylistId",
                table: "PlaylistSong",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSong_SongId",
                table: "PlaylistSong",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastArtist_ArtistId",
                table: "PodcastArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastArtist_PodcastId",
                table: "PodcastArtist",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_SongContributor_ArtistId",
                table: "SongContributor",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_SongContributor_SongId",
                table: "SongContributor",
                column: "SongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodeArtist");

            migrationBuilder.DropTable(
                name: "ListenerListPodcast");

            migrationBuilder.DropTable(
                name: "PlaylistSong");

            migrationBuilder.DropTable(
                name: "PodcastArtist");

            migrationBuilder.DropTable(
                name: "SongContributor");

            migrationBuilder.DropTable(
                name: "ListenerList");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "MediaCollection");
        }
    }
}
