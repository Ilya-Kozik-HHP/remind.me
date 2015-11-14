using System;
using System.Collections.Generic;

using Remide.Me.Common.Extentions;

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

        public bool Contains(double latitude, double longitude)
        {
            // TODO: implement precise
            if (Radius == 0)
            {
                return latitude == Latitude && longitude == Longitude;
            }

            return GetDistance(latitude, longitude) <= Radius;
        }

        public double GetDistance(double latitude, double longitude)
        {
            //const double earthRadius = 3958.75; // miles (or 6371.0 kilometers)
            const double earthRadius = 6371000;

            double dLat = (Latitude - latitude).ToRadians();
            double dLng = (Longitude - longitude).ToRadians();

            double sindLat = Math.Sin(dLat / 2);
            double sindLng = Math.Sin(dLng / 2);

            double a = Math.Pow(sindLat, 2) + Math.Pow(sindLng, 2) *
                Math.Cos(latitude.ToRadians()) * Math.Cos(Latitude.ToRadians());

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return earthRadius * c;
        }
    }
}