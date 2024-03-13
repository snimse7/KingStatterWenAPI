using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace KingStatterWenAPI.Models
{
    public class Matches
    {
        public class Match_
        {
            [BsonId]
            public ObjectId _id { get; set; }
            public Match_()
            {
                this._id = ObjectId.GenerateNewId();
            }
            public string matchId { get; set; }
            public string team1 { get; set; }
            public string team2 { get; set; }
            public string ground { get; set; }
            public string toss { get; set; }
            public string chooseTo { get; set; }
            public DateTime date { get; set; }
            public int overs { get; set; }
            public Inning inning1 { get; set; }
            public Inning inning2 { get; set; }
        }

        public class Inning
        {
            public string teamname { get; set; }
            public int runs { get; set; }
            public int overs { get; set; }
            public int balls { get; set; }
            public double runRate { get; set; }
            public int wickets { get; set; }
            public Extras extras { get; set; }
            public List<Batting> battingInning { get; set; }
            public List<Bowling> bowlingInning { get; set; }

        }
        public class Batting
        {
            public string playerId { get; set; }
            public string name { get; set; }
            public int battingPosition { get; set; }
            public string status { get; set; }
            public int runs { get; set; }
            public int bowls { get; set; }
            public int fours { get; set; }
            public int six { get; set; }
            public double strike_rate { get; set; }
            public bool currentPlayer { get; set; }
            public bool onStrike { get; set; }
            public string? out_by { get; set; }
            public string? out_type { get; set; }
        }

        public class Bowling
        {
            public string playerId { get; set; }
            public string name { get; set; }
            public int overs { get; set; }
            public int balls { get; set; }
            public int maidenOvers { get; set; }
            public int runs { get; set; }
            public double economy { get; set; }
            public int wickets { get; set; }
            public bool currentBowler { get; set; }
        }
        public class Bowl
        {

            public string matchId { get; set; }
            public string inning { get; set; }
            public int runs { get; set; }
            public bool legalDelievery { get; set; }
            public Batting batsman { get; set; }
            public Bowling bowler { get; set; }
            public bool six { get; set; }
            public bool four { get; set; }
            public bool wide { get; set; }
            public bool noBall { get; set; }
            public bool byes { get; set; }
            public bool penalty { get; set; }

        }

        public class Wicket
        {
            public string matchId { get; set; }
            public string inning { get; set; }
            public string outPlayerId { get; set; }
            public string bowlerId { get; set; }
            public string outType { get; set; }
            public string outBy { get; set; }
            public int runsAddedInBall { get; set; }
            public bool isLegalDelievery { get; set; }
            public bool isNoBall { get; set; }
            public bool isWide { get; set; }
            public bool isByes { get; set; }
            public bool isLegByes { get; set; }
        }

        public class Extras
        {
            public int noBall { get; set; }
            public int legByes { get; set; }
            public int byes { get; set; }
            public int wides { get; set; }

        }
    }
}
