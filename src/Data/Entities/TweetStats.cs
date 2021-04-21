using System.Text.Json.Serialization;

namespace Birdie.Core.Data.Entities
{
    public class TweetStats
    {
        [JsonIgnore]
        public long Id { get; set; }
        [JsonIgnore]
        public long TweetId { get; set; }
        public int RetweetCount { get; set; }
        public int FavoriteCount { get; set; }
        public int ReplyCount { get; set; }
        public int QuoteCount { get; set; }
        [JsonIgnore]
        public Tweet Tweet { get; set; }
    }
}