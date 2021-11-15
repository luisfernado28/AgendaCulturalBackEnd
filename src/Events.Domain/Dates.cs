using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain
{
    public class Dates
    {
        public bool areindependent { get; set; }
        [BsonDateTimeOptions]

        public List<DateTime> dates { get; set; }
        public DateTime time{ get; set; }
    }
}
