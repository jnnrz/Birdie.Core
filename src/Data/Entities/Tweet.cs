using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FluentValidation;
using NpgsqlTypes;

namespace Birdie.Core.Data.Entities
{
    public class Tweet
    {
        public long Id { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Retweeted { get; set; }
        public bool Favorited { get; set; }
        [JsonIgnore]
        public NpgsqlTsVector SearchVector { get; set; }

        public TweetStats Stats { get; set; }
        public ICollection<Hashtag> Hashtags { get; set; }
        public ICollection<Mention> Mentions { get; set; }
        public ICollection<Url> Urls { get; set; }
        public ICollection<Media> Mediae { get; set; }

        public long UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }

    public class TweetValidator : AbstractValidator<Tweet>
    {
        public TweetValidator(IValidator<Url> urlValidator)
        {
            RuleFor(t => t.Body).MaximumLength(300).NotNull();
            RuleForEach(t => t.Urls).SetValidator(urlValidator);
        }
    }
}