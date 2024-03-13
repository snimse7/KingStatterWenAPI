namespace KingStatterWenAPI.Interface
{
    public interface ICricInfo
    {
        Task<string> rankings(string formatType, string category);
        Task<string> searchPlayerByName(string name);
        Task<string> getImage(string imageId);
        Task<string> recentMatches();
        Task<string> getScoreCardById(int id);
        Task<string> getTrendingPlayers();
        Task<string> getPlayerInfoById(int id);
        Task<string> getBowlingInfoById(int playerId);
        Task<string> getBattingInfoById(int playerId);
    }
}
