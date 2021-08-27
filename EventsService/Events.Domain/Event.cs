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
        public int Price { get; set; }
        public string Phone{ get; set; }
        public string[] Images { get; set; }
        public string[] Dates{ get; set; }
        public int Type{ get; set; }
        public List<(string,string)> SocialMedia{ get; set; }
        public string[] VenueID { get; set; }
        public string[] TagID { get; set; }
    }
}
