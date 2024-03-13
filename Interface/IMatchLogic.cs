using KingStatterWenAPI.Models;
using static KingStatterWenAPI.Models.Inputs;
using static KingStatterWenAPI.Models.Matches;
using static KingStatterWenAPI.Models.Responses;

namespace KingStatterWenAPI.Interface
{
    public interface IMatchLogic
    {
        Task<InsertDocumentResponse> newMatch(Match_ match);
        Task<Match_> getMatch(string matchId);
        Task<List<Bowling>> getBowlerList(string matchId, string inning);
        Task<List<Batting>> getBatsManList(string matchId, string inning);
        Task<Batting> getBatsMan(string matchId, string inning, string playerId);
        Task<Bowling> getBowler(string matchId, string inning, string playerId);
        Task<bool> updateBatsman(UpdateBatsManInput updateBatsManInput);
        Task<bool> updateBowler(UpdateBowlerInput updateBowlerInput);
    }
}
