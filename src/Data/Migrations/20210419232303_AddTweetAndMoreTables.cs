using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Birdie.Core.Data.Migrations
{
    public partial class AddTweetAndMoreTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "favorites",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    tweet_id = table.Column<long>(type: "bigint", nullable: false),
                    favorited_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_favorites", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hashtag",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    indices = table.Column<int[]>(type: "integer[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hashtag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "retweets",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    tweet_id = table.Column<long>(type: "bigint", nullable: false),
                    retweeted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_retweets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tweets",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    body = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    retweeted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    favorited = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tweets", x => x.id);
                    table.ForeignKey(
                        name: "fk_tweets_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hashtag_tweet",
                columns: table => new
                {
                    hashtags_id = table.Column<long>(type: "bigint", nullable: false),
                    tweets_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hashtag_tweet", x => new { x.hashtags_id, x.tweets_id });
                    table.ForeignKey(
                        name: "fk_hashtag_tweet_hashtag_hashtags_id",
                        column: x => x.hashtags_id,
                        principalTable: "hashtag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_hashtag_tweet_tweets_tweets_id",
                        column: x => x.tweets_id,
                        principalTable: "tweets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "media",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    url = table.Column<string>(type: "text", nullable: true),
                    display_url = table.Column<string>(type: "text", nullable: true),
                    indices = table.Column<int[]>(type: "integer[]", nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false),
                    tweet_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_media", x => x.id);
                    table.ForeignKey(
                        name: "fk_media_tweets_tweet_id",
                        column: x => x.tweet_id,
                        principalTable: "tweets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mention",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    screen_name = table.Column<string>(type: "text", nullable: true),
                    indices = table.Column<int[]>(type: "integer[]", nullable: true),
                    tweet_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mention", x => x.id);
                    table.ForeignKey(
                        name: "fk_mention_tweets_tweet_id",
                        column: x => x.tweet_id,
                        principalTable: "tweets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tweet_stats",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tweet_id = table.Column<long>(type: "bigint", nullable: false),
                    retweet_count = table.Column<int>(type: "integer", nullable: false),
                    favorite_count = table.Column<int>(type: "integer", nullable: false),
                    reply_count = table.Column<int>(type: "integer", nullable: false),
                    quote_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tweet_stats", x => x.id);
                    table.ForeignKey(
                        name: "fk_tweet_stats_tweets_tweet_id",
                        column: x => x.tweet_id,
                        principalTable: "tweets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "url",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    generated_url = table.Column<string>(type: "text", nullable: true),
                    expanded_url = table.Column<string>(type: "text", nullable: true),
                    display_url = table.Column<string>(type: "text", nullable: true),
                    indices = table.Column<int[]>(type: "integer[]", nullable: true),
                    tweet_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_url", x => x.id);
                    table.ForeignKey(
                        name: "fk_url_tweets_tweet_id",
                        column: x => x.tweet_id,
                        principalTable: "tweets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_hashtag_tweet_tweets_id",
                table: "hashtag_tweet",
                column: "tweets_id");

            migrationBuilder.CreateIndex(
                name: "ix_media_tweet_id",
                table: "media",
                column: "tweet_id");

            migrationBuilder.CreateIndex(
                name: "ix_mention_tweet_id",
                table: "mention",
                column: "tweet_id");

            migrationBuilder.CreateIndex(
                name: "ix_tweet_stats_tweet_id",
                table: "tweet_stats",
                column: "tweet_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tweets_user_id",
                table: "tweets",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_url_tweet_id",
                table: "url",
                column: "tweet_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favorites");

            migrationBuilder.DropTable(
                name: "hashtag_tweet");

            migrationBuilder.DropTable(
                name: "media");

            migrationBuilder.DropTable(
                name: "mention");

            migrationBuilder.DropTable(
                name: "retweets");

            migrationBuilder.DropTable(
                name: "tweet_stats");

            migrationBuilder.DropTable(
                name: "url");

            migrationBuilder.DropTable(
                name: "hashtag");

            migrationBuilder.DropTable(
                name: "tweets");
        }
    }
}
