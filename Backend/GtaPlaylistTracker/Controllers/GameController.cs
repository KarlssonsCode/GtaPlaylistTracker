﻿using GtaPlaylistTracker.Contracts.Requests;
using GtaPlaylistTracker.Models;
using GtaPlaylistTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace GtaPlaylistTracker.Controllers
{
    [Route("/Game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;
        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }
        [HttpPost("AddGame")]
        public async Task<IActionResult> CreateGame(CreateGameRequest gameRequest)
        {
            var createdGame = await _gameService.CreateGameAsync(gameRequest);
            if (createdGame != null)
            {
                return Ok(createdGame);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("GetAllGames")]
        public async Task<ActionResult<IEnumerable<Game>>> GetAllGames()
        {
            var games = await _gameService.GetAllGamesAsync();
            if (games == null)
            {
                return NotFound();
            }
            return Ok(games);
        }
    }
}
