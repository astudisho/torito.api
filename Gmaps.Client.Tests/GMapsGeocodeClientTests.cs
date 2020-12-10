using Gmaps.Client.Implementations;
using Gmaps.Client.Interfaces;
using Gmaps.Client.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Models.GMaps;
using Xunit;

namespace Gmaps.Client.Tests
{
    public class GMapsGeocodeClientTests : IClassFixture<GmapsClientFixture>
    {
        private readonly IGmapsGeocodeClient _gmapsGeoClient;
        private readonly Task<GeoCodeResponse> _geoCodeResponseTask;
        private readonly string _testAddress;
        
        public GMapsGeocodeClientTests(GmapsClientFixture fixture)
        {
            _gmapsGeoClient = fixture.gmapsGeocodeClient;
            _testAddress = fixture.testAddress;
            _geoCodeResponseTask = fixture.geoCodeResponseTask;
        }

        [Fact]
        public async Task GmapsClient_Should_Return_Ok_Status()
        {
            var result = await _geoCodeResponseTask;

            Assert.Equal("Ok", result.Status, ignoreCase: true);
        }

        [Fact]
        public async Task GmapsClient_Should_Return_Response()
        {
            var result = await _geoCodeResponseTask;

            Assert.NotNull(result);
            Assert.NotEmpty(result.Results);
        }

        [Fact]
        public async Task GmapsClient_Should_Contain_Location()
        {
            var result = await _geoCodeResponseTask;

            var geometry = result.Results.First().Geometry;
            Assert.NotNull(geometry);
            Assert.NotNull(geometry.Location);
            Assert.NotEqual(default, geometry.Location.Lat);
            Assert.NotEqual(default, geometry.Location.Lng);
        }

        [Fact]
        public async Task GmapsClient_Result_Should_Be_In_Region()
        {
            var result = await _geoCodeResponseTask;

            var addressComponents = result.Results.First().AddressComponents;
            Assert.Contains(addressComponents, x => x.LongName == "Jalisco");
            Assert.Contains(addressComponents, x => x.LongName == "Mexico");
        }
    }
}
