using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gmaps.Client.Implementations;
using Gmaps.Client.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Torito.Core.Handlers;
using Torito.Core.Handlers.Implementations;
using Torito.Core.Handlers.Interfaces;
using Torito.Core.Services.Implementations;
using Torito.Core.Services.Interfaces;
using Torito.Data.Implementation;
using Torito.Data.Interfaces;
using Torito.Data.Persistance.Context;
using Torito.Data.Persistance.DataModels;
using Torito.Models.Utils.Tools;
using TwitterClient.Implementations;
using TwitterClient.Interfaces;

using Torito.Data.Utils.Mappings;
using Torito.Core.Handlers.Implementations.Receivers;

namespace Torito.WebApi.ServiceExtensions
{
    internal static class StartupServiceExtension
    {
        internal static void InjectServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<UserSecretManager>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var userSecretManager = serviceProvider.GetService<UserSecretManager>();
            var webHostEnvironment = serviceProvider.GetService<IWebHostEnvironment>();
            
            serviceCollection.AddScoped<ITweetRepository, TweetClientRepository>();
            serviceCollection.AddScoped<ITweetDbRepository, TweetDbRepository>();
            serviceCollection.AddScoped<IGmapsGeocodeClient, GmapsGeocodeClient>(x => new GmapsGeocodeClient(userSecretManager.GetGmapsGeocodeApiKey()));
            serviceCollection.AddScoped<IRecentSearchService,RecentSearchService>(x => new RecentSearchService(userSecretManager.GetTwitterApiKey()));
            serviceCollection.AddDbContext<ToritoContext>(options => options.UseSqlServer(userSecretManager.GetDataConnectionStringApiKey()));
            serviceCollection.AddScoped<ITweetLocationService, TweetLocationService>();
            serviceCollection.AddScoped<ISyncService, SyncService>();


            // Address clean.
            // Receivers.
            serviceCollection.AddScoped<IReceiver<TweetDbo>, AddressCleanReceiver>();
            serviceCollection.AddScoped<IReceiver<TweetDbo>, AlcoholimetroCleanReceiver>();
            serviceCollection.AddScoped<IReceiver<TweetDbo>, RetweetCleanReceiver>();
            serviceCollection.AddScoped<IReceiver<TweetDbo>, ParenthesisCleanReceiver>();
            serviceCollection.AddScoped<IReceiver<TweetDbo>, HashtagsCleanReceiver>();
            serviceCollection.AddScoped<IReceiver<TweetDbo>, IconCleanReceiver>();

            // Services.
            serviceCollection.AddScoped<IAddressCleanService, AddressCleanService>();
            serviceCollection.AddScoped<IHandler<TweetDbo>, TweetDboAddressCleanHandler>();
            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile(typeof(DataMapperProfile)));
            serviceCollection.AddScoped<ICachedTweetService, CachedTweetService>();

            //var sp = serviceCollection.BuildServiceProvider();
            //var result = sp.GetService<IReceiver<TweetDbo>>();
        }
    }
}
