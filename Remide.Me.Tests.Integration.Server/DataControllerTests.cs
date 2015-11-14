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

        [Test]
        public void TestGetDataByLocation()
        {
            string userID = Guid.NewGuid().ToString();

            RedisLocationStorageProvider locationStorageProvider =
                new RedisLocationStorageProvider(new RedisConfiguration());

            var locations = new List<Location>
                            {
                                new Location
                                {
                                    ID = Guid.NewGuid().ToString(),
                                    Latitude = 53.9152587,
                                    Longitude = 27.47368,
                                    Radius = 500,
                                    Data = new List<Data>
                                           {
                                               new Data
                                               {
                                                   ID = Guid.NewGuid().ToString(),
                                                   Name = "EXISTS",
                                                   Text = "EXISTS TEXT"
                                               },
                                           }
                                },
                                new Location
                                {
                                    ID = Guid.NewGuid().ToString(),
                                    Latitude = 30.9152587,
                                    Longitude = 30.47368,
                                    Radius = 500,
                                    Data = new List<Data>
                                           {
                                               new Data
                                               {
                                                   ID = Guid.NewGuid().ToString(),
                                                   Name = "NOT EXISTS",
                                                   Text = "NOT EXISTS TEXT"
                                               }
                                           }
                                },
                            };

            locationStorageProvider.Save(userID, locations).Wait();

            var data = controller.GetDataByLocation(userID, 53.9147568, 27.4735622).Result;
        }
    }
}