using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare020.Repository.Migrations
{
    public partial class Added_LockedOut_LockedOutUntil_In_korisnickoNalog_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LockedOut",
                table: "KorisnickiNalozi",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LockedOutUntil",
                table: "KorisnickiNalozi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LockedOut",
                table: "KorisnickiNalozi");

            migrationBuilder.DropColumn(
                name: "LockedOutUntil",
                table: "KorisnickiNalozi");
        }
    }
}
