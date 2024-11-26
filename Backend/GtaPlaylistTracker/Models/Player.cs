using System.ComponentModel.DataAnnotations;

namespace GtaPlaylistTracker.Models
{
    public class Player
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Gamertag { get; set; }
        public string? Name { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
