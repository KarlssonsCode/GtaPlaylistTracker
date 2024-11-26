using System.ComponentModel.DataAnnotations;

namespace GtaPlaylistTracker.Contracts.Requests
{
    public class CreatePlayerRequest
    {
        [Required]
        public string Gamertag { get; set; }
        public string? Name { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
