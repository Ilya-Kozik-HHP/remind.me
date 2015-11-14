using System.Collections.Generic;

using Remide.Me.Business.Entities;

namespace Remide.Me.DataAccess.Infrastructure
{
    public interface IDataStorageProvider
    {
        List<Data> GetData(string userID);
        List<Data> GetDataByLocation(string userID, double latitude, double longitude);
    }
}