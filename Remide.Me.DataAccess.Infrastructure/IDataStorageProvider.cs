using System.Collections.Generic;
using System.Threading.Tasks;

using Remide.Me.Business.Entities;

namespace Remide.Me.DataAccess.Infrastructure
{
    public interface IDataStorageProvider
    {
        Task<List<Data>> GetData(string userID);
        Task<List<Data>> GetDataByLocation(string userID, double latitude, double longitude);
    }
}