using Birdie.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Birdie.Core.Data
{
    public class BirdieContext : DbContext
    {
        public BirdieContext(DbContextOptions<BirdieContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(b =>
            {
                b.Property(u => u.Name).HasMaxLength(20).IsRequired();
                b.Property(u => u.Username).HasMaxLength(20).IsRequired();
                b.Property(u => u.Description).HasMaxLength(140);
                b.Property(u => u.Location).HasMaxLength(100);
                b.Property(u => u.Url).HasMaxLength(250);
                b.Property(u => u.CreatedAt).HasDefaultValueSql("now()");
                b.Property(u => u.IsVerified).HasDefaultValue(false);
                b.Property(u => u.IsProtected).HasDefaultValue(false);
                b.Property(u => u.Following).HasDefaultValue(false);
                b.Property(u => u.WantRetweet).HasDefaultValue(true);
                b.Property(u => u.CanDm).HasDefaultValue(false);
                b.Property(u => u.CanMediaTag).HasDefaultValue(true);
                b.Property(u => u.PinnedStatusId).HasDefaultValue(0L);

                // These two fields are required but right now we don't have a placeholder image for them
                b.Property(u => u.ProfileImageUrl)
                    .HasMaxLength(250)
                    .HasDefaultValue("default_profile_pic.jpg")
                    .IsRequired();

                b.Property(u => u.ProfileBannerUrl)
                    .HasMaxLength(250)
                    .HasDefaultValue("default_banner_pic.jpg")
                    .IsRequired();

                b.Property(u => u.Email).HasMaxLength(100).IsRequired();
            });

            builder.Entity<Country>(b =>
            {
                b.Property(c => c.Name).HasMaxLength(50).IsRequired();
            });

            builder.Entity<Tweet>(b =>
            {
                b.Property(t => t.Body).HasMaxLength(300).IsRequired();
                b.Property(t => t.Retweeted).HasDefaultValue(false);
                b.Property(t => t.Favorited).HasDefaultValue(false);
                b.Property(t => t.CreatedAt).HasDefaultValueSql("now()");
            });

            builder.Entity<Hashtag>(b =>
            {
                b.Property(h => h.Title).HasMaxLength(40).IsRequired(true);
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<TweetStats> TweetStats { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Retweet> Retweets { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<SavedSearch> SavedSearches { get; set; }
    }
}