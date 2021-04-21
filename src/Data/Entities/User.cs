using System;
using System.Collections.Generic;
using FluentValidation;

namespace Birdie.Core.Data.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsVerified { get; set; }
        public bool IsProtected { get; set; }
        public bool Following { get; set; }
        public bool WantRetweet { get; set; }
        public bool CanDm { get; set; }
        public bool CanMediaTag { get; set; }
        public long PinnedStatusId { get; set; }
        public string ProfileImageUrl { get; set; }
        public string ProfileBannerUrl { get; set; }
        public string Email { get; set; }
        
        public Country Country { get; set; }
        public UserStatistics Statistics { get; set; }
        public ICollection<Tweet> Tweets { get; set; }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).MaximumLength(50).NotNull();
            RuleFor(u => u.Username).MaximumLength(30).NotNull();
            RuleFor(u => u.Email).EmailAddress().NotNull();
        }
    }
}