using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Torito.Models.Twitter.Enums.RecentSearchEnums;

namespace Torito.Models.Twitter
{
    public class RecentSearchRequestParameters : IRequestParameters
    {
        [Description("start_time")]
        public string StartTime { get; set; }
        [Description("end_time")]
        public string EndTime { get; set; }
        [Description("since_id")]
        public long? SinceId { get; set; }
        [Description("until_id")]
        public long? UntilId { get; set; }
        [Description("max-results")]
        [Range(10, 100)]
        public int MaxResults { get; set; } = 10;
        [Description("next_token")]
        public string NextToken { get; set; }
        [Description("tweet.fields")]
        public IEnumerable<TweetFields> TweetFields { get; set; }
        [Description("media.fields")]
        public IEnumerable<MediaFields> MediaFields { get; set; }
        [Description("place.fields")]
        public IEnumerable<PlaceFields> PlaceFields { get; set; }
        [Description("poll.fields")]
        public IEnumerable<PollFields> PollFields { get; set; }
        [Description("user.fields")]
        public IEnumerable<UserFields> UserFields { get; set; }
        [Description("expansions")]
        public IEnumerable<Expansions> Expansions { get; set; }
    }
}
