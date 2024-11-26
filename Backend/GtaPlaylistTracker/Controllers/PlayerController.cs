using GtaPlaylistTracker.Contracts.Requests;
using GtaPlaylistTracker.Models;
using GtaPlaylistTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace GtaPlaylistTracker.Controllers
{
    [Route("/Player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;
        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost("CreatePlayer")]
        public async Task<IActionResult> CreatePlayer(CreatePlayerRequest playerRequest)
        {
            var createdPlayer = await _playerService.CreatePlayerAsync(playerRequest);
            if (createdPlayer != null)
            {
                return Ok(createdPlayer);
            }
            else
            {
                return BadRequest();
            };
        }

        [HttpGet("GetAllPlayers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var players = await _playerService.GetAllPlayersAsync();
            return Ok(players);
        }
    }
}
