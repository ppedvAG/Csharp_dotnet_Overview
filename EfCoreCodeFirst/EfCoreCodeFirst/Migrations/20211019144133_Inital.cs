using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreCodeFirst.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abteilungen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abteilungen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GebDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mitarbeiter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Beruf = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mitarbeiter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mitarbeiter_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbteilungMitarbeiter",
                columns: table => new
                {
                    AbteilungenId = table.Column<int>(type: "int", nullable: false),
                    MitarbeiterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbteilungMitarbeiter", x => new { x.AbteilungenId, x.MitarbeiterId });
                    table.ForeignKey(
                        name: "FK_AbteilungMitarbeiter_Abteilungen_AbteilungenId",
                        column: x => x.AbteilungenId,
                        principalTable: "Abteilungen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbteilungMitarbeiter_Mitarbeiter_MitarbeiterId",
                        column: x => x.MitarbeiterId,
                        principalTable: "Mitarbeiter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kunde",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Kundennummer = table.Column<string>(type: "nvarchar(49)", maxLength: 49, nullable: false),
                    AnsprechpartnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunde", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kunde_Mitarbeiter_AnsprechpartnerId",
                        column: x => x.AnsprechpartnerId,
                        principalTable: "Mitarbeiter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kunde_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbteilungMitarbeiter_MitarbeiterId",
                table: "AbteilungMitarbeiter",
                column: "MitarbeiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Kunde_AnsprechpartnerId",
                table: "Kunde",
                column: "AnsprechpartnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbteilungMitarbeiter");

            migrationBuilder.DropTable(
                name: "Kunde");

            migrationBuilder.DropTable(
                name: "Abteilungen");

            migrationBuilder.DropTable(
                name: "Mitarbeiter");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
