using System.Text.Json.Serialization;

namespace Birdie.Core.Data.Entities
{
    public class SavedSearch
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Search { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}