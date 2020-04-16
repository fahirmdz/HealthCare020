using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare020.Repository.Migrations
{
    public partial class Added_JMBG_Column_To_LicniPodaci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomIzvestaji_MedicinskiTehnicari_MedicinskiTehnicarId",
                table: "CustomIzvestaji");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomIzvestaji_Pacijenti_PacijentId",
                table: "CustomIzvestaji");

            migrationBuilder.DropForeignKey(
                name: "FK_DnevniIzvestaji_MedicinskiTehnicari_MedicinskiTehnicarId",
                table: "DnevniIzvestaji");

            migrationBuilder.DropForeignKey(
                name: "FK_DnevniIzvestaji_Pacijenti_PacijentId",
                table: "DnevniIzvestaji");

            migrationBuilder.DropForeignKey(
                name: "FK_Gradovi_Drzave_DrzavaId",
                table: "Gradovi");

            migrationBuilder.DropForeignKey(
                name: "FK_Posete_Pacijenti_PacijentId",
                table: "Posete");

            migrationBuilder.DropForeignKey(
                name: "FK_UputiZaLecenje_Doktori_DoktorId",
                table: "UputiZaLecenje");

            migrationBuilder.AddColumn<string>(
                name: "JMBG",
                table: "LicniPodaci",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomIzvestaji_MedicinskiTehnicari_MedicinskiTehnicarId",
                table: "CustomIzvestaji",
                column: "MedicinskiTehnicarId",
                principalTable: "MedicinskiTehnicari",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomIzvestaji_Pacijenti_PacijentId",
                table: "CustomIzvestaji",
                column: "PacijentId",
                principalTable: "Pacijenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DnevniIzvestaji_MedicinskiTehnicari_MedicinskiTehnicarId",
                table: "DnevniIzvestaji",
                column: "MedicinskiTehnicarId",
                principalTable: "MedicinskiTehnicari",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DnevniIzvestaji_Pacijenti_PacijentId",
                table: "DnevniIzvestaji",
                column: "PacijentId",
                principalTable: "Pacijenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gradovi_Drzave_DrzavaId",
                table: "Gradovi",
                column: "DrzavaId",
                principalTable: "Drzave",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posete_Pacijenti_PacijentId",
                table: "Posete",
                column: "PacijentId",
                principalTable: "Pacijenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UputiZaLecenje_Doktori_DoktorId",
                table: "UputiZaLecenje",
                column: "DoktorId",
                principalTable: "Doktori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomIzvestaji_MedicinskiTehnicari_MedicinskiTehnicarId",
                table: "CustomIzvestaji");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomIzvestaji_Pacijenti_PacijentId",
                table: "CustomIzvestaji");

            migrationBuilder.DropForeignKey(
                name: "FK_DnevniIzvestaji_MedicinskiTehnicari_MedicinskiTehnicarId",
                table: "DnevniIzvestaji");

            migrationBuilder.DropForeignKey(
                name: "FK_DnevniIzvestaji_Pacijenti_PacijentId",
                table: "DnevniIzvestaji");

            migrationBuilder.DropForeignKey(
                name: "FK_Gradovi_Drzave_DrzavaId",
                table: "Gradovi");

            migrationBuilder.DropForeignKey(
                name: "FK_Posete_Pacijenti_PacijentId",
                table: "Posete");

            migrationBuilder.DropForeignKey(
                name: "FK_UputiZaLecenje_Doktori_DoktorId",
                table: "UputiZaLecenje");

            migrationBuilder.DropColumn(
                name: "JMBG",
                table: "LicniPodaci");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomIzvestaji_MedicinskiTehnicari_MedicinskiTehnicarId",
                table: "CustomIzvestaji",
                column: "MedicinskiTehnicarId",
                principalTable: "MedicinskiTehnicari",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomIzvestaji_Pacijenti_PacijentId",
                table: "CustomIzvestaji",
                column: "PacijentId",
                principalTable: "Pacijenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DnevniIzvestaji_MedicinskiTehnicari_MedicinskiTehnicarId",
                table: "DnevniIzvestaji",
                column: "MedicinskiTehnicarId",
                principalTable: "MedicinskiTehnicari",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DnevniIzvestaji_Pacijenti_PacijentId",
                table: "DnevniIzvestaji",
                column: "PacijentId",
                principalTable: "Pacijenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gradovi_Drzave_DrzavaId",
                table: "Gradovi",
                column: "DrzavaId",
                principalTable: "Drzave",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posete_Pacijenti_PacijentId",
                table: "Posete",
                column: "PacijentId",
                principalTable: "Pacijenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UputiZaLecenje_Doktori_DoktorId",
                table: "UputiZaLecenje",
                column: "DoktorId",
                principalTable: "Doktori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
