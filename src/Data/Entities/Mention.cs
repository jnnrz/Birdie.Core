using System.Text.Json.Serialization;

namespace Birdie.Core.Data.Entities
{
    public class Mention
    {
        [JsonIgnore]
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public int[] Indices { get; set; }
        [JsonIgnore]
        public Tweet Tweet { get; set; }
    }
}