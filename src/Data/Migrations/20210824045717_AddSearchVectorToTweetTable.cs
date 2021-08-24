using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

namespace Birdie.Core.Data.Migrations
{
    public partial class AddSearchVectorToTweetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "search_vector",
                table: "tweets",
                type: "tsvector",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_tweets_search_vector",
                table: "tweets",
                column: "search_vector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.Sql(@"CREATE TRIGGER search_vector_update BEFORE INSERT OR UPDATE
                ON ""tweets"" FOR EACH ROW EXECUTE PROCEDURE
                tsvector_update_trigger(""search_vector"", 'pg_catalog.spanish', ""body"")");

            migrationBuilder.Sql(@"CREATE INDEX fts_idx ON ""tweets"" USING GIN (to_tsvector('spanish', ""body""));");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_tweets_search_vector",
                table: "tweets");

            migrationBuilder.DropColumn(
                name: "search_vector",
                table: "tweets");

            migrationBuilder.Sql("DROP TRIGGER search_vector_update");
            migrationBuilder.Sql(@"DROP INDEX fts_idx");
        }
    }
}
