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
        [ActionName("update")]
        public async Task<IHttpActionResult> UpdateLocations(AddLocationsRequest request)
        {
            await locationStorageProvider.Save(request.UserID, request.Locations);

            return Ok();
        }

        [HttpGet]
        [ActionName("get")]
        public async Task<IHttpActionResult> GetLocations(string id)
        {
            List<Location> locations = await locationStorageProvider.GetLocations(id);

            return Ok(locations);
        }
    }
}