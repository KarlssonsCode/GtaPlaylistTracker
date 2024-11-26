using System.ComponentModel.DataAnnotations;

namespace GtaPlaylistTracker.Contracts.Requests
{
    public class CreateGameRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
