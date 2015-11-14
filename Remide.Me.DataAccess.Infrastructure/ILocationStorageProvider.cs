using System.Collections.Generic;
using System.Threading.Tasks;

using Remide.Me.Business.Entities;

namespace Remide.Me.DataAccess.Infrastructure
{
    public interface ILocationStorageProvider
    {
        Task Save(string userID, List<Location> locations);
        Task<List<Location>> GetLocations(string userID);
    }
}