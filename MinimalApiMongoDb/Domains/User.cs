using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MinimalApiMongoDb.Domains
{
    public class User
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")] 
        public string Name { get; set;}

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        public Dictionary<string, string> AdditionalAtributes { get; set; }
        public User() {
            AdditionalAtributes = new Dictionary<string, string>();
        }   
    }
}
