﻿using System;

namespace Domain
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
