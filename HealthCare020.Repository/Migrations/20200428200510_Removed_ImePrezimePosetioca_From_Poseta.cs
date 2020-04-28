using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare020.Repository.Migrations
{
    public partial class Removed_ImePrezimePosetioca_From_Poseta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosetiocIme",
                table: "Posete");

            migrationBuilder.DropColumn(
                name: "PosetiocPrezime",
                table: "Posete");

            migrationBuilder.AlterColumn<int>(
                name: "PacijentId",
                table: "Posete",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TokenPosetaId",
                table: "Posete",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posete_TokenPosetaId",
                table: "Posete",
                column: "TokenPosetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posete_TokeniPoseta_TokenPosetaId",
                table: "Posete",
                column: "TokenPosetaId",
                principalTable: "TokeniPoseta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posete_TokeniPoseta_TokenPosetaId",
                table: "Posete");

            migrationBuilder.DropIndex(
                name: "IX_Posete_TokenPosetaId",
                table: "Posete");

            migrationBuilder.DropColumn(
                name: "TokenPosetaId",
                table: "Posete");

            migrationBuilder.AlterColumn<int>(
                name: "PacijentId",
                table: "Posete",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosetiocIme",
                table: "Posete",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosetiocPrezime",
                table: "Posete",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }
    }
}
