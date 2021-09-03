using Microsoft.EntityFrameworkCore.Migrations;

namespace Birdie.Core.Data.Migrations
{
    public partial class ChangesToSomeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_hashtag_tweet_hashtag_hashtags_id",
                table: "hashtag_tweet");

            migrationBuilder.DropForeignKey(
                name: "fk_mention_tweets_tweet_id",
                table: "mention");

            migrationBuilder.DropForeignKey(
                name: "fk_user_statistics_users_user_id",
                table: "user_statistics");

            migrationBuilder.DropForeignKey(
                name: "fk_users_country_country_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_statistics",
                table: "user_statistics");

            migrationBuilder.DropPrimaryKey(
                name: "pk_mention",
                table: "mention");

            migrationBuilder.DropPrimaryKey(
                name: "pk_hashtag",
                table: "hashtag");

            migrationBuilder.DropPrimaryKey(
                name: "pk_country",
                table: "country");

            migrationBuilder.RenameTable(
                name: "user_statistics",
                newName: "user_stats");

            migrationBuilder.RenameTable(
                name: "mention",
                newName: "mentions");

            migrationBuilder.RenameTable(
                name: "hashtag",
                newName: "hashtags");

            migrationBuilder.RenameTable(
                name: "country",
                newName: "countries");

            migrationBuilder.RenameIndex(
                name: "ix_user_statistics_user_id",
                table: "user_stats",
                newName: "ix_user_stats_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_mention_tweet_id",
                table: "mentions",
                newName: "ix_mentions_tweet_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_stats",
                table: "user_stats",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_mentions",
                table: "mentions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_hashtags",
                table: "hashtags",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_countries",
                table: "countries",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_hashtag_tweet_hashtags_hashtags_id",
                table: "hashtag_tweet",
                column: "hashtags_id",
                principalTable: "hashtags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_mentions_tweets_tweet_id",
                table: "mentions",
                column: "tweet_id",
                principalTable: "tweets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_user_stats_users_user_id",
                table: "user_stats",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_users_countries_country_id",
                table: "users",
                column: "country_id",
                principalTable: "countries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_hashtag_tweet_hashtags_hashtags_id",
                table: "hashtag_tweet");

            migrationBuilder.DropForeignKey(
                name: "fk_mentions_tweets_tweet_id",
                table: "mentions");

            migrationBuilder.DropForeignKey(
                name: "fk_user_stats_users_user_id",
                table: "user_stats");

            migrationBuilder.DropForeignKey(
                name: "fk_users_countries_country_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_stats",
                table: "user_stats");

            migrationBuilder.DropPrimaryKey(
                name: "pk_mentions",
                table: "mentions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_hashtags",
                table: "hashtags");

            migrationBuilder.DropPrimaryKey(
                name: "pk_countries",
                table: "countries");

            migrationBuilder.RenameTable(
                name: "user_stats",
                newName: "user_statistics");

            migrationBuilder.RenameTable(
                name: "mentions",
                newName: "mention");

            migrationBuilder.RenameTable(
                name: "hashtags",
                newName: "hashtag");

            migrationBuilder.RenameTable(
                name: "countries",
                newName: "country");

            migrationBuilder.RenameIndex(
                name: "ix_user_stats_user_id",
                table: "user_statistics",
                newName: "ix_user_statistics_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_mentions_tweet_id",
                table: "mention",
                newName: "ix_mention_tweet_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_statistics",
                table: "user_statistics",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_mention",
                table: "mention",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_hashtag",
                table: "hashtag",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_country",
                table: "country",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_hashtag_tweet_hashtag_hashtags_id",
                table: "hashtag_tweet",
                column: "hashtags_id",
                principalTable: "hashtag",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_mention_tweets_tweet_id",
                table: "mention",
                column: "tweet_id",
                principalTable: "tweets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_user_statistics_users_user_id",
                table: "user_statistics",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_users_country_country_id",
                table: "users",
                column: "country_id",
                principalTable: "country",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
