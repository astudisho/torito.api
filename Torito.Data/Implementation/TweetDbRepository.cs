﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Torito.Data.Interfaces;
using Torito.Data.Persistance.Context;
using Torito.Data.Persistance.DataModels;
using Torito.Models.Twitter;
using AutoMapper;

namespace Torito.Data.Implementation
{
    public class TweetDbRepository : ITweetDbRepository
    {
        private readonly ToritoContext _toritoContext;
        private readonly IMapper _mapper;
        
        public TweetDbRepository(ToritoContext context, IMapper mapper)
        {
            _toritoContext = context;
            _mapper = mapper;
        }

        public async Task<int> AddList(IEnumerable<TweetDbo> data, CancellationToken cancellationToken = default)
        {
            await _toritoContext.Tweets.AddRangeAsync(data);
            var saveTask = _toritoContext.SaveChangesAsync(cancellationToken);

            return await saveTask;
        }        

        public Task<List<TweetDbo>> GetAll(CancellationToken cancellationToken = default)
        {
            var result = _toritoContext.Tweets
                .Include(x => x.Entities)
                .Include(x => x.Entities.Annotations)
                .Include(x => x.Entities.Hashtags)
                .ToListAsync(cancellationToken);

            return result;
        }

        Task<List<TweetDbo>> ITweetDbRepository.GetLast100ToritoTweets(CancellationToken ct = default)
        {
            var result = _toritoContext.Tweets
                .OrderByDescending(x => x.CreatedAt)
                //.OrderByDescending(x => x.Id)
                .Take(100)
                .Include(x => x.Entities)
                .ThenInclude(x => x.Annotations)
                .Include(x => x.Entities.Hashtags);
                //.AsSplitQuery();

            return result.ToListAsync(ct);
        }

        public Task<List<TweetDbo>> GetTweetsWithNullAddressText(CancellationToken cancellationToken = default)
        {
            var result = _toritoContext.Tweets
                .Where(x => x.AddressText == null)
                //.OrderByDescending(x => x.CreatedAt)
                .ToListAsync(cancellationToken);

            return result;
        }

        public Task<List<TweetDbo>> GetTweetsWithNullGeoLocation(CancellationToken cancellationToken = default)
        {
            var result = _toritoContext.Tweets
                //.Include(x => x.Geocode)
                .Where(x => x.Geocode == null)
                .Where(x => x.AddressText != null);
                //.OrderByDescending(x => x.CreatedAt);

            return result.ToListAsync();
        }

        public Task<List<TweetDbo>> GetRecent100TweetsWithGeoLocation(CancellationToken cancellation = default)
        {
            var results = _toritoContext.Tweets
                .Where(x => x.Geocode.Results.Count > 0)
                .Include(x => x.Geocode.Results)
                .ThenInclude(x => x.Geometry)
                .ThenInclude(x => x.Location)
                .OrderByDescending(x => x.CreatedAt)
                .Take(100)
                //.OrderByDescending(x => x.Id)
                //.AsSplitQuery()
                .ToListAsync();

            return results;    
        }

        public Task<List<TweetDbo>> GetLast24HrsWithGeoLocation(CancellationToken cancellation = default)
        {
            var results = _toritoContext.Tweets
                .Where(x => x.Geocode.Results.Count > 0)
                .Where(x => x.CreatedAt > DateTime.Now.AddHours(-24))
                .Include(x => x.Geocode.Results)
                .ThenInclude(x => x.Geometry)
                .ThenInclude(x => x.Location)
                .OrderByDescending(x => x.CreatedAt)
                //.OrderByDescending(x => x.Id)
                //.AsSplitQuery()
                .ToListAsync();

            return results;
        }

        public Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            var result = _toritoContext.SaveChangesAsync();
            return  result;
        }
    } 
}
