namespace Remide.Me.DataAccess.Redis.Configuration
{
    public class RedisConfiguration
    {
        private const int DefaultDatabase = 0;
        private const string DefaultConnectionString = "localhost:6379";

        public int Database
        {
            get { return DefaultDatabase; }
        }

        public string ConnectionString
        {
            get { return DefaultConnectionString; }
        }
    }
}