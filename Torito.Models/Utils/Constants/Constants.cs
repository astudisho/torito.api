using System;
using System.Collections.Generic;
using System.Text;

namespace Torito.Models.Utils
{
    public class Constants
    {
        public class Twitter
        {
            public static class SerializeProperties
            {
                public class Metadata
                {
                    public const string Count = "result_count";
                }
            }

            public static class QueryParameters
            {
                public static class RecentSearch
                {
                    public static class Expansions
                    {
                        public static readonly string AuthorId = "author_id";
                        public static readonly string ReferencedTweetsId = "referenced_tweets.id";
                        public static readonly string InReplyToUser = "in_reply_to_user_id";
                        public static readonly string AttachmentsMediaKeys = "attachments.media_keys";
                        public static readonly string AttachmentsPollIds = "attachments.poll_ids";
                        public static readonly string GeoPlaceId = "geo.place_id";
                        public static readonly string EntitiesMentionsUsername = "entities.mentions.username";
                        public static readonly string ReferencedTweetsIdAuthorId = "referenced_tweets.id.author_id";                        
                    }

                    public static class MediaFields
                    {
                        public static readonly string DurationMs = "duration_ms";
                        public static readonly string Height = "height";
                        public static readonly string MediaKey = "media_key";
                        public static readonly string PreviewImageUrl = "preview_image_url";
                        public static readonly string Type = "type";
                        public static readonly string Url = "url";
                        public static readonly string Width = "width";
                        public static readonly string PublicMetrics = "public_metrics";
                        public static readonly string NonPublicMetrics = "non_public_metrics";
                        public static readonly string OrganicMetrics = "organic_metrics";
                        public static readonly string PromotedMetric = "promoted_metric";                        
                    }

                    public static class PlaceFields
                    {
                        public static readonly string ContainedWithin = "contained_within";
                        public static readonly string Country = "country";
                        public static readonly string CountryCode = "country_code";
                        public static readonly string FullName = "full_name";
                        public static readonly string Geo = "geo";
                        public static readonly string Id = "id";
                        public static readonly string Name = "name";
                        public static readonly string PlaceType = "place_type";
                    }

                    public static class PollFields
                    {
                        public static readonly string DurationMinutes = "duration_minutes";
                        public static readonly string EndDateTime = "end_datetime";
                        public static readonly string Id = "id";
                        public static readonly string Options = "options";
                        public static readonly string VOtingStatus = "voting_status";
                    }

                    public static class TweetFields
                    {
                        public static readonly string Attachments = "attachments";
                        public static readonly string AuthorId = "author_id";
                        public static readonly string ContextAnnotations = "context_annotations";
                        public static readonly string ConversationId = "conversation_id";
                        public static readonly string CreatedAt = "created_at";
                        public static readonly string Entities = "entities";
                        public static readonly string Geo = "geo";
                        public static readonly string Id = "id";
                        public static readonly string InReplyToUserId = "in_reply_to_user_id";
                        public static readonly string Lang = "lang";
                        public static readonly string NonPublicMetrics = "non_public_metrics";
                        public static readonly string PublicMetrics = "public_metrics";
                        public static readonly string OrganMetrics = "organic_metrics";
                        public static readonly string PromotedMetrics = "promoted_metrics";
                        public static readonly string PossiblySensitive = "possibly_sensitive";
                        public static readonly string ReferencedTweets = "referenced_tweets";
                        public static readonly string Source = "source";
                        public static readonly string Text = "text";
                        public static readonly string WithHeld = "withheld";
                    }

                    public static class UserFields
                    {
                        public static readonly string CreatedAt = "created_at";
                        public static readonly string Description = "description";
                        public static readonly string Entities = "entities";
                        public static readonly string Id = "id";
                        public static readonly string Location = "location";
                        public static readonly string Name = "name";
                        public static readonly string PinnedTweetId = "pinned_tweet_id";
                        public static readonly string ProfileImageUrl = "profile_image_url";
                        public static readonly string Protected = "protected";
                        public static readonly string PublicMetrics = "public_metrics";
                        public static readonly string Url = "url";
                        public static readonly string UserName = "username";
                        public static readonly string Verified = "verified";
                        public static readonly string WithHeld = "withheld";
                    }
                }
            }
        }
    }
}
