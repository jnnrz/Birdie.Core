using System.Text.Json.Serialization;

namespace Birdie.Core.Data.Entities
{
    public class Media
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string DisplayUrl { get; set; }
        public int[] Indices { get; set; }
        public MediaType Type { get; set; }
        
        public long TweetId { get; set; }
        [JsonIgnore]
        public Tweet Tweet { get; set; }
    }

    public enum MediaType
    {
        Photo,
        Video,
        Gif
    }
}