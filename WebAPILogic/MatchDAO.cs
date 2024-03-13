using Amazon.Runtime.Internal;
using KingStatterWenAPI.Interface;
using KingStatterWenAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static KingStatterWenAPI.Models.Inputs;
using static KingStatterWenAPI.Models.Matches;
using static KingStatterWenAPI.Models.Responses;

namespace KingStatterWenAPI.WebAPILogic
{
    public class MatchDAO : IMatchLogic
    {

        private readonly IMongoCollection<Match_> _usersCollection;

        public MatchDAO(IConfiguration configuration, IOptions<KingStatterDataBaseSettings> database)
        {
            var mongoClient = new MongoClient(database.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(database.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<Match_>(database.Value.MatchCollectionName);
        }

        public async Task<InsertDocumentResponse> newMatch(Match_ match)
        {
            InsertDocumentResponse insertDocumentResponse = new InsertDocumentResponse();
            try
            {
                match.matchId = Guid.NewGuid().ToString();
                match.date = DateTime.Now;
                for (int i = 0; i < match.inning1.bowlingInning.Count; i++)
                {
                    match.inning1.battingInning[i].playerId = Guid.NewGuid().ToString();
                    match.inning2.battingInning[i].playerId = Guid.NewGuid().ToString();

                    match.inning1.bowlingInning[i].playerId = match.inning2.battingInning[i].playerId;
                    match.inning2.bowlingInning[i].playerId = match.inning1.battingInning[i].playerId;

                }

                await _usersCollection.InsertOneAsync(match);

                insertDocumentResponse.success = true;
                insertDocumentResponse.id = match.matchId;
                insertDocumentResponse.message = "Match has been Successfully Created";
            }
            catch
            {
                insertDocumentResponse.success = false;
                insertDocumentResponse.message = "Something Went Wrong Please Try Again";
            }
            return insertDocumentResponse;
        }

        public async Task<Match_> getMatch(string matchId)
        {
            try
            {
                var match = await _usersCollection.Find(x => (x.matchId == matchId)).FirstOrDefaultAsync();
                return match;
            }
            catch { throw; }
        }

        public async Task<List<Batting>> getBatsManList(string matchId,string inning)
        {
            try
            {
                var match = await getMatch(matchId);
                if (inning == "inning1")
                {
                    return match.inning1.battingInning;
                }
                else
                {
                    return match.inning2.battingInning;
                }
            }
            catch { throw; }
        }

        public async Task<List<Bowling>> getBowlerList(string matchId, string inning)
        {
            try
            {
                var match = await getMatch(matchId);
                if (inning == "inning1")
                {
                    return match.inning1.bowlingInning;
                }
                else
                {
                    return match.inning2.bowlingInning;
                }
            }
            catch { throw; }
        }

        public async Task<Batting> getBatsMan(string matchId, string inning,string playerId)
        {
            try
            {
                var match=await getMatch(matchId);
                var batsManList = inning == "inning1" ? match.inning1.battingInning : match.inning2.battingInning;
                
                    
                for(int i = 0; i < batsManList.Count; i++)
                {
                    if (batsManList[i].playerId == playerId)
                    {
                        return batsManList[i];
                    }
                }
               
                return new Batting();
            }
            catch { throw; }
        }

        public async Task<Bowling> getBowler(string matchId, string inning, string playerId)
        {
            try
            {
                var match = await getMatch(matchId);
                var bowlerList = inning == "inning1" ? match.inning1.bowlingInning : match.inning2.bowlingInning;


                for (int i = 0; i < bowlerList.Count; i++)
                {
                    if (bowlerList[i].playerId == playerId)
                    {
                        return bowlerList[i];
                    }
                }

                return new Bowling();
            }
            catch { throw; }
        }

        public async Task<bool> updateBatsman(UpdateBatsManInput updateBatsManInput)
        {
            try
            {
                var match = await getMatch(updateBatsManInput.matchId);
                var batsManList = updateBatsManInput.inning == "inning1" ? match.inning1.battingInning : match.inning2.battingInning;
                Batting batsman=new Batting();
                for(int i = 0; i < batsManList.Count; i++)
                {
                    if (batsManList[i].playerId== updateBatsManInput.batsman.playerId)
                    {
                         batsManList[i]=updateBatsManInput.batsman;
                        break;
                    }
                }

                var update = await _usersCollection.ReplaceOneAsync(x => x.matchId == updateBatsManInput.matchId,match);
                if (update.ModifiedCount > 0)
                {
                    return true;
                }
                return false;

            }
            catch { throw; }
        }
        public async Task<bool> updateBowler(UpdateBowlerInput updateBowlerInput)
        {
            try
            {
                var match = await getMatch(updateBowlerInput.matchId);
                var bowlerList = updateBowlerInput.inning == "inning1" ? match.inning1.bowlingInning : match.inning2.bowlingInning;
                Bowling batsman = new Bowling();
                for (int i = 0; i < bowlerList.Count; i++)
                {
                    if (bowlerList[i].playerId == updateBowlerInput.bowler.playerId)
                    {
                        bowlerList[i] = updateBowlerInput.bowler;
                        break;
                    }
                }

                var update = await _usersCollection.ReplaceOneAsync(x => x.matchId == updateBowlerInput.matchId, match);
                if (update.ModifiedCount > 0)
                {
                    return true;
                }
                return false;

            }
            catch { throw; }
        }
    }
}
