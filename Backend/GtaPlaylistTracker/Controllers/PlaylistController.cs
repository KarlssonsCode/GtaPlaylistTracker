using GtaPlaylistTracker.Contracts.Requests;
using GtaPlaylistTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace GtaPlaylistTracker.Controllers
{
    [Route("/Playlist")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly PlaylistService _playlistService;
        public PlaylistController(PlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpPost("CreatePlaylist")]
        public async Task<IActionResult> CreatePlaylist(CreatePlaylistRequest playlistRequest)
        {
            var createdPlaylist = await _playlistService.CreatePlaylistAsync(playlistRequest);
            if (createdPlaylist != null)
            {
                return Ok(createdPlaylist);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("GetAllPlaylists")]
        public async Task<IActionResult> GetAllPlaylists()
        {
            var playlists = await _playlistService.GetAllPlaylistsAsync();
            return Ok(playlists);
        }

    }
}
