using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DataAccess.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }
    public class Login
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }
}