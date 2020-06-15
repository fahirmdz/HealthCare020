using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare020.Repository.Migrations
{
    public partial class Added_LicniPodaci_to_PacijentiNaLecenju : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LicniPodaciId",
                table: "PacijentiNaLecenju",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PacijentiNaLecenju_LicniPodaciId",
                table: "PacijentiNaLecenju",
                column: "LicniPodaciId");

            migrationBuilder.AddForeignKey(
                name: "FK_PacijentiNaLecenju_LicniPodaci_LicniPodaciId",
                table: "PacijentiNaLecenju",
                column: "LicniPodaciId",
                principalTable: "LicniPodaci",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacijentiNaLecenju_LicniPodaci_LicniPodaciId",
                table: "PacijentiNaLecenju");

            migrationBuilder.DropIndex(
                name: "IX_PacijentiNaLecenju_LicniPodaciId",
                table: "PacijentiNaLecenju");

            migrationBuilder.DropColumn(
                name: "LicniPodaciId",
                table: "PacijentiNaLecenju");
        }
    }
}
