using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare020.Repository.Migrations
{
    public partial class Replaced_MedicinskiTehnicar_With_Doktor_In_DnevniIzvestaj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DnevniIzvestaji_MedicinskiTehnicari_MedicinskiTehnicarId",
                table: "DnevniIzvestaji");

            migrationBuilder.DropIndex(
                name: "IX_DnevniIzvestaji_MedicinskiTehnicarId",
                table: "DnevniIzvestaji");

            migrationBuilder.DropColumn(
                name: "MedicinskiTehnicarId",
                table: "DnevniIzvestaji");

            migrationBuilder.AddColumn<int>(
                name: "DoktorId",
                table: "DnevniIzvestaji",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DnevniIzvestaji_DoktorId",
                table: "DnevniIzvestaji",
                column: "DoktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DnevniIzvestaji_Doktori_DoktorId",
                table: "DnevniIzvestaji",
                column: "DoktorId",
                principalTable: "Doktori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DnevniIzvestaji_Doktori_DoktorId",
                table: "DnevniIzvestaji");

            migrationBuilder.DropIndex(
                name: "IX_DnevniIzvestaji_DoktorId",
                table: "DnevniIzvestaji");

            migrationBuilder.DropColumn(
                name: "DoktorId",
                table: "DnevniIzvestaji");

            migrationBuilder.AddColumn<int>(
                name: "MedicinskiTehnicarId",
                table: "DnevniIzvestaji",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DnevniIzvestaji_MedicinskiTehnicarId",
                table: "DnevniIzvestaji",
                column: "MedicinskiTehnicarId");

            migrationBuilder.AddForeignKey(
                name: "FK_DnevniIzvestaji_MedicinskiTehnicari_MedicinskiTehnicarId",
                table: "DnevniIzvestaji",
                column: "MedicinskiTehnicarId",
                principalTable: "MedicinskiTehnicari",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
