using System.Text.Json.Serialization;

namespace Birdie.Core.Data.Entities
{
    public class Url
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string GeneratedUrl { get; set; }
        public string ExpandedUrl { get; set; }
        public string DisplayUrl { get; set; }
        public int[] Indices { get; set; }
        [JsonIgnore]
        public long TweetId { get; set; }
        [JsonIgnore]
        public Tweet Tweet { get; set; }
    }
}