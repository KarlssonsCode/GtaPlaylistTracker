using System.ComponentModel.DataAnnotations;

namespace GtaPlaylistTracker.Contracts.Requests
{
    public class CreatePlaylistRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int GameId { get; set; }
        [Required]
        public int Races { get; set; }
    }
}
