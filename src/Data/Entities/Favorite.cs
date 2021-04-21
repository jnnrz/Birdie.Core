using System;
using System.Text.Json.Serialization;

namespace Birdie.Core.Data.Entities
{
    public class Favorite
    {
        [JsonIgnore]
        public long Id { get; set; }
        public long UserId { get; set; }
        public long TweetId { get; set; }
        public DateTime FavoritedAt { get; set; }
    }
}