using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Remide.Me.Business.Entities;
using Remide.Me.DataAccess.Infrastructure;
using Remide.Me.DataAccess.Redis.Configuration;
using StackExchange.Redis;

namespace Remide.Me.DataAccess.Redis
{
    public class RedisLocationStorageProvider : ILocationStorageProvider
    {
        private readonly RedisConfiguration redisConfiguration;

        public RedisLocationStorageProvider(RedisConfiguration redisConfiguration)
        {
            this.redisConfiguration = redisConfiguration;
        }

        public async Task Save(string userGUID, List<Location> locations)
        {
            using (var redisConnection = ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString))
            {
                IDatabase database = redisConnection.GetDatabase(redisConfiguration.Database);

                string key = KeyProvider.GetUserLocationsKey(userGUID);

                await database.ListRightPushAsync(key, locations.Select(c=> (RedisValue)Jil.JSON.Serialize(c)).ToArray());
            }
        }

        public async Task<List<Location>> GetLocations(string userID)
        {
            using (var redisConnection = ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString))
            {
                IDatabase database = redisConnection.GetDatabase(redisConfiguration.Database);

                string key = KeyProvider.GetUserLocationsKey(userID);

                var items = await database.ListRangeAsync(key);

                return items.Select(c => Jil.JSON.Deserialize<Location>(c.ToString())).ToList();
            }
        }
    }
}