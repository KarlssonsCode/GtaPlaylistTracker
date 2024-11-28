using System.ComponentModel.DataAnnotations;

namespace GtaPlaylistTracker.Models
{
    public class Playlist
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int GameId { get; set; }
        [Required]
        public int Races { get; set; }

        public Game Game { get; set; }

        public ICollection<PlaylistResult> PlaylistResults { get; set; }
    }
}
