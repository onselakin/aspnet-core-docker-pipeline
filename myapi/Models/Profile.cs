using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
 
namespace myapi.Models
{
    public class Profile
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("ProfileImageUrl")]
        public string ProfileImageUrl { get; set; }
    }
}