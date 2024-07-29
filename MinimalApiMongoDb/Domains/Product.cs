using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MinimalApiMongoDb.Domains
{
    public class Product
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        public Dictionary<string, string> AdditionalAtributes { get; set; }

        public Product() 
        { 
            AdditionalAtributes = new Dictionary<string, string>();
        }    
    }
}
