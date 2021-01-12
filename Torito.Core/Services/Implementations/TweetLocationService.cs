using AutoMapper;
using Gmaps.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Torito.Core.Services.Interfaces;
using Torito.Data.Interfaces;
using Torito.Data.Persistance.DataModels;
using Torito.Data.Persistance.DataModels.Gmaps;
using Torito.Models.Twitter;

namespace Torito.Core.Services.Implementations
{
    public class TweetLocationService : ITweetLocationService
    {
        private readonly ITweetDbRepository _tweetDbRepository;
        private readonly IAddressCleanService _addressCleanService;
        private readonly IGmapsGeocodeClient _gmapsGeocodeClient;
        private readonly IMapper _mapper;
        public TweetLocationService(ITweetDbRepository tweetDbRepository, 
            IAddressCleanService addressCleanService, 
            IGmapsGeocodeClient gmapsGeocodeClient,
            IMapper mapper)
        {
            _tweetDbRepository = tweetDbRepository;
            _addressCleanService = addressCleanService;
            _gmapsGeocodeClient = gmapsGeocodeClient;
            _mapper = mapper;
        }

        public async Task<IList<TweetDbo>> AssignAddressTextToTweet(CancellationToken cancellationToken = default)
        {
            var notAddressTextTweets = await _tweetDbRepository.GetTweetsWithNullAddressText(cancellationToken);

            var addressTextTweets = notAddressTextTweets.Select(x =>
            {
                _addressCleanService.SetAddressFromTweet(x);
                return x;
            }).ToList();

            return addressTextTweets;
        }

        public async Task<TweetDbo> AssignAddressObjectToTweet(TweetDbo tweetDbo, CancellationToken cancellationToken = default)
        {
            var geocode = await _gmapsGeocodeClient.GetGeocodeForAddress(tweetDbo.AddressText, cancellationToken);

            var geocodeDbo = _mapper.Map<GeocodeDbo>(geocode);

            tweetDbo.Geocode = geocodeDbo;

            return tweetDbo;
        }
    }
}
