using System.ComponentModel.DataAnnotations;

namespace GtaPlaylistTracker.Models
{
    public class Game
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
