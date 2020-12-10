using Gmaps.Client.Implementations;
using Gmaps.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Models.GMaps;
using Torito.Models.Utils.Tools;

namespace Gmaps.Client.Tests.Fixtures
{

    public class GmapsClientFixture
    {
        internal readonly UserSecretManager secretManager;
        internal readonly string gmapsApiKey;
        internal readonly string testAddress;
        internal readonly IGmapsGeocodeClient gmapsGeocodeClient;
        internal readonly Task<GeoCodeResponse> geoCodeResponseTask; 
        public GmapsClientFixture()
        {
            secretManager = new UserSecretManager();
            gmapsApiKey = secretManager.GetGmapsGeocodeApiKey();
            gmapsGeocodeClient = new GmapsGeocodeClient(gmapsApiKey);
            testAddress = "Av.Vallarta y Niño Obrero, por la cámara de comercio de Guadalajara.";
            geoCodeResponseTask = gmapsGeocodeClient.GetGeocodeForAddress(testAddress);
        }        
    }
}
