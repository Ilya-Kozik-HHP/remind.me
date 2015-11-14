using System;
using System.Threading.Tasks;

using Remide.Me.Business.Entities;
using Remide.Me.DataAccess.Infrastructure;
using Remide.Me.DataAccess.Redis.Configuration;

using StackExchange.Redis;

namespace Remide.Me.DataAccess.Redis
{
    public class AccountStorageProvider : IAccountStorageProvider
    {
        private readonly RedisConfiguration redisConfiguration;

        public AccountStorageProvider(RedisConfiguration redisConfiguration)
        {
            this.redisConfiguration = redisConfiguration;
        }

        public async Task Save(AccountInfo accountInfo)
        {
            if (accountInfo != null)
            {
                using (var redisConnection = ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString))
                {
                    IDatabase database = redisConnection.GetDatabase(redisConfiguration.Database);

                    string fieldKey = String.Format("{0}:{1}", accountInfo.Name, accountInfo.Password);

                    bool exists = await database.HashExistsAsync(KeyProvider.UserLoginKey, fieldKey);

                    if (!exists)
                    {
                        string accountString = Jil.JSON.Serialize(accountInfo);

                        await database.HashSetAsync(KeyProvider.UserLoginKey, fieldKey, accountString);
                    }
                }
            }
        }

        public async Task<AccountInfo> GetByCredentials(string name, string password)
        {
            AccountInfo accountInfo = null;

            using (var redisConnection = ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString))
            {
                IDatabase database = redisConnection.GetDatabase(redisConfiguration.Database);

                string fieldKey = String.Format("{0}:{1}", name, password);

                bool exists = await database.HashExistsAsync(KeyProvider.UserLoginKey, fieldKey);

                if (exists)
                {
                    string accountString = database.HashGet(KeyProvider.UserLoginKey, fieldKey);
                    accountInfo = Jil.JSON.Deserialize<AccountInfo>(accountString);
                }
            }

            return accountInfo;
        }
    }
}