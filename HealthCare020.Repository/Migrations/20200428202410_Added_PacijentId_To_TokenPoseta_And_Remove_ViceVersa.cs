using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare020.Repository.Migrations
{
    public partial class Added_PacijentId_To_TokenPoseta_And_Remove_ViceVersa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacijenti_TokeniPoseta_TokenPosetaId",
                table: "Pacijenti");

            migrationBuilder.DropIndex(
                name: "IX_Pacijenti_TokenPosetaId",
                table: "Pacijenti");

            migrationBuilder.DropColumn(
                name: "TokenPosetaId",
                table: "Pacijenti");

            migrationBuilder.AddColumn<int>(
                name: "PacijentId",
                table: "TokeniPoseta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TokeniPoseta_PacijentId",
                table: "TokeniPoseta",
                column: "PacijentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TokeniPoseta_Pacijenti_PacijentId",
                table: "TokeniPoseta",
                column: "PacijentId",
                principalTable: "Pacijenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TokeniPoseta_Pacijenti_PacijentId",
                table: "TokeniPoseta");

            migrationBuilder.DropIndex(
                name: "IX_TokeniPoseta_PacijentId",
                table: "TokeniPoseta");

            migrationBuilder.DropColumn(
                name: "PacijentId",
                table: "TokeniPoseta");

            migrationBuilder.AddColumn<int>(
                name: "TokenPosetaId",
                table: "Pacijenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pacijenti_TokenPosetaId",
                table: "Pacijenti",
                column: "TokenPosetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacijenti_TokeniPoseta_TokenPosetaId",
                table: "Pacijenti",
                column: "TokenPosetaId",
                principalTable: "TokeniPoseta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
