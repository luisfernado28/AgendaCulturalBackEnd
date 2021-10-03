using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Events.Domain
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string VenueId { get; set; }
        public int Price { get; set; }
        public string Phone{ get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public List<string> Dates{ get; set; }
        public List<string> TagsId { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
    }
}
