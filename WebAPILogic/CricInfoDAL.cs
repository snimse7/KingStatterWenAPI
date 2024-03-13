using KingStatterWenAPI.Interface;
using KingStatterWenAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace KingStatterWenAPI.WebAPILogic
{
    public class CricInfoDAL:ICricInfo  
    {
        
        private readonly CricBuzzAPIConstants _cricBuzzAPIConstants=new CricBuzzAPIConstants();
        private readonly string baseURL="https://cricbuzz-cricket.p.rapidapi.com/";
        public async Task<string> rankings(string formatType,string category)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseURL + $"stats/v1/rankings/{category}?formatType={formatType}"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", _cricBuzzAPIConstants.rapidAPIKeY},
                        { "X-RapidAPI-Host", _cricBuzzAPIConstants.requestURI },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return body;
                }
            }
            catch { throw; }
        }

        public async Task<string> searchPlayerByName(string name)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseURL + $"stats/v1/player/search?plrN={name}"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", _cricBuzzAPIConstants.rapidAPIKeY},
                        { "X-RapidAPI-Host", _cricBuzzAPIConstants.requestURI },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch { throw; }
        }

        public async Task<string> getImage(string imageId)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseURL + $"img/v1/i1/{imageId}/i.jpg"),
                    Headers =
                {
                    { "X-RapidAPI-Key", _cricBuzzAPIConstants.rapidAPIKeY},
                    { "X-RapidAPI-Host", _cricBuzzAPIConstants.requestURI },
                },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var a = await response.Content.ReadAsStringAsync();
                    return a;
                }
            }
            catch { throw; }
            
        }

        public async Task<string> recentMatches()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseURL + "matches/v1/recent"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", _cricBuzzAPIConstants.rapidAPIKeY},
                        { "X-RapidAPI-Host", _cricBuzzAPIConstants.requestURI },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return body;
                }
            }
            catch { throw; }
        }

        public async Task<string> getScoreCardById(int id)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseURL + $"mcenter/v1/{id}/scard"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", _cricBuzzAPIConstants.rapidAPIKeY},
                        { "X-RapidAPI-Host", _cricBuzzAPIConstants.requestURI },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return body;
                }
            }
            catch { throw; }
        }

        public async Task<string> getTrendingPlayers()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseURL + "stats/v1/player/trending"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", _cricBuzzAPIConstants.rapidAPIKeY},
                        { "X-RapidAPI-Host", _cricBuzzAPIConstants.requestURI },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return body;
                }
            }
            catch { throw; }
        }
        public async Task<string> getPlayerInfoById(int id)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseURL + $"stats/v1/player/{id}"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", _cricBuzzAPIConstants.rapidAPIKeY},
                        { "X-RapidAPI-Host", _cricBuzzAPIConstants.requestURI },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return body;
                }
            }
            catch { throw; }
        }

        public async Task<string> getBowlingInfoById(int playerId)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseURL + $"stats/v1/player/{playerId}/bowling"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", _cricBuzzAPIConstants.rapidAPIKeY},
                        { "X-RapidAPI-Host", _cricBuzzAPIConstants.requestURI },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return body;
                }
            }
            catch { throw; }
            
        }

        public async Task<string> getBattingInfoById(int playerId)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseURL + $"stats/v1/player/{playerId}/batting"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", _cricBuzzAPIConstants.rapidAPIKeY},
                        { "X-RapidAPI-Host", _cricBuzzAPIConstants.requestURI },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return body;
                }
            }
            catch { throw; }
            
        }

    }
}
