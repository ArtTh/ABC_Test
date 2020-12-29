using System;

namespace Domain
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
