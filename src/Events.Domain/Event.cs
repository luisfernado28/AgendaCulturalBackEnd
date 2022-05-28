using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Events.Domain
{
    public class Event
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public eventStatus Status { get; set; }
        public int Price { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool AreIndependent { get; set; }
        [BsonDateTimeOptions]
        public List<DateTime> Dates { get; set; }
        public DateTime Time { get; set; }
        public List<string> Tags { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string VenueId { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string VenueWebsite { get; set; }
        public string VenueFacebook { get; set; }
        public string VenueTwitter { get; set; }
        public string VenueInstagram { get; set; }
        public string VenueDescription { get; set; }
        public string LocationType { get; set; }
        public double[] LocationCoordinates { get; set; }
    }
}
