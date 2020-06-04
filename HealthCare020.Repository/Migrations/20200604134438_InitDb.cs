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
                    DateCreated = table.Column<DateTime>(nullable: false),
                    LockedOut = table.Column<bool>(nullable: false),
                    LockedOutUntil = table.Column<DateTime>(nullable: true)
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RolesKorisnickiNalozi_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PacijentiNaLecenju",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StacionarnoOdeljenjeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacijentiNaLecenju", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacijentiNaLecenju_StacionarnaOdeljenja_StacionarnoOdeljenjeId",
                        column: x => x.StacionarnoOdeljenjeId,
                        principalTable: "StacionarnaOdeljenja",
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
                    JMBG = table.Column<string>(maxLength: 12, nullable: false),
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
                name: "Posete",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacijentNaLecenjuId = table.Column<int>(nullable: false),
                    DatumVreme = table.Column<DateTime>(nullable: false),
                    BrojTelefonaPosetioca = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posete_PacijentiNaLecenju_PacijentNaLecenjuId",
                        column: x => x.PacijentNaLecenjuId,
                        principalTable: "PacijentiNaLecenju",
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
                name: "ZdravstvenaKnjizica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicniPodaciId = table.Column<int>(nullable: false),
                    DoktorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdravstvenaKnjizica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZdravstvenaKnjizica_Doktori_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ZdravstvenaKnjizica_LicniPodaci_LicniPodaciId",
                        column: x => x.LicniPodaciId,
                        principalTable: "LicniPodaci",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZdravstvenaKnjizicaId = table.Column<int>(nullable: false),
                    KorisnickiNalogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacijenti_KorisnickiNalozi_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalozi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pacijenti_ZdravstvenaKnjizica_ZdravstvenaKnjizicaId",
                        column: x => x.ZdravstvenaKnjizicaId,
                        principalTable: "ZdravstvenaKnjizica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Uputnice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacijentId = table.Column<int>(nullable: false),
                    UputioDoktorId = table.Column<int>(nullable: false),
                    UpucenKodDoktoraId = table.Column<int>(nullable: false),
                    Razlog = table.Column<string>(nullable: false),
                    Napomena = table.Column<string>(nullable: false),
                    DatumVreme = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uputnice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uputnice_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Uputnice_Doktori_UpucenKodDoktoraId",
                        column: x => x.UpucenKodDoktoraId,
                        principalTable: "Doktori",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Uputnice_Doktori_UputioDoktorId",
                        column: x => x.UputioDoktorId,
                        principalTable: "Doktori",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ZahteviZaPregled",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacijentId = table.Column<int>(nullable: false),
                    DoktorId = table.Column<int>(nullable: false),
                    UputnicaId = table.Column<int>(nullable: true),
                    Napomena = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahteviZaPregled", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZahteviZaPregled_Doktori_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktori",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ZahteviZaPregled_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ZahteviZaPregled_Uputnice_UputnicaId",
                        column: x => x.UputnicaId,
                        principalTable: "Uputnice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Pregledi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZahtevZaPregledId = table.Column<int>(nullable: false),
                    DoktorId = table.Column<int>(nullable: false),
                    PacijentId = table.Column<int>(nullable: false),
                    DatumPregleda = table.Column<DateTime>(nullable: false),
                    IsOdradjen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregledi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pregledi_Doktori_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktori",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pregledi_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pregledi_ZahteviZaPregled_ZahtevZaPregledId",
                        column: x => x.ZahtevZaPregledId,
                        principalTable: "ZahteviZaPregled",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LekarskaUverenja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PregledId = table.Column<int>(nullable: false),
                    ZdravstvenoStanjeId = table.Column<int>(nullable: false),
                    OpisStanja = table.Column<string>(maxLength: 255, nullable: true),
                    DoktorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LekarskaUverenja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LekarskaUverenja_Doktori_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LekarskaUverenja_Pregledi_PregledId",
                        column: x => x.PregledId,
                        principalTable: "Pregledi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LekarskaUverenja_ZdravstvenaStanja_ZdravstvenoStanjeId",
                        column: x => x.ZdravstvenoStanjeId,
                        principalTable: "ZdravstvenaStanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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
                name: "IX_LekarskaUverenja_DoktorId",
                table: "LekarskaUverenja",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_LekarskaUverenja_PregledId",
                table: "LekarskaUverenja",
                column: "PregledId");

            migrationBuilder.CreateIndex(
                name: "IX_LekarskaUverenja_ZdravstvenoStanjeId",
                table: "LekarskaUverenja",
                column: "ZdravstvenoStanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_LicniPodaci_GradId",
                table: "LicniPodaci",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinskiTehnicari_RadnikId",
                table: "MedicinskiTehnicari",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacijenti_KorisnickiNalogId",
                table: "Pacijenti",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacijenti_ZdravstvenaKnjizicaId",
                table: "Pacijenti",
                column: "ZdravstvenaKnjizicaId");

            migrationBuilder.CreateIndex(
                name: "IX_PacijentiNaLecenju_StacionarnoOdeljenjeId",
                table: "PacijentiNaLecenju",
                column: "StacionarnoOdeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Posete_PacijentNaLecenjuId",
                table: "Posete",
                column: "PacijentNaLecenjuId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_DoktorId",
                table: "Pregledi",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_PacijentId",
                table: "Pregledi",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_ZahtevZaPregledId",
                table: "Pregledi",
                column: "ZahtevZaPregledId");

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
                name: "IX_Uputnice_PacijentId",
                table: "Uputnice",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnice_UpucenKodDoktoraId",
                table: "Uputnice",
                column: "UpucenKodDoktoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnice_UputioDoktorId",
                table: "Uputnice",
                column: "UputioDoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaPregled_DoktorId",
                table: "ZahteviZaPregled",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaPregled_PacijentId",
                table: "ZahteviZaPregled",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaPregled_UputnicaId",
                table: "ZahteviZaPregled",
                column: "UputnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdravstvenaKnjizica_DoktorId",
                table: "ZdravstvenaKnjizica",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdravstvenaKnjizica_LicniPodaciId",
                table: "ZdravstvenaKnjizica",
                column: "LicniPodaciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LekarskaUverenja");

            migrationBuilder.DropTable(
                name: "MedicinskiTehnicari");

            migrationBuilder.DropTable(
                name: "Posete");

            migrationBuilder.DropTable(
                name: "RadniciPrijem");

            migrationBuilder.DropTable(
                name: "RolesKorisnickiNalozi");

            migrationBuilder.DropTable(
                name: "Pregledi");

            migrationBuilder.DropTable(
                name: "ZdravstvenaStanja");

            migrationBuilder.DropTable(
                name: "PacijentiNaLecenju");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ZahteviZaPregled");

            migrationBuilder.DropTable(
                name: "Uputnice");

            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "ZdravstvenaKnjizica");

            migrationBuilder.DropTable(
                name: "Doktori");

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
