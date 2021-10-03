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
        public string Name { get; set; }
        public int Role{ get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
        public string[] Favorites { get; set; }
    }
}
