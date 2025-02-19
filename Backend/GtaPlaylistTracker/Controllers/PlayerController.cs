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
        private readonly IWebHostEnvironment _environment;
        public PlayerController(PlayerService playerService, IWebHostEnvironment environment)
        {
            _playerService = playerService;
            _environment = environment;
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
        public async Task<ActionResult<IEnumerable<Player>>> GetAllPlayers()
        {
            var players = await _playerService.GetAllPlayersAsync();
            if (players == null)
            {
                return NotFound();
            }
            return Ok(players);
        }

        [HttpPost("UploadProfilePicture/{playerId}")]
        public async Task<IActionResult> UploadProfilePicture(int playerId, IFormFile file)
        {
            var player = await _playerService.GetPlayerByIdAsync(playerId);
            if (player == null)
            {
                return NotFound("Player not found");
            }
            if (file== null || file.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Generates a unique filename
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            player.ProfilePictureUrl = $"/uploads/{fileName}";
            await _playerService.UpdatePlayerAsync(player);


            return Ok(new { profilePictureUrl = player.ProfilePictureUrl });
        }
    }
}
