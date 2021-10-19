using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreCodeFirst.Migrations
{
    public partial class ErsterKauf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ErsterKauf",
                table: "Kunde",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErsterKauf",
                table: "Kunde");
        }
    }
}
