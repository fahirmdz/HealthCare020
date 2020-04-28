using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare020.Repository.Migrations
{
    public partial class Added_BrojPreostalihPoseta_Column_To_TokenPoseta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolesKorisnickiNalozi_KorisnickiNalozi_KorisnickiNalogId",
                table: "RolesKorisnickiNalozi");

            migrationBuilder.AddColumn<int>(
                name: "BrojPreostalihPoseta",
                table: "TokeniPoseta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RolesKorisnickiNalozi_KorisnickiNalozi_KorisnickiNalogId",
                table: "RolesKorisnickiNalozi",
                column: "KorisnickiNalogId",
                principalTable: "KorisnickiNalozi",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolesKorisnickiNalozi_KorisnickiNalozi_KorisnickiNalogId",
                table: "RolesKorisnickiNalozi");

            migrationBuilder.DropColumn(
                name: "BrojPreostalihPoseta",
                table: "TokeniPoseta");

            migrationBuilder.AddForeignKey(
                name: "FK_RolesKorisnickiNalozi_KorisnickiNalozi_KorisnickiNalogId",
                table: "RolesKorisnickiNalozi",
                column: "KorisnickiNalogId",
                principalTable: "KorisnickiNalozi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
