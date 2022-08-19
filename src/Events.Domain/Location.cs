/*
 * Project: Agenda Cultural Back End Net Core
 * Author: Luis Fernando Choque (luisfernandochoquea@gmail.com)
 * -----
 * Copyright 2021 - 2022 Universidad Privada Boliviana La Paz, Luis Fernando Choque Arana
 */
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
