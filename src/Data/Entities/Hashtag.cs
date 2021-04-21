using System.Collections.Generic;
using System.Text.Json.Serialization;
using FluentValidation;

namespace Birdie.Core.Data.Entities
{
    public class Hashtag
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Title { get; set; }
        public int[] Indices { get; set; }
        [JsonIgnore]
        public ICollection<Tweet> Tweets { get; set; }
    }
    
    public class HashtagValidator : AbstractValidator<Hashtag>
    {
        public HashtagValidator()
        {
            RuleFor(h => h.Title).MaximumLength(40).NotNull();
        }
    }
}