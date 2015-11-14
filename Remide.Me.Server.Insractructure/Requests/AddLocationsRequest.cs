using System.Collections.Generic;

using Remide.Me.Business.Entities;

namespace Remide.Me.Server.Insractructure.Requests
{
    public class AddLocationsRequest
    {
        public List<Location> Locations { get; set; }
    }
}