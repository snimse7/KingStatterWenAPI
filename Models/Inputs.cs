using static KingStatterWenAPI.Models.Matches;

namespace KingStatterWenAPI.Models
{
    public class Inputs
    {
        public class UpdateBatsManInput
        {
            public string matchId { get; set; }
            public string inning { get; set; }
            public Batting batsman { get; set; }


        }

        public class UpdateBowlerInput
        {
            public string matchId { get; set; }
            public string inning { get; set; }
            public Bowling bowler { get; set; }


        }
    }
}
