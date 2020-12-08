using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Torito.Data.Interfaces;
using Torito.Data.Persistance.Context;
using Torito.Data.Persistance.DataModels;
using Torito.Models.Twitter;

namespace Torito.Data.Implementation
{
    public class TweetDbRepository : ITweetDbRepository
    {
        private readonly ToritoContext _toritoContext;
        public TweetDbRepository(ToritoContext context)
        {
            _toritoContext = context;
        }
        public async Task<int> AddList(IEnumerable<TweetDbo> data, CancellationToken cancellationToken = default)
        {
            await _toritoContext.Tweets.AddRangeAsync(data);
            var saveTask = _toritoContext.SaveChangesAsync(cancellationToken);

            return await saveTask;
        }        

        public async Task<IList<TweetDbo>> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _toritoContext.Tweets
                .Include(x => x.Entities)
                .Include(x => x.Entities.Annotations)
                .Include(x => x.Entities.Hashtags)
                .ToListAsync(cancellationToken);

            return result;
        }

        //public async Task<IList<TweetDbo>> GetLast100ToritoTweets(CancellationToken cancellationToken = default)
        //{
        //    var result = await _toritoContext.Tweets                
        //        .Include(x => x.Entities)
        //        .ThenInclude(x => x.Annotations)               
        //        .Include(x => x.Entities.Hashtags)
        //        .ToListAsync(cancellationToken);

        //    return result;
        //}
    }
}
