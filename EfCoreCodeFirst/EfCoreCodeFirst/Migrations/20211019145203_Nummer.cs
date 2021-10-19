using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreCodeFirst.Migrations
{
    public partial class Nummer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
    

            migrationBuilder.AddColumn<int>(
                name: "Nummer",
                table: "Mitarbeiter",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nummer",
                table: "Mitarbeiter");

 
        }
    }
}
