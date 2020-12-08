using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Torito.Models.Twitter
{
    public class Annotation
    {
        [DeserializeAs(Name = "start")]
        public int? Start { get; set; }

        [DeserializeAs(Name = "end")]
        public int? End { get; set; }

        [DeserializeAs(Name = "probability")]
        public double? Probability { get; set; }

        [DeserializeAs(Name = "type")]
        public string Type { get; set; }

        [DeserializeAs(Name = "normalized_text")]
        public string NormalizedText { get; set; }
    }

    public class Mention
    {
        [DeserializeAs(Name = "start")]
        public int? Start { get; set; }

        [DeserializeAs(Name = "end")]
        public int? End { get; set; }

        [DeserializeAs(Name = "username")]
        public string Username { get; set; }
    }

    public class Hashtag
    {
        [DeserializeAs(Name = "start")]
        public int? Start { get; set; }

        [DeserializeAs(Name = "end")]
        public int? End { get; set; }

        [DeserializeAs(Name = "tag")]
        public string Tag { get; set; }
    }

    public class Entities
    {
        [DeserializeAs(Name = "annotations")]
        public List<Annotation> Annotations { get; set; }

        [DeserializeAs(Name = "mentions")]
        public List<Mention> Mentions { get; set; }

        [DeserializeAs(Name = "hashtags")]
        public List<Hashtag> Hashtags { get; set; }
    }

    public class PublicMetrics
    {
        [DeserializeAs(Name = "retweet_count")]
        public int? RetweetCount { get; set; }

        [DeserializeAs(Name = "reply_count")]
        public int? ReplyCount { get; set; }

        [DeserializeAs(Name = "like_count")]
        public int? LikeCount { get; set; }

        [DeserializeAs(Name = "quote_count")]
        public int? QuoteCount { get; set; }
    }

    public class Tweet
    {
        [DeserializeAs(Name = "author_id")]
        public string AuthorId { get; set; }

        [DeserializeAs(Name = "text")]
        public string Text { get; set; }

        [DeserializeAs(Name = "id")]
        public ulong Id { get; set; }

        [DeserializeAs(Name = "entities")]
        public Entities Entities { get; set; }

        [DeserializeAs(Name = "lang")]
        public string Lang { get; set; }

        [DeserializeAs(Name = "possibly_sensitive")]
        public bool? PossiblySensitive { get; set; }

        [DeserializeAs(Name = "source")]
        public string Source { get; set; }

        [DeserializeAs(Name = "public_metrics")]
        public PublicMetrics PublicMetrics { get; set; }

        [DeserializeAs(Name = "conversation_id")]
        public string ConversationId { get; set; }

        [DeserializeAs(Name = "created_at")]
        public DateTime? CreatedAt { get; set; }
    }

}
