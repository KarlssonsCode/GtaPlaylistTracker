using GtaPlaylistTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GtaPlaylistTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistResult> PlaylistsResult { get; set; }
        public DbSet<Game> Games { get; set; }

    }
}
