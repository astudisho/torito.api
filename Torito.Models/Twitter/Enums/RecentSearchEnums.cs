using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Torito.Models.Twitter.Enums
{
    public static class RecentSearchEnums
    {
        public enum Expansions
        {
            [Description("author_id")]
            AuthorId,
            [Description("referenced_tweets.id")]
            ReferencedTweets,
            [Description("in_reply_to_user_id")]
            InReplyToUser,
            [Description("attachments.media_keys	")]
            AttachmentsMediaKeys,
            [Description("attachments.poll_ids	")]
            AttachmentsPollId,
            [Description("geo.place_id")]
            GeoPlaceId,
            [Description("entities.mentions.username")]
            EntitiesMentionsUsername,
            [Description("referenced_tweets.id.author_id")]
            ReferencedTweetsAuthorId
        }

        public enum MediaFields
        {
            [Description("duration_ms")]
            DurationMs,
            [Description("height")]
            Height,
            [Description("media_key")]
            MediaKey,
            [Description("preview_image_url")]
            PreviewImageUrl,
            [Description("type")]
            Type,
            [Description("url")]
            Url,
            [Description("width")]
            Width,
            [Description("public_metrics")]
            PublicMetrics,            
            [Description("non_public_metrics")]
            NonPublicMetrics,
            [Description("organic_metrics")]
            OrganicMetrics, 
            [Description("promoted_metric")]
            PromotedMetric
        }

        public enum PlaceFields
        {
            contained_within, country, country_code, full_name, geo, id, name, place_type
        }

        public enum PollFields
        {
            duration_minutes, end_datetime, id, options, voting_status
        }

        public enum TweetFields
        {
            attachments, author_id, context_annotations, conversation_id, created_at, entities, geo, id, in_reply_to_user_id, lang, non_public_metrics, public_metrics, organic_metrics, promoted_metrics, possibly_sensitive, referenced_tweets, source, text, withheld
        }

        public enum UserFields
        {
            created_at, description, entities, id, location, name, pinned_tweet_id, profile_image_url, @protected, public_metrics, url, username, verified, withheld
        }
    }
}
