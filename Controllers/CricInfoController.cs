using KingStatterWenAPI.Interface;
using KingStatterWenAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;
using static KingStatterWenAPI.Models.Inputs;
using static KingStatterWenAPI.Models.Matches;

namespace Statter_web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CricInfoController : ControllerBase
    {
        private readonly ICricInfo _cricInfo;
        public CricInfoController(ICricInfo cricInfo)
        {
            _cricInfo = cricInfo;
        }

        [HttpGet]
        [Route("Ranking")]
        public async Task<string> ranking(string formatType, string category)
        {
            try
            {
                return await _cricInfo.rankings(formatType, category);

            }
            catch { throw; }
        }

        [HttpGet]
        [Route("searchPlayerByName")]
        public async Task<string> searchPlayerByName(string name)
        {
            try
            {
                return await _cricInfo.searchPlayerByName(name);

            }
            catch { throw; }
        }

        [HttpGet]
        [Route("getImage")]
        public async Task<string> imageById(string id)
        {
            try
            {
                return await _cricInfo.getImage(id);

            }
            catch { throw; }
        }

        [HttpGet]
        [Route("getRecentMatches")]
        public async Task<string> getRecentMatches()
        {
            try
            {
                return await _cricInfo.recentMatches();

            }
            catch { throw; }
        }

        [HttpGet]
        [Route("getScoreCardById")]
        public async Task<string> getScoreCardById(int matchId)
        {
            try
            {
                return await _cricInfo.getScoreCardById(matchId);

            }
            catch { throw; }
        }

        [HttpGet]
        [Route("getTrendingPlayers")]
        public async Task<string> getTrendingPlayers()
        {
            try
            {
                return await _cricInfo.getTrendingPlayers();

            }
            catch { throw; }
        }

        [HttpGet]
        [Route("getPlayerInfoById")]
        public async Task<string> getPlayerInfoById(int playerId)
        {
            try
            {
                return await _cricInfo.getPlayerInfoById(playerId);

            }
            catch { throw; }
        }

        [HttpGet]
        [Route("getBowlingInfoById")]
        public async Task<string> getBowlingInfoById(int playerId)
        {
            try
            {
                return await _cricInfo.getPlayerInfoById(playerId);

            }
            catch { throw; }
        }

        [HttpGet]
        [Route("getBattingInfoById")]
        public async Task<string> getBattingInfoById(int playerId)
        {
            try
            {
                return await _cricInfo.getBattingInfoById(playerId);

            }
            catch { throw; }
        }
    }
}
