using System;
using System.Text.Json.Serialization;

namespace Birdie.Core.Data.Entities
{
    public class Retweet
    {
        [JsonIgnore]
        public long Id { get; set; }
        public long UserId { get; set; }
        public long TweetId { get; set; }
        public DateTime RetweetedAt { get; set; }
    }
}