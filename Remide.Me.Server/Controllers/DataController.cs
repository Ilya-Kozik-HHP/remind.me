using System.Threading.Tasks;
using System.Web.Http;

using Remide.Me.DataAccess.Infrastructure;

namespace Remide.Me.Server.Controllers
{
    public class DataController : ApiController
    {
        private readonly IDataStorageProvider dataStorageProvider;

        public DataController(IDataStorageProvider dataStorageProvider)
        {
            this.dataStorageProvider = dataStorageProvider;
        }

        [HttpGet]
        [ActionName("get")]
        public async Task<IHttpActionResult> GetData(string id)
        {
            var allData = await dataStorageProvider.GetData(id);

            return Ok(allData);
        }

        [HttpGet]
        [ActionName("getbylocation")]
        public async Task<IHttpActionResult> GetDataByLocation(string id, double latitude, double longitude)
        {
            var allData = await dataStorageProvider.GetDataByLocation(id, latitude, longitude);

            return Ok(allData);
        }
    }
}