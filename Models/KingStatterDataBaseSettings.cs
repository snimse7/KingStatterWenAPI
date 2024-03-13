namespace KingStatterWenAPI.Models
{
    public class KingStatterDataBaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string UserCollectionName { get; set; } = null!;
        public string MatchCollectionName { get; set; } = null!;



    }
}
