using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Remide.Me.Business.Entities;
using Remide.Me.DataAccess.Infrastructure;

using StackExchange.Redis;

namespace Remide.Me.DataAccess.Redis
{
    public class RedisLocationStorageProvider : ILocationStorageProvider
    {
        private const int DefaultDatabase = 0;
        private const string DefaultConnectionString = "localhost:6379";

        public async Task Save(string userGUID, List<Location> locations)
        {
            using (var redisConnection = ConnectionMultiplexer.Connect(DefaultConnectionString))
            {
                IDatabase database = redisConnection.GetDatabase(DefaultDatabase);

                string key = KeyProvider.GetUserLocationsKey(userGUID);

                await database.ListRightPushAsync(key, locations.Select(c=> (RedisValue)Jil.JSON.Serialize(c)).ToArray());
            }
        }

        public async Task<List<Location>> GetLocations(string userID)
        {
            using (var redisConnection = ConnectionMultiplexer.Connect(DefaultConnectionString))
            {
                IDatabase database = redisConnection.GetDatabase(DefaultDatabase);

                string key = KeyProvider.GetUserLocationsKey(userID);

                var items = await database.ListRangeAsync(key);

                return items.Select(c => Jil.JSON.Deserialize<Location>(c.ToString())).ToList();
            }
        }
    }
}