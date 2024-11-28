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

        protected override void OnModelCreating(ModelBuilder modelBuilder) //ChatGPT
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite primary key for PlaylistResult
            modelBuilder.Entity<PlaylistResult>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PlaylistId });

                // Define relationships
                entity.HasOne(e => e.Player)
                    .WithMany(p => p.PlaylistResults) // Assuming Player has a collection of PlaylistResults
                    .HasForeignKey(e => e.PlayerId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Playlist)
                    .WithMany(p => p.PlaylistResults) // Assuming Playlist has a collection of PlaylistResults
                    .HasForeignKey(e => e.PlaylistId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
