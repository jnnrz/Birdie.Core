// <auto-generated />
using System;
using Birdie.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Birdie.Core.Data.Migrations
{
    [DbContext(typeof(BirdieContext))]
    [Migration("20210322203136_AddUsersTable")]
    partial class AddUsersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Birdie.Core.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

            modelBuilder.Entity("Birdie.Core.Data.Entities.UserStatistics", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
#pragma warning restore 612, 618
        }
    }
}