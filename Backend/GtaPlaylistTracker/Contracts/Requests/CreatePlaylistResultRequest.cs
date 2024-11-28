using System.ComponentModel.DataAnnotations;

namespace GtaPlaylistTracker.Contracts.Requests
{
    public class CreatePlaylistResultRequest
    {
        [Required]
        public int PlaylistId { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public double Points { get; set; }        
        public double FinishPosition { get; set; }
        [Required]
        public bool RageQuit { get; set; }

    }
}
