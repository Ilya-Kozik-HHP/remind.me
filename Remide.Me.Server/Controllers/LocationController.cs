using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

using Remide.Me.Business.Entities;
using Remide.Me.DataAccess.Infrastructure;
using Remide.Me.Server.Insractructure.Requests;

namespace Remide.Me.Server.Controllers
{
    public class LocationController : ApiController
    {
        private readonly ILocationStorageProvider locationStorageProvider;

        public LocationController(ILocationStorageProvider locationStorageProvider)
        {
            this.locationStorageProvider = locationStorageProvider;
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddLocations(AddLocationsRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetNearestLocations()
        {
            throw new NotImplementedException();
        }
    }
}