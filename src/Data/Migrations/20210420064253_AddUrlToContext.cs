using Microsoft.EntityFrameworkCore.Migrations;

namespace Birdie.Core.Data.Migrations
{
    public partial class AddUrlToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_url_tweets_tweet_id",
                table: "url");

            migrationBuilder.DropPrimaryKey(
                name: "pk_url",
                table: "url");

            migrationBuilder.RenameTable(
                name: "url",
                newName: "urls");

            migrationBuilder.RenameIndex(
                name: "ix_url_tweet_id",
                table: "urls",
                newName: "ix_urls_tweet_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_urls",
                table: "urls",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_urls_tweets_tweet_id",
                table: "urls",
                column: "tweet_id",
                principalTable: "tweets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_urls_tweets_tweet_id",
                table: "urls");

            migrationBuilder.DropPrimaryKey(
                name: "pk_urls",
                table: "urls");

            migrationBuilder.RenameTable(
                name: "urls",
                newName: "url");

            migrationBuilder.RenameIndex(
                name: "ix_urls_tweet_id",
                table: "url",
                newName: "ix_url_tweet_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_url",
                table: "url",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_url_tweets_tweet_id",
                table: "url",
                column: "tweet_id",
                principalTable: "tweets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
