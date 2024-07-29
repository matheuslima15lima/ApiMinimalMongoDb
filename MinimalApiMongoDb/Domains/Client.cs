using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MinimalApiMongoDb.Domains
{
    public class Client
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }


        [BsonElement("UserId"), BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }  

        [BsonElement("Name")] 
        public string? Name { get; set;}

        [BsonElement("Cpf")] 
        public int Cpf { get; set;}

        [BsonElement("Phone")]
        public int Phone { get; set; }

        [BsonElement("Address")]
        public string? Address { get; set; }

        public Dictionary<string, string> AdditionalAtributes { get; set; }

        public Client()
        {
            AdditionalAtributes = new Dictionary<string, string>();
        }
    }
}
