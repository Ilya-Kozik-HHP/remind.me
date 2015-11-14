using System;
using System.Collections.Generic;
using System.Globalization;
using Remide.Me.Business.Entities;
using Remide.Me.DataAccess.Redis;
using Remide.Me.DataAccess.Redis.Configuration;
using Remide.Me.Server.Controllers;

using NUnit.Framework;

namespace Remide.Me.Tests.Integration.Server
{
    [TestFixture]
    public class DataControllerTests
    {
        private DataController controller;

        [SetUp]
        public void Initialize()
        {
            RedisDataStorageProvider storageProvider = new RedisDataStorageProvider(new RedisConfiguration());

            controller = new DataController(storageProvider);
        }

        [Test]
        public void TestGetAllData()
        {
            string userID = 20.ToString(CultureInfo.InvariantCulture);

            var allData = controller.GetData(userID).Result;
        }
    }
}