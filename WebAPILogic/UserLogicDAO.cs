using Amazon.Runtime.Internal;
using KingStatterWenAPI.Interface;
using KingStatterWenAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;
using static KingStatterWenAPI.Models.Responses;

namespace KingStatterWenAPI.WebAPILogic
{
    public class UserLogicDAO: IUserLogic
    {
        
        private readonly IMongoCollection<User> _usersCollection;

        public UserLogicDAO(IConfiguration configuration, IOptions<KingStatterDataBaseSettings> database)
        {
            var mongoClient = new MongoClient(database.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(database.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<User>(database.Value.UserCollectionName);
        }

        public static string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the password string to byte array
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Compute the hash
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

                // Convert the hashed bytes to a hexadecimal string
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }


        public async Task<InsertDocumentResponse> newUser(User user)
        {
            InsertDocumentResponse signUpResponse = new InsertDocumentResponse();
            try
            {
                user.createdOn=DateTime.Now;
                user.userId = Guid.NewGuid().ToString();
                user.password=EncryptPassword(user.password);
                await _usersCollection.InsertOneAsync(user);
                signUpResponse.success = true;
                signUpResponse.message = "Account Successfully Created ! You can login now";


            }
            catch 
            {
                signUpResponse.success=false;
                signUpResponse.message = "Something Went Wrong Please try Again";
            }
            return signUpResponse;
        }

        public async Task<User> GetUser(string userName)
        {
            try
            {
                var data=await _usersCollection.Find(x=> x.userName == userName).FirstOrDefaultAsync();
                return data;
            }
            catch { throw; }
        }

        public async Task<bool> checkUserPresent(string userName)
        {
            bool result = false;
            try
            {
                var data = await _usersCollection.Find(x => x.userName == userName).FirstOrDefaultAsync();
                if(data != null)
                {
                    result = true;
                }
            }
            catch { return result; }
            return result;
        }

        public async Task<SignInResponse> signInUser(string userName, string password)
        {
            try
            {
                SignInResponse signInResponse = new SignInResponse();
                if (await checkUserPresent(userName))
                {
                    var user = await GetUser(userName);
                    string passWord = EncryptPassword(password);
                    if (passWord == user.password)
                    {
                        signInResponse.isValidCredentidals = true;
                        signInResponse.user=user;
                        signInResponse.message = "Successfully LoggedIn";
                    }
                    else
                    {
                        signInResponse.isValidCredentidals = false;
                        signInResponse.message = "Please Enter Correct PassWord";

                    }
                }
                else
                {
                    signInResponse.isValidCredentidals = false;
                    signInResponse.message = "Please enter correct UserName";
                }

                return signInResponse;
            }
            catch { throw; }
            
        }

        public async void gey()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://livescore6.p.rapidapi.com/teams/get-table?ID=3339&Type=short"),
                Headers =
                {
                    { "X-RapidAPI-Key", "e69228c046msh1e9a12e60e90479p13c261jsna8b03e24a612" },
                    { "X-RapidAPI-Host", "livescore6.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }

        
    }
}
