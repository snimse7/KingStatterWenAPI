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
    public class MatchController : ControllerBase
    {
        private readonly IMatchLogic _match;
        public MatchController(IMatchLogic match)
        {
            _match = match;
        }

        [HttpPost]
        [Route("/NewMatch")]
        public async Task<IActionResult> newMatch(Match_ match)
        {
            try
            {
                return Ok(await _match.newMatch(match));
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetMatchDetails")]
        public async Task<IActionResult> matchDetails(string matchId)
        {
            try
            {
                return Ok(await _match.getMatch(matchId));
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("BattingList")]
        public async Task<IActionResult> battingList(string matchId,string inning)
        {
            try
            {
                return Ok(await _match.getBatsManList(matchId,inning));
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("BowlingList")]
        public async Task<IActionResult> bowlingList(string matchId, string inning)
        {
            try
            {
                return Ok(await _match.getBowlerList(matchId, inning));
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        [Route("getBatsmanById")]
        public async Task<IActionResult> getBatsmanById(string matchId, string inning, string playerId)
        {
            try
            {
                return Ok(await _match.getBatsMan(matchId, inning,playerId));
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        [Route("getBowlerById")]
        public async Task<IActionResult> getBowlerById(string matchId, string inning, string playerId)
        {
            try
            {
                return Ok(await _match.getBowler(matchId, inning, playerId));
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("UpdateBatsMan")]
        public async Task<IActionResult> updateBatsman(UpdateBatsManInput updateBatsManInput)
        {
            try
            {
                return Ok(await _match.updateBatsman(updateBatsManInput));
            }
            catch { throw; }
        }

        [HttpPost]
        [Route("UpdateBowler")]
        public async Task<IActionResult> updateBowler(UpdateBowlerInput updateBowlerInput)
        {
            try
            {
                return Ok(await _match.updateBowler(updateBowlerInput));
            }
            catch { throw; }
        }
    }
}
