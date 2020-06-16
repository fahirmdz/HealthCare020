using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare020.Repository.Migrations
{
    public partial class Added_EmailAddress_to_LicniPodaci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacijenti_ZdravstvenaKnjizica_ZdravstvenaKnjizicaId",
                table: "Pacijenti");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "LicniPodaci",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacijenti_ZdravstvenaKnjizica_ZdravstvenaKnjizicaId",
                table: "Pacijenti",
                column: "ZdravstvenaKnjizicaId",
                principalTable: "ZdravstvenaKnjizica",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacijenti_ZdravstvenaKnjizica_ZdravstvenaKnjizicaId",
                table: "Pacijenti");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "LicniPodaci");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacijenti_ZdravstvenaKnjizica_ZdravstvenaKnjizicaId",
                table: "Pacijenti",
                column: "ZdravstvenaKnjizicaId",
                principalTable: "ZdravstvenaKnjizica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
