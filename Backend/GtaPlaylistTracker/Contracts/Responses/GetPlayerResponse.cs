using System.ComponentModel.DataAnnotations;

namespace GtaPlaylistTracker.Contracts.Responses
{
    public class GetPlayerResponse
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Gamertag { get; set; }
        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
