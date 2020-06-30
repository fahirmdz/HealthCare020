using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare020.Repository.Migrations
{
    public partial class Added_OdobrenoDatumVreme_to_ZahtevZaPosetu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumVreme",
                table: "ZahteviZaPosetu");

            migrationBuilder.AddColumn<DateTime>(
                name: "OdobrenoDatumVreme",
                table: "ZahteviZaPosetu",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TrazenoDatumVreme",
                table: "ZahteviZaPosetu",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OdobrenoDatumVreme",
                table: "ZahteviZaPosetu");

            migrationBuilder.DropColumn(
                name: "TrazenoDatumVreme",
                table: "ZahteviZaPosetu");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumVreme",
                table: "ZahteviZaPosetu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
