using System.Collections.Generic;

using Remide.Me.Business.Entities;
using Remide.Me.DataAccess.Infrastructure;

namespace Remide.Me.DataAccess.Redis
{
    public class RedisLocationStorageProvider : ILocationStorageProvider
    {
        public void Save(int userID, List<Location> locations)
        {
            throw new System.NotImplementedException();
        }
    }
}