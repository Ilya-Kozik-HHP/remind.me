using System;

namespace Remide.Me.DataAccess.Redis
{
    public static class KeyProvider
    {
        private const string UserCommonKeyFormat = "users:{0}:common";
        private const string UserLocationsKeyFormat = "users:{0}:locations";

        public static string GetUserCommonKey(params object[] items)
        {
            return String.Format(UserCommonKeyFormat, items);
        }

        public static string GetUserLocationsKey(params object[] items)
        {
            return String.Format(UserLocationsKeyFormat, items);
        }
    }
}