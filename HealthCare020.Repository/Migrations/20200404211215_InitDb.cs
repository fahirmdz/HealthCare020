using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare020.Repository.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzave",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 20, nullable: true),
                    PozivniBroj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzave", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalozi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    LastOnline = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalozi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NaucneOblasti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaucneOblasti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StacionarnaOdeljenja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StacionarnaOdeljenja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TokeniPoseta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokeniPoseta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdravstvenaStanja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdravstvenaStanja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gradovi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 20, nullable: true),
                    DrzavaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gradovi_Drzave_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RolesKorisnickiNalozi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickiNalogId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesKorisnickiNalozi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesKorisnickiNalozi_KorisnickiNalozi_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalozi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RolesKorisnickiNalozi_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LicniPodaci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 15, nullable: false),
                    Prezime = table.Column<string>(maxLength: 15, nullable: false),
                    Adresa = table.Column<string>(maxLength: 30, nullable: false),
                    Pol = table.Column<string>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: false),
                    GradId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicniPodaci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicniPodaci_Gradovi_GradId",
                        column: x => x.GradId,
                        principalTable: "Gradovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicniPodaciId = table.Column<int>(nullable: false),
                    TokenPosetaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacijenti_LicniPodaci_LicniPodaciId",
                        column: x => x.LicniPodaciId,
                        principalTable: "LicniPodaci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pacijenti_TokeniPoseta_TokenPosetaId",
                        column: x => x.TokenPosetaId,
                        principalTable: "TokeniPoseta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Radnici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickiNalogId = table.Column<int>(nullable: false),
                    LicniPodaciId = table.Column<int>(nullable: false),
                    StacionarnoOdeljenjeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radnici_KorisnickiNalozi_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalozi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Radnici_LicniPodaci_LicniPodaciId",
                        column: x => x.LicniPodaciId,
                        principalTable: "LicniPodaci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Radnici_StacionarnaOdeljenja_StacionarnoOdeljenjeId",
                        column: x => x.StacionarnoOdeljenjeId,
                        principalTable: "StacionarnaOdeljenja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Posete",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosetiocIme = table.Column<string>(maxLength: 15, nullable: true),
                    PosetiocPrezime = table.Column<string>(maxLength: 15, nullable: true),
                    DatumVreme = table.Column<DateTime>(nullable: false),
                    PacijentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posete_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Doktori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RadnikId = table.Column<int>(nullable: false),
                    NaucnaOblastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doktori_NaucneOblasti_NaucnaOblastId",
                        column: x => x.NaucnaOblastId,
                        principalTable: "NaucneOblasti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Doktori_Radnici_RadnikId",
                        column: x => x.RadnikId,
                        principalTable: "Radnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MedicinskiTehnicari",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RadnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinskiTehnicari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicinskiTehnicari_Radnici_RadnikId",
                        column: x => x.RadnikId,
                        principalTable: "Radnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RadniciPrijem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RadnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadniciPrijem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadniciPrijem_Radnici_RadnikId",
                        column: x => x.RadnikId,
                        principalTable: "Radnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UputiZaLecenje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpisStanja = table.Column<string>(maxLength: 250, nullable: false),
                    DatumVreme = table.Column<DateTime>(nullable: false),
                    LicniPodaciId = table.Column<int>(nullable: false),
                    DoktorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UputiZaLecenje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UputiZaLecenje_Doktori_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UputiZaLecenje_LicniPodaci_LicniPodaciId",
                        column: x => x.LicniPodaciId,
                        principalTable: "LicniPodaci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CustomIzvestaji",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelesnaTemperatura = table.Column<double>(nullable: false),
                    KrvniPritisakGornji = table.Column<int>(nullable: false),
                    KrvniPritisakDonji = table.Column<int>(nullable: false),
                    GlukozaUKrvi = table.Column<double>(nullable: false),
                    DatumVreme = table.Column<DateTime>(nullable: false),
                    MedicinskiTehnicarId = table.Column<int>(nullable: false),
                    PacijentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomIzvestaji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomIzvestaji_MedicinskiTehnicari_MedicinskiTehnicarId",
                        column: x => x.MedicinskiTehnicarId,
                        principalTable: "MedicinskiTehnicari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CustomIzvestaji_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DnevniIzvestaji",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpisStanja = table.Column<string>(maxLength: 250, nullable: false),
                    DatumVreme = table.Column<DateTime>(nullable: false),
                    ZdravstvenoStanjeId = table.Column<int>(nullable: false),
                    MedicinskiTehnicarId = table.Column<int>(nullable: false),
                    PacijentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DnevniIzvestaji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DnevniIzvestaji_MedicinskiTehnicari_MedicinskiTehnicarId",
                        column: x => x.MedicinskiTehnicarId,
                        principalTable: "MedicinskiTehnicari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DnevniIzvestaji_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DnevniIzvestaji_ZdravstvenaStanja_ZdravstvenoStanjeId",
                        column: x => x.ZdravstvenoStanjeId,
                        principalTable: "ZdravstvenaStanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomIzvestaji_MedicinskiTehnicarId",
                table: "CustomIzvestaji",
                column: "MedicinskiTehnicarId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomIzvestaji_PacijentId",
                table: "CustomIzvestaji",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_DnevniIzvestaji_MedicinskiTehnicarId",
                table: "DnevniIzvestaji",
                column: "MedicinskiTehnicarId");

            migrationBuilder.CreateIndex(
                name: "IX_DnevniIzvestaji_PacijentId",
                table: "DnevniIzvestaji",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_DnevniIzvestaji_ZdravstvenoStanjeId",
                table: "DnevniIzvestaji",
                column: "ZdravstvenoStanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktori_NaucnaOblastId",
                table: "Doktori",
                column: "NaucnaOblastId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktori_RadnikId",
                table: "Doktori",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Gradovi_DrzavaId",
                table: "Gradovi",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_LicniPodaci_GradId",
                table: "LicniPodaci",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinskiTehnicari_RadnikId",
                table: "MedicinskiTehnicari",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacijenti_LicniPodaciId",
                table: "Pacijenti",
                column: "LicniPodaciId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacijenti_TokenPosetaId",
                table: "Pacijenti",
                column: "TokenPosetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Posete_PacijentId",
                table: "Posete",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Radnici_KorisnickiNalogId",
                table: "Radnici",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Radnici_LicniPodaciId",
                table: "Radnici",
                column: "LicniPodaciId");

            migrationBuilder.CreateIndex(
                name: "IX_Radnici_StacionarnoOdeljenjeId",
                table: "Radnici",
                column: "StacionarnoOdeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_RadniciPrijem_RadnikId",
                table: "RadniciPrijem",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesKorisnickiNalozi_KorisnickiNalogId",
                table: "RolesKorisnickiNalozi",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesKorisnickiNalozi_RoleId",
                table: "RolesKorisnickiNalozi",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UputiZaLecenje_DoktorId",
                table: "UputiZaLecenje",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_UputiZaLecenje_LicniPodaciId",
                table: "UputiZaLecenje",
                column: "LicniPodaciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomIzvestaji");

            migrationBuilder.DropTable(
                name: "DnevniIzvestaji");

            migrationBuilder.DropTable(
                name: "Posete");

            migrationBuilder.DropTable(
                name: "RadniciPrijem");

            migrationBuilder.DropTable(
                name: "RolesKorisnickiNalozi");

            migrationBuilder.DropTable(
                name: "UputiZaLecenje");

            migrationBuilder.DropTable(
                name: "MedicinskiTehnicari");

            migrationBuilder.DropTable(
                name: "ZdravstvenaStanja");

            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Doktori");

            migrationBuilder.DropTable(
                name: "TokeniPoseta");

            migrationBuilder.DropTable(
                name: "NaucneOblasti");

            migrationBuilder.DropTable(
                name: "Radnici");

            migrationBuilder.DropTable(
                name: "KorisnickiNalozi");

            migrationBuilder.DropTable(
                name: "LicniPodaci");

            migrationBuilder.DropTable(
                name: "StacionarnaOdeljenja");

            migrationBuilder.DropTable(
                name: "Gradovi");

            migrationBuilder.DropTable(
                name: "Drzave");
        }
    }
}
