using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
namespace Models 
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }
    }
}
