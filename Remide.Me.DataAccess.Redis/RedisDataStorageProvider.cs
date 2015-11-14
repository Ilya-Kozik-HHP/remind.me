using System.Collections.Generic;

using Remide.Me.Business.Entities;
using Remide.Me.DataAccess.Infrastructure;
using Remide.Me.DataAccess.Redis.Configuration;

namespace Remide.Me.DataAccess.Redis
{
    public class RedisDataStorageProvider : IDataStorageProvider
    {
        private readonly RedisConfiguration redisConfiguration;

        public RedisDataStorageProvider(RedisConfiguration redisConfiguration)
        {
            this.redisConfiguration = redisConfiguration;
        }

        public List<Data> GetData(string userID)
        {
            throw new System.NotImplementedException();
        }

        public List<Data> GetDataByLocation(string userID, double latitude, double longitude)
        {
            throw new System.NotImplementedException();
        }
    }
}