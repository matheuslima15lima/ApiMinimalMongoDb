
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

        //referencia aos produtos do pedido
        [BsonElement("productId")]
        public List<string>? ProductId { get; set;}
        public List<Product>? Products { get; set;}


        //referencia ao cliente que esta fazendo o pedido
        [BsonElement("clientId")]
        public string? ClientId { get; set; }   
        public Client? Clients { get; set; }
    }
}
