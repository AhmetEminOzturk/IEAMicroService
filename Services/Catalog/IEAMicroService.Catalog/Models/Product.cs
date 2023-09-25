using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IEAMicroService.Catalog.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
