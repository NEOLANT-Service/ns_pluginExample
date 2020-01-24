using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NsPluginExample.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OAuthToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccessToken = table.Column<string>(nullable: true),
                    RefreshToken = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ExpiresIn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OAuthToken", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OAuthToken");
        }
    }
}
