using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KingStatterWenAPI.Models
{
    public class User
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public User()
        {
            this._id = ObjectId.GenerateNewId();
        }
        public string userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public DateTime createdOn { get; set; }
    }
}
