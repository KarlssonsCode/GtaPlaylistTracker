using GtaPlaylistTracker.Contracts.Requests;
using GtaPlaylistTracker.Data;
using GtaPlaylistTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GtaPlaylistTracker.Services
{
    public class GameService
    {
        private readonly ApplicationDbContext _context;

        public GameService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<Game> CreateGameAsync(CreateGameRequest gameRequest)
        {
            Game newGame = new Game
            {
                Name = gameRequest.Name,
            };

            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();
            return newGame;
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }
    }
}
