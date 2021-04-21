using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Birdie.Core.Data.Migrations
{
    public partial class AddUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    username = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    location = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "character varying(140)", maxLength: 140, nullable: true),
                    url = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    is_verified = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_protected = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    following = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    want_retweet = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    can_dm = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    can_media_tag = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    pinned_status_id = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    profile_image_url = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, defaultValue: "default_profile_pic.jpg"),
                    profile_banner_url = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, defaultValue: "default_banner_pic.jpg"),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_country_country_id",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_statistics",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    followers_count = table.Column<int>(type: "integer", nullable: false),
                    friends_count = table.Column<int>(type: "integer", nullable: false),
                    listed_count = table.Column<int>(type: "integer", nullable: false),
                    favourites_count = table.Column<int>(type: "integer", nullable: false),
                    status_count = table.Column<int>(type: "integer", nullable: false),
                    media_count = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_statistics", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_statistics_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_statistics_user_id",
                table: "user_statistics",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_country_id",
                table: "users",
                column: "country_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_statistics");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
