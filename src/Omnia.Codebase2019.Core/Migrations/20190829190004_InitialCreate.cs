using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Omnia.Codebase2019.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderedBeers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Beer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedBeers", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderedBeers");
        }
    }
}
