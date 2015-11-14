using System.Collections.Generic;

namespace Remide.Me.Business.Entities
{
    public class Location
    {
        public string ID { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Radius { get; set; }

        public List<Data> Data { get; set; }

        public Location()
        {
            Data = new List<Data>();
        }
    }
}