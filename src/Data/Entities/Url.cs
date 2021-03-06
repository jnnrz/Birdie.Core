using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentValidation;

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

    public class UrlValidator : AbstractValidator<Url>
    {
        public UrlValidator()
        {
            RuleFor(u => u.ExpandedUrl)
                .Must((url) => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("URI is not valid.");
        }
    }
}