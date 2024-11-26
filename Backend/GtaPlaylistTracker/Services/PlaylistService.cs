using GtaPlaylistTracker.Contracts.Requests;
using GtaPlaylistTracker.Data;
using GtaPlaylistTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GtaPlaylistTracker.Services
{
    public class PlaylistService
    {
        private readonly ApplicationDbContext _context;

        public PlaylistService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Playlist> CreatePlaylistAsync(CreatePlaylistRequest playlistRequest)
        {
            Playlist newPlaylist = new Playlist
            {
                Name = playlistRequest.Name,
                GameId = playlistRequest.GameId,
                Races = playlistRequest.Races,
            };

            _context.Playlists.Add(newPlaylist);
            await _context.SaveChangesAsync();
            return newPlaylist;
        }
        public async Task<IEnumerable<Playlist>> GetAllPlaylistsAsync()
        {
            return await _context.Playlists.ToListAsync();
        }
    }
}
