using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Remide.Me.Business.Entities;
using Remide.Me.DataAccess.Infrastructure;
using Remide.Me.DataAccess.Redis.Configuration;

using StackExchange.Redis;

namespace Remide.Me.DataAccess.Redis
{
    public class RedisDataStorageProvider : IDataStorageProvider
    {
        private readonly RedisConfiguration redisConfiguration;

        public RedisDataStorageProvider(RedisConfiguration redisConfiguration)
        {
            this.redisConfiguration = redisConfiguration;
        }

        public async Task<List<Data>> GetData(string userID)
        {
            List<Data> result = new List<Data>();

            using (var redisConnection = ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString))
            {
                IDatabase database = redisConnection.GetDatabase(redisConfiguration.Database);

                string key = KeyProvider.GetUserLocationsKey(userID);

                var items = await database.ListRangeAsync(key);

                var allData = items.Select(c => Jil.JSON.Deserialize<Location>(c.ToString())).SelectMany(c => c.Data).ToList();

                allData.ForEach(c =>
                                {
                                    var item = result.FirstOrDefault(f => f.ID == c.ID);
                                    if (item == null)
                                    {
                                        result.Add(c);
                                    }
                                });
            }

            return result;
        }

        public async Task<List<Data>> GetDataByLocation(string userID, double latitude, double longitude)
        {
            List<Data> result = new List<Data>();

            using (var redisConnection = ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString))
            {
                IDatabase database = redisConnection.GetDatabase(redisConfiguration.Database);

                string key = KeyProvider.GetUserLocationsKey(userID);

                var items = await database.ListRangeAsync(key);

                var allData = items.Select(c => Jil.JSON.Deserialize<Location>(c.ToString())).
                    Where(c => c.Contains(latitude, longitude)).SelectMany(c => c.Data).ToList();

                allData.ForEach(c =>
                                {
                                    var item = result.FirstOrDefault(f => f.ID == c.ID);
                                    if (item == null)
                                    {
                                        result.Add(c);
                                    }
                                });

            }

            return result;
        }
    }
}