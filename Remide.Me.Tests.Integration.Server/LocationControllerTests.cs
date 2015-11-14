using System;
using System.Collections.Generic;
using System.Globalization;
using Remide.Me.Business.Entities;
using Remide.Me.DataAccess.Redis;
using Remide.Me.DataAccess.Redis.Configuration;
using Remide.Me.Server.Controllers;
using Remide.Me.Server.Insractructure.Requests;

using NUnit.Framework;

namespace Remide.Me.Tests.Integration.Server
{
    [TestFixture]
    public class LocationControllerTests
    {
        private LocationController controller;

        [SetUp]
        public void Initialize()
        {
            RedisLocationStorageProvider storageProvider = new RedisLocationStorageProvider(new RedisConfiguration());

            controller = new LocationController(storageProvider);
        }

        [Test]
        public void TestUpdateLocations()
        {
            string userID = 20.ToString(CultureInfo.InvariantCulture);

            var request = new AddLocationsRequest
                          {
                              UserID = userID,
                              Locations = new List<Location>
                                          {
                                              new Location
                                              {
                                                  ID = Guid.NewGuid().ToString(),
                                                  Latitude = 123.123123,
                                                  Longitude = 345.345345,
                                                  Radius = 123123,
                                                  Data = new List<Data>
                                                         {
                                                             new Data
                                                             {
                                                                 ID = Guid.NewGuid().ToString(),
                                                                 Name = Guid.NewGuid().ToString(),
                                                                 Text = Guid.NewGuid().ToString(),
                                                             },
                                                             new Data
                                                             {
                                                                 ID = Guid.NewGuid().ToString(),
                                                                 Name = Guid.NewGuid().ToString(),
                                                                 Text = Guid.NewGuid().ToString(),
                                                             },
                                                             new Data
                                                             {
                                                                 ID = Guid.NewGuid().ToString(),
                                                                 Name = Guid.NewGuid().ToString(),
                                                                 Text = Guid.NewGuid().ToString(),
                                                             }
                                                         }
                                              },
                                              new Location
                                              {
                                                  ID = Guid.NewGuid().ToString(),
                                                  Latitude = 123.123123,
                                                  Longitude = 345.345345,
                                                  Radius = 123123,
                                                  Data = new List<Data>
                                                         {
                                                             new Data
                                                             {
                                                                 ID = Guid.NewGuid().ToString(),
                                                                 Name = Guid.NewGuid().ToString(),
                                                                 Text = Guid.NewGuid().ToString(),
                                                             },
                                                         }
                                              },
                                              new Location
                                              {
                                                  ID = Guid.NewGuid().ToString(),
                                                  Latitude = 123.123123,
                                                  Longitude = 345.345345,
                                                  Radius = 123123,
                                              },
                                          }
                          };

            controller.UpdateLocations(request).Wait();

            var locations = controller.GetLocations(userID).Result;
        }
    }
}