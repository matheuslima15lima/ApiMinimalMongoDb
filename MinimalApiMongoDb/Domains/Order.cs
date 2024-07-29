
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MinimalApiMongoDb.Domains
{
    public class Order
    {
        [BsonId]
        [BsonElement("_id"),BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; }

        [BsonElement("Product")] 
        public Product Product { get; set;}

        [BsonElement("Client")]
        public Client Client { get; set; }
    }
}
