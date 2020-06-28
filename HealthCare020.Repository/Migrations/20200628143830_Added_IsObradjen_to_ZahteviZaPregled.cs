using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare020.Repository.Migrations
{
    public partial class Added_IsObradjen_to_ZahteviZaPregled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsObradjen",
                table: "ZahteviZaPregled",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsObradjen",
                table: "ZahteviZaPregled");
        }
    }
}
