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
        public int Name { get; set; }
        public int Role{ get; set; }
        public int Email{ get; set; }
        public int Password{ get; set; }
        public int Favorites { get; set; }
    }
}
