using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        [Description("max_results")]
        [Range(10, 100)]
        public int MaxResults { get; set; } = 10;
        [Description("next_token")]
        public string NextToken { get; set; }
        [Description("tweet.fields")]
        public IEnumerable<string> TweetFields { get; set; }
        [Description("media.fields")]
        public IEnumerable<string> MediaFields { get; set; }
        [Description("place.fields")]
        public IEnumerable<string> PlaceFields { get; set; }
        [Description("poll.fields")]
        public IEnumerable<string> PollFields { get; set; }
        [Description("user.fields")]
        public IEnumerable<string> UserFields { get; set; }
        [Description("expansions")]
        public IList<string> Expansions { get; set; }
    }
}
