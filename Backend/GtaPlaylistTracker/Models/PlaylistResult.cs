using System.ComponentModel.DataAnnotations;

namespace GtaPlaylistTracker.Models
{
    public class PlaylistResult
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PlaylistId { get; set;}
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public double Points { get; set;}
        [Required]
        public double FinishPosition { get; set; }
        [Required]
        public bool RageQuit { get; set; }

        public Player Player { get; set; }
        public Playlist Playlist { get; set; }

    }
}
