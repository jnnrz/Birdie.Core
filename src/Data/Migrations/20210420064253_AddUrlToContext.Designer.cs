// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Birdie.Core.Data.Migrations
{
    [DbContext(typeof(BirdieContext))]
    [Migration("20210420064253_AddUrlToContext")]
    partial class AddUrlToContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Birdie.API.Data.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_country");

                    b.ToTable("country");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.Favorite", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("FavoritedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("favorited_at");

                    b.Property<long>("TweetId")
                        .HasColumnType("bigint")
                        .HasColumnName("tweet_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_favorites");

                    b.ToTable("favorites");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.Hashtag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int[]>("Indices")
                        .HasColumnType("integer[]")
                        .HasColumnName("indices");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_hashtag");

                    b.ToTable("hashtag");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.Media", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("DisplayUrl")
                        .HasColumnType("text")
                        .HasColumnName("display_url");

                    b.Property<int[]>("Indices")
                        .HasColumnType("integer[]")
                        .HasColumnName("indices");

                    b.Property<long>("TweetId")
                        .HasColumnType("bigint")
                        .HasColumnName("tweet_id");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<string>("Url")
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_media");

                    b.HasIndex("TweetId")
                        .HasDatabaseName("ix_media_tweet_id");

                    b.ToTable("media");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.Mention", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int[]>("Indices")
                        .HasColumnType("integer[]")
                        .HasColumnName("indices");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("ScreenName")
                        .HasColumnType("text")
                        .HasColumnName("screen_name");

                    b.Property<long?>("TweetId")
                        .HasColumnType("bigint")
                        .HasColumnName("tweet_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_mention");

                    b.HasIndex("TweetId")
                        .HasDatabaseName("ix_mention_tweet_id");

                    b.ToTable("mention");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.Retweet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("RetweetedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("retweeted_at");

                    b.Property<long>("TweetId")
                        .HasColumnType("bigint")
                        .HasColumnName("tweet_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_retweets");

                    b.ToTable("retweets");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.Tweet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("body");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("Favorited")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("favorited");

                    b.Property<bool>("Retweeted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("retweeted");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_tweets");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_tweets_user_id");

                    b.ToTable("tweets");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.TweetStats", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("FavoriteCount")
                        .HasColumnType("integer")
                        .HasColumnName("favorite_count");

                    b.Property<int>("QuoteCount")
                        .HasColumnType("integer")
                        .HasColumnName("quote_count");

                    b.Property<int>("ReplyCount")
                        .HasColumnType("integer")
                        .HasColumnName("reply_count");

                    b.Property<int>("RetweetCount")
                        .HasColumnType("integer")
                        .HasColumnName("retweet_count");

                    b.Property<long>("TweetId")
                        .HasColumnType("bigint")
                        .HasColumnName("tweet_id");

                    b.HasKey("Id")
                        .HasName("pk_tweet_stats");

                    b.HasIndex("TweetId")
                        .IsUnique()
                        .HasDatabaseName("ix_tweet_stats_tweet_id");

                    b.ToTable("tweet_stats");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.Url", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("DisplayUrl")
                        .HasColumnType("text")
                        .HasColumnName("display_url");

                    b.Property<string>("ExpandedUrl")
                        .HasColumnType("text")
                        .HasColumnName("expanded_url");

                    b.Property<string>("GeneratedUrl")
                        .HasColumnType("text")
                        .HasColumnName("generated_url");

                    b.Property<int[]>("Indices")
                        .HasColumnType("integer[]")
                        .HasColumnName("indices");

                    b.Property<long>("TweetId")
                        .HasColumnType("bigint")
                        .HasColumnName("tweet_id");

                    b.HasKey("Id")
                        .HasName("pk_urls");

                    b.HasIndex("TweetId")
                        .HasDatabaseName("ix_urls_tweet_id");

                    b.ToTable("urls");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("CanDm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("can_dm");

                    b.Property<bool>("CanMediaTag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("can_media_tag");

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer")
                        .HasColumnName("country_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .HasMaxLength(140)
                        .HasColumnType("character varying(140)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<bool>("Following")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("following");

                    b.Property<bool>("IsProtected")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_protected");

                    b.Property<bool>("IsVerified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_verified");

                    b.Property<string>("Location")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<long>("PinnedStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L)
                        .HasColumnName("pinned_status_id");

                    b.Property<string>("ProfileBannerUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasDefaultValue("default_banner_pic.jpg")
                        .HasColumnName("profile_banner_url");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasDefaultValue("default_profile_pic.jpg")
                        .HasColumnName("profile_image_url");

                    b.Property<string>("Url")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("url");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("username");

                    b.Property<bool>("WantRetweet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("want_retweet");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("CountryId")
                        .HasDatabaseName("ix_users_country_id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.UserStatistics", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("FavouritesCount")
                        .HasColumnType("integer")
                        .HasColumnName("favourites_count");

                    b.Property<int>("FollowersCount")
                        .HasColumnType("integer")
                        .HasColumnName("followers_count");

                    b.Property<int>("FriendsCount")
                        .HasColumnType("integer")
                        .HasColumnName("friends_count");

                    b.Property<int>("ListedCount")
                        .HasColumnType("integer")
                        .HasColumnName("listed_count");

                    b.Property<int>("MediaCount")
                        .HasColumnType("integer")
                        .HasColumnName("media_count");

                    b.Property<int>("StatusCount")
                        .HasColumnType("integer")
                        .HasColumnName("status_count");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_statistics");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasDatabaseName("ix_user_statistics_user_id");

                    b.ToTable("user_statistics");
                });

            modelBuilder.Entity("HashtagTweet", b =>
                {
                    b.Property<long>("HashtagsId")
                        .HasColumnType("bigint")
                        .HasColumnName("hashtags_id");

                    b.Property<long>("TweetsId")
                        .HasColumnType("bigint")
                        .HasColumnName("tweets_id");

                    b.HasKey("HashtagsId", "TweetsId")
                        .HasName("pk_hashtag_tweet");

                    b.HasIndex("TweetsId")
                        .HasDatabaseName("ix_hashtag_tweet_tweets_id");

                    b.ToTable("hashtag_tweet");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.Media", b =>
                {
                    b.HasOne("Birdie.API.Data.Entities.Tweet", "Tweet")
                        .WithMany("Mediae")
                        .HasForeignKey("TweetId")
                        .HasConstraintName("fk_media_tweets_tweet_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tweet");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.Mention", b =>
                {
                    b.HasOne("Birdie.API.Data.Entities.Tweet", "Tweet")
                        .WithMany("Mentions")
                        .HasForeignKey("TweetId")
                        .HasConstraintName("fk_mention_tweets_tweet_id");

                    b.Navigation("Tweet");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.Tweet", b =>
                {
                    b.HasOne("Birdie.API.Data.Entities.User", "User")
                        .WithMany("Tweets")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_tweets_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.TweetStats", b =>
                {
                    b.HasOne("Birdie.API.Data.Entities.Tweet", "Tweet")
                        .WithOne("Stats")
                        .HasForeignKey("Birdie.API.Data.Entities.TweetStats", "TweetId")
                        .HasConstraintName("fk_tweet_stats_tweets_tweet_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tweet");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.Url", b =>
                {
                    b.HasOne("Birdie.API.Data.Entities.Tweet", "Tweet")
                        .WithMany("Urls")
                        .HasForeignKey("TweetId")
                        .HasConstraintName("fk_urls_tweets_tweet_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tweet");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.User", b =>
                {
                    b.HasOne("Birdie.API.Data.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .HasConstraintName("fk_users_country_country_id");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.UserStatistics", b =>
                {
                    b.HasOne("Birdie.API.Data.Entities.User", "User")
                        .WithOne("Statistics")
                        .HasForeignKey("Birdie.API.Data.Entities.UserStatistics", "UserId")
                        .HasConstraintName("fk_user_statistics_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HashtagTweet", b =>
                {
                    b.HasOne("Birdie.API.Data.Entities.Hashtag", null)
                        .WithMany()
                        .HasForeignKey("HashtagsId")
                        .HasConstraintName("fk_hashtag_tweet_hashtag_hashtags_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Birdie.API.Data.Entities.Tweet", null)
                        .WithMany()
                        .HasForeignKey("TweetsId")
                        .HasConstraintName("fk_hashtag_tweet_tweets_tweets_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.Tweet", b =>
                {
                    b.Navigation("Mediae");

                    b.Navigation("Mentions");

                    b.Navigation("Stats");

                    b.Navigation("Urls");
                });

            modelBuilder.Entity("Birdie.API.Data.Entities.User", b =>
                {
                    b.Navigation("Statistics");

                    b.Navigation("Tweets");
                });
#pragma warning restore 612, 618
        }
    }
}
