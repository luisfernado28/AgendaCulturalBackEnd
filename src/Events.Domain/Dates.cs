/*
 * Project: Agenda Cultural Back End Net Core
 * Author: Luis Fernando Choque (luisfernandochoquea@gmail.com)
 * -----
 * Copyright 2021 - 2022 Universidad Privada Boliviana La Paz, Luis Fernando Choque Arana
 */
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

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
