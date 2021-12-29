using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Events.Domain
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
}
