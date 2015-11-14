using System.Collections.Generic;

using Remide.Me.Business.Entities;

namespace Remide.Me.Server.Insractructure.Requests
{
    public class GetNearestLocationsRequest
    {
        public List<Location> Locations { get; set; }
    }
}