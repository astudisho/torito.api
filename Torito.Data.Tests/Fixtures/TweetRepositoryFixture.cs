﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Data.Implementation;
using Torito.Data.Interfaces;
using Torito.Data.Persistance.Context;
using Torito.Data.Utils.Mappings;
using Torito.Models.Utils.Tools;
using TwitterClient.Implementations;
using TwitterClient.Interfaces;

namespace Torito.Data.Tests.Fixtures
{
    public class TweetRepositoryFixture : IDisposable
    {
        internal UserSecretManager secretManager;
        internal string integrationConnectionString;
        internal string twitterApiKey;
        internal ToritoContext toritoContext;
        internal TweetDbRepository tweetDbRepository;
        internal TweetClientRepository tweetClientRepository;
        internal IRecentSearchService recentSearchService;
        internal IMapper mapper;
        internal ICachedTweetService cachedtweetService;
        public TweetRepositoryFixture()
        {
            // Secrets.
            secretManager = new UserSecretManager();
            integrationConnectionString = secretManager.GetDataConnectionStringApiKey("integration");
            twitterApiKey = secretManager.GetTwitterApiKey();

            // Mappper.
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(typeof(DataMapperProfile)))
                .CreateMapper();
            this.mapper = mapper;

            // Twitter Services.
            recentSearchService = new RecentSearchService(twitterApiKey);

            // Context and repositories.
            toritoContext = new ToritoContext(integrationConnectionString);
            var isCreated = toritoContext.Database.EnsureCreated();
            tweetDbRepository = new TweetDbRepository(toritoContext);
            tweetClientRepository = new TweetClientRepository(recentSearchService);
            cachedtweetService = new CachedTweetService(tweetClientRepository, tweetDbRepository, this.mapper);            
        }
        public void Dispose()
        {
            var isDeleted = toritoContext.Database.EnsureDeleted();
        }
    }
}