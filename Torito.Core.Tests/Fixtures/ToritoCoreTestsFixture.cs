using AutoMapper;
using Gmaps.Client.Implementations;
using Gmaps.Client.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Core.Handlers;
using Torito.Core.Handlers.Implementations;
using Torito.Core.Handlers.Interfaces;
using Torito.Core.Services.Implementations;
using Torito.Core.Services.Interfaces;
using Torito.Data.Implementation;
using Torito.Data.Interfaces;
using Torito.Data.Persistance.Context;
using Torito.Data.Persistance.DataModels;
using Torito.Data.Utils.Mappings;
using Torito.Models.GMaps;
using Torito.Models.Utils.Tools;

namespace Torito.Core.Tests.Fixtures
{
    public class ToritoCoreTestsFixture : IDisposable
    {
        internal UserSecretManager SecretManager { get; private set; }
        internal IAddressCleanService AddressCleanService { get; private set; }
        internal IGmapsGeocodeClient GmapsGeocodeClient { get; private set; }
        internal ITweetLocationService LocationService { get; private set; }
        internal ITweetDbRepository TweetDbRepository { get; private set; }
        internal ToritoContext ToritoContext { get; private set; }
        internal IMapper Mapper { get; private set; }
        internal IReceiver<TweetDbo> AddressCleanReceiver { get; private set; }
        internal IReceiver<TweetDbo> ParenthesisCleanReceiver { get; private set; }
        internal IReceiver<TweetDbo> RetweetCleanReceiver { get; private set; }
        internal IReceiver<TweetDbo> HashtagsCleanReceiver { get; private set; }
        internal IReceiver<TweetDbo> AlcoholimetroCleanReceiver { get; private set; }
        internal IHandler<TweetDbo> TweetDboCleanerHandler { get; private set; }
        //internal readonly Task<GeoCodeResponse> geoCodeResponseTask;
        public ToritoCoreTestsFixture()
        {
            SecretManager = new UserSecretManager();
            var gmapsApiKey = SecretManager.GetGmapsGeocodeApiKey();
            GmapsGeocodeClient = new GmapsGeocodeClient(gmapsApiKey);

            // Mappper.
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(typeof(DataMapperProfile)))
                .CreateMapper();
            Mapper = mapper;

            // Cleaners.
            AddressCleanReceiver = new AddressCleanReceiver();
            ParenthesisCleanReceiver = new ParenthesisCleanReceiver();
            RetweetCleanReceiver = new RetweetCleanReceiver();
            HashtagsCleanReceiver = new HashtagsCleanReceiver();

            // Cleaner Handler.
            TweetDboCleanerHandler = new TweetDboAddressCleanHandler(
                new IReceiver<TweetDbo>[]
                { 
                    AddressCleanReceiver,
                    AlcoholimetroCleanReceiver,
                    RetweetCleanReceiver, 
                    ParenthesisCleanReceiver, 
                    HashtagsCleanReceiver, 
                });
            // Clean Service.
            AddressCleanService = new AddressCleanService(TweetDboCleanerHandler);

            // Inmemory DB.
            var contextOptions = new DbContextOptionsBuilder<ToritoContext>()
                .UseInMemoryDatabase("ToritoDevInMemory")
                .Options;

            // Db.
            ToritoContext = new ToritoContext(contextOptions);
            ToritoContext.Database.EnsureCreated();
            TweetDbRepository = new TweetDbRepository(ToritoContext, mapper);
            LocationService = new TweetLocationService(TweetDbRepository,AddressCleanService, GmapsGeocodeClient, Mapper);

        }
        public void Dispose()
        {
            // ToritoContext.Database.EnsureDeleted();
        }
    }
}
