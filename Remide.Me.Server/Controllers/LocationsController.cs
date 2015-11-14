﻿using System.Threading.Tasks;
using System.Web.Http;

using Remide.Me.DataAccess.Infrastructure;
using Remide.Me.Server.Insractructure.Requests;

namespace Remide.Me.Server.Controllers
{
    public class LocationsController : ApiController
    {
        private readonly ILocationStorageProvider locationStorageProvider;

        public LocationsController(ILocationStorageProvider locationStorageProvider)
        {
            this.locationStorageProvider = locationStorageProvider;
        }

        [HttpPost]
        [ActionName("update")]
        public async Task<IHttpActionResult> UpdateLocations(AddLocationsRequest request)
        {
            await locationStorageProvider.Save(request.UserID, request.Locations);

            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetLocations(GetLocationsRequest request)
        {
            await locationStorageProvider.GetLocations(request.UserID);

            return Ok();
        }
    }
}