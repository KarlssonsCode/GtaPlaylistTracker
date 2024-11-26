﻿using GtaPlaylistTracker.Data;
using GtaPlaylistTracker.Models;
using GtaPlaylistTracker.Contracts.Requests;
using Microsoft.EntityFrameworkCore;

namespace GtaPlaylistTracker.Services
{
    public class PlayerService
    {
        private readonly ApplicationDbContext _context;
        
        public PlayerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Player> CreatePlayerAsync(CreatePlayerRequest playerRequest)
        {
            Player newPlayer = new Player
            {
                Gamertag = playerRequest.Gamertag,
                Name = playerRequest.Name,
                ProfilePictureUrl = playerRequest.ProfilePictureUrl,
            };

            _context.Players.Add(newPlayer);
            await _context.SaveChangesAsync();
            return newPlayer;
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return await _context.Players.ToListAsync();
        }


    }
}