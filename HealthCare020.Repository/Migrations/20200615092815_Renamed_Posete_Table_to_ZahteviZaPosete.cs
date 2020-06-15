using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare020.Repository.Migrations
{
    public partial class Renamed_Posete_Table_to_ZahteviZaPosete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posete");

            migrationBuilder.CreateTable(
                name: "ZahteviZaPosetu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacijentNaLecenjuId = table.Column<int>(nullable: false),
                    DatumVreme = table.Column<DateTime>(nullable: false),
                    BrojTelefonaPosetioca = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahteviZaPosetu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZahteviZaPosetu_PacijentiNaLecenju_PacijentNaLecenjuId",
                        column: x => x.PacijentNaLecenjuId,
                        principalTable: "PacijentiNaLecenju",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaPosetu_PacijentNaLecenjuId",
                table: "ZahteviZaPosetu",
                column: "PacijentNaLecenjuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZahteviZaPosetu");

            migrationBuilder.CreateTable(
                name: "Posete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojTelefonaPosetioca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumVreme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacijentNaLecenjuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posete_PacijentiNaLecenju_PacijentNaLecenjuId",
                        column: x => x.PacijentNaLecenjuId,
                        principalTable: "PacijentiNaLecenju",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posete_PacijentNaLecenjuId",
                table: "Posete",
                column: "PacijentNaLecenjuId");
        }
    }
}
