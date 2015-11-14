using System;
using System.Collections.Generic;

using Remide.Me.Business.Entities;
using Remide.Me.DataAccess.Redis;
using Remide.Me.DataAccess.Redis.Configuration;
using Remide.Me.Server.Controllers;
using Remide.Me.Server.Insractructure.Requests;

using NUnit.Framework;

namespace Remide.Me.Tests.Integration.Server
{
    [TestFixture]
    public class LocationsControllerTests
    {
        private LocationController controller;

        [SetUp]
        public void Initialize()
        {
            controller = new LocationController(new RedisLocationStorageProvider(new RedisConfiguration()));
        }

        [Test]
        public void TestUpdateLocations()
        {
            var request = new AddLocationsRequest
                          {
                              UserID = 20.ToString(),
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
                                                  Radius = 123123
                                              }
                                          }
                          };


            var resutl = controller.UpdateLocations(request).Result;
        }
    }
}