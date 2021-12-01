using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Events.Domain
{
    public class Location
    {
        public string type { get; set; }
        public double[] coordinates { get; set; }
    }

}
