using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare020.Repository.Migrations
{
    public partial class Removed_TrazenoDatumVreme_from_ZahteviZaPosetu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OdobrenoDatumVreme",
                table: "ZahteviZaPosetu");

            migrationBuilder.DropColumn(
                name: "TrazenoDatumVreme",
                table: "ZahteviZaPosetu");

            migrationBuilder.AddColumn<DateTime>(
                name: "ZakazanoDatumVreme",
                table: "ZahteviZaPosetu",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZakazanoDatumVreme",
                table: "ZahteviZaPosetu");

            migrationBuilder.AddColumn<DateTime>(
                name: "OdobrenoDatumVreme",
                table: "ZahteviZaPosetu",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TrazenoDatumVreme",
                table: "ZahteviZaPosetu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
