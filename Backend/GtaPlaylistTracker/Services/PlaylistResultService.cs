using GtaPlaylistTracker.Contracts.Requests;
using GtaPlaylistTracker.Data;
using GtaPlaylistTracker.Models;

namespace GtaPlaylistTracker.Services
{
    public class PlaylistResultService
    {
        private readonly ApplicationDbContext _context;

        public PlaylistResultService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PlaylistResult> CreatePlaylistResultAsync(CreatePlaylistResultRequest playlistResultRequest)
        {
            PlaylistResult newPlaylistResult = new PlaylistResult
            {
                PlayerId = playlistResultRequest.PlayerId,
                PlaylistId = playlistResultRequest.PlaylistId,
                FinishPosition = playlistResultRequest.FinishPosition,
                Points = playlistResultRequest.Points,
                RageQuit = playlistResultRequest.RageQuit,
            };

            _context.PlaylistsResult.Add(newPlaylistResult);
            await _context.SaveChangesAsync();
            return newPlaylistResult;
        }
    }
}
