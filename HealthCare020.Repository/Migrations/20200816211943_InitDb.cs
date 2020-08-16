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
                    FaceId = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
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
                name: "LicniPodaci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 20, nullable: false),
                    Prezime = table.Column<string>(maxLength: 20, nullable: false),
                    JMBG = table.Column<string>(maxLength: 12, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Adresa = table.Column<string>(maxLength: 30, nullable: false),
                    Pol = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: false),
                    GradId = table.Column<int>(nullable: false),
                    ProfilePicture = table.Column<byte[]>(nullable: true)
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
                name: "PacijentiNaLecenju",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicniPodaciId = table.Column<int>(nullable: false),
                    StacionarnoOdeljenjeId = table.Column<int>(nullable: false),
                    BrojSobe = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacijentiNaLecenju", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacijentiNaLecenju_LicniPodaci_LicniPodaciId",
                        column: x => x.LicniPodaciId,
                        principalTable: "LicniPodaci",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PacijentiNaLecenju_StacionarnaOdeljenja_StacionarnoOdeljenjeId",
                        column: x => x.StacionarnoOdeljenjeId,
                        principalTable: "StacionarnaOdeljenja",
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
                name: "ZahteviZaPosetu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacijentNaLecenjuId = table.Column<int>(nullable: false),
                    DatumVremeKreiranja = table.Column<DateTime>(nullable: false),
                    ZakazanoDatumVreme = table.Column<DateTime>(nullable: true),
                    IsObradjen = table.Column<bool>(nullable: false),
                    BrojTelefonaPosetioca = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahteviZaPosetu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZahteviZaPosetu_PacijentiNaLecenju_PacijentNaLecenjuId",
                        column: x => x.PacijentNaLecenjuId,
                        principalTable: "PacijentiNaLecenju",
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
                        principalColumn: "Id");
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
                    Napomena = table.Column<string>(nullable: true),
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
                    DatumVreme = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(maxLength: 255, nullable: false),
                    IsObradjen = table.Column<bool>(nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
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
                    VrijemePregledaUid = table.Column<long>(nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "Id", "Naziv", "PozivniBroj" },
                values: new object[,]
                {
                    { 1, "Bosna i Hercegovina", "387" },
                    { 2, "Srbija", "381" },
                    { 3, "Crna Gora", "382" }
                });

            migrationBuilder.InsertData(
                table: "KorisnickiNalozi",
                columns: new[] { "Id", "DateCreated", "FaceId", "LastOnline", "LockedOut", "LockedOutUntil", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[,]
                {
                    { 16, new DateTime(2020, 4, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(7110), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(7114), false, null, "XQGkmyhLdSuKkotbqLmNvaAWoOl0ASKCDWTrkplrSdw08AP1JFHzR5yH3y09dE0n/l1YAmYuD2L6poF64WbmrA==", "YeO593QvyX33ISCRJKJKFw==", "pacijent11" },
                    { 15, new DateTime(2020, 4, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(7081), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(7085), false, null, "iemAcmH305fw7smSernvSx/S+uY+Oj/ykGrOEAe7piCfAotic7OzycjJvOHC2A6qCtlvswLM7z0bIYDg596SKA==", "CxsMsjV2YKnC9ILmPAL2VQ==", "pacijent10" },
                    { 14, new DateTime(2020, 6, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(7053), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(7057), false, null, "pTssS464IN5Sp97ulAXtaSY1AJgiEMmDLdFq7jusWWtRITsFxAs2kX35uSkk+WByYB9TYj2cpDXceDH1S2VEDg==", "ftRPU4KpaRl9kIIaV9RWHA==", "pacijent9" },
                    { 13, new DateTime(2020, 6, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(7024), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(7028), false, null, "Mr8MGTow/UWr3s0Xxa2cBr2/XZyF7AfkBkZG8O5evEOz3LTDVIInid1d4U6F64ILGEuuUH1w4ARl3dcBl0+g0w==", "mkVqGI8oxf/kLamHeoGBKQ==", "pacijent8" },
                    { 12, new DateTime(2020, 7, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6968), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6998), false, null, "mOU8tSAR6srd9gL8Ca/D2pY6z18Wfuatf6aG1kwyXBWuIdL2sTDVNTjgb1hyX//LQBDUia7+vHF/zkhpbR6yhg==", "RgEs7OahRGDt4uD1Sz9AwQ==", "pacijent7" },
                    { 11, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6940), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6944), false, null, "a3FFgcrii2/tJguUpIeiByNNTwqyLv7V0XMKoOuQNliRv038lXmfoA7JlvAZWE8SPPQbq6+R2Xl/8i4kNEbxug==", "nKebXrUqnT9nuQvopcJhXw==", "pacijent6" },
                    { 10, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6888), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6891), false, null, "B7QkuuUQRTretggCXMwXzorQrGMFV4jxDy6RiTIRtr8AoFO0Ax5+x9A3+0c9spsZNwxDi1eu3041dBucaw8Rzg==", "K2S5f8XDrT45/kL6KN5Uyw==", "pacijent5" },
                    { 9, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6858), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6861), false, null, "MPv23zJH32gaq4eg31kQWh03Y3c64Gs/hCC8zHhFi8lV2gcbbbcoFVqgEZZV9DWQcCkpZxQGn/9T1QkMav+auw==", "vcJl/s4FVgK4eRnGzeUeFA==", "pacijent4" },
                    { 8, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6812), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6816), false, null, "5vnJS+az6ofCHGC/ftsC3qKDDA9P+zmUMe8oOlYHG89Vvfsr/C4guLe9BxWRr9HcSoewRKSXulY8KobG+iiP+g==", "IaI82Nkz+GUZYhrrCOtq8g==", "pacijent3" },
                    { 7, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6785), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6788), false, null, "NNp+aaIvYRTFPh/R8J3XRchCfKMrQr6pQcJB71TsnFTBYK4MHDi9UmlfyE7Hbuezb6XxsF4ygU1Lg0qvMFeIBw==", "iajqnBG+Wr/AmeH5g/HJCQ==", "pacijent2" },
                    { 6, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6757), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6760), false, null, "7nYe6cwHlFIx6NiY7PfT6rakig9M6l3wuOI1Gfz9O9/vXrAAFCJQONyK/IQ+ZGNvx93BFo1L6NpC+BcFVcQ5jQ==", "beuy+nmSTVb/Ip5HGZVDXg==", "doktor2" },
                    { 5, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6728), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6731), false, null, "c5xghhbG8tDfTeaf1+J8Se+o/IQ8fyxwWI3auWE/12YFHgHvPAsskRFihNbCklolnhCUiaZRY4xMBu3P9/esJw==", "b1/8iNZLP1IaB+D1B3OUSQ==", "medicinskitehnicar" },
                    { 4, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6698), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6702), false, null, "3FXd+GEud1oiiorvbKVeSps3r0CYQ09n4FHVY91WtnFMKumBfm5z9ohnxLMfCTd//zlzmX+JHKXD59Mbgy0+KQ==", "iY2NjlgzhqdTU23hmiZ0+A==", "pacijent" },
                    { 3, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6656), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6662), false, null, "tNbjarghbR5SEeS4HxCcnINt9NhObdIlTzLW9fhRtS6MNULHw4LLy2AWqNwTyblqWnVr/VpkJjUnR3wd90BtqA==", "YJdBUgkwrm8l3bz3y1g14w==", "radnikprijem" },
                    { 2, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6325), null, new DateTime(2020, 8, 16, 23, 19, 42, 590, DateTimeKind.Local).AddTicks(6349), false, null, "EtejxuT8onWPEsyIKavD4k8GdGun2scA0V4JNlyxcV6oKw5HkGcEzEIHJ2TDo96wUjqjhYyRhP8NM33bm/xnFA==", "fBIhqQ1z2Akj5HDTqfPTMw==", "doktor" },
                    { 1, new DateTime(2020, 8, 16, 23, 19, 42, 588, DateTimeKind.Local).AddTicks(4903), null, new DateTime(2020, 8, 16, 23, 19, 42, 588, DateTimeKind.Local).AddTicks(5557), false, null, "iPJ5vFIsAGKcK9HrpZMAnR+BBQZBd7GTzFExGl5SYRPpyOG0gNdbE+gRYObnVUCOwSApOZ3YJeAi+W7czi2Bpg==", "UqPQpoPgauVaAn8NWweDvA==", "admin" }
                });

            migrationBuilder.InsertData(
                table: "NaucneOblasti",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 6, "Fizijatrija" },
                    { 5, "Kardiologija" },
                    { 4, "Reumatologija" },
                    { 1, "Hirurgija" },
                    { 2, "Endokrinologija" },
                    { 3, "Neurohirurgija" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Doktor" },
                    { 3, "MedicinckiTehnicar" },
                    { 4, "RadnikPrijem" },
                    { 5, "Pacijent" }
                });

            migrationBuilder.InsertData(
                table: "StacionarnaOdeljenja",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Hiruško" },
                    { 2, "Plućno" },
                    { 3, "Ortopedijsko" },
                    { 4, "Koronarno" }
                });

            migrationBuilder.InsertData(
                table: "ZdravstvenaStanja",
                columns: new[] { "Id", "Opis" },
                values: new object[,]
                {
                    { 4, "Otežano" },
                    { 1, "Odlično" },
                    { 2, "Dobro" },
                    { 3, "Pod kontrolom" },
                    { 5, "Loše" }
                });

            migrationBuilder.InsertData(
                table: "Gradovi",
                columns: new[] { "Id", "DrzavaId", "Naziv" },
                values: new object[,]
                {
                    { 1, 1, "Sarajevo" },
                    { 12, 3, "Budva" },
                    { 11, 3, "Podgorica" },
                    { 10, 2, "Kraljevo" },
                    { 9, 2, "Subotica" },
                    { 8, 2, "Novi Sad" },
                    { 13, 3, "Tivat" },
                    { 6, 2, "Novi Pazar" },
                    { 5, 1, "Goražde" },
                    { 4, 1, "Visoko" },
                    { 3, 1, "Zenica" },
                    { 2, 1, "Mostar" },
                    { 7, 2, "Beograd" }
                });

            migrationBuilder.InsertData(
                table: "RolesKorisnickiNalozi",
                columns: new[] { "Id", "KorisnickiNalogId", "RoleId" },
                values: new object[,]
                {
                    { 12, 5, 5 },
                    { 15, 4, 5 },
                    { 19, 6, 5 },
                    { 20, 7, 5 },
                    { 21, 8, 5 },
                    { 24, 11, 5 },
                    { 23, 10, 5 },
                    { 25, 12, 5 },
                    { 26, 13, 5 },
                    { 27, 14, 5 },
                    { 9, 2, 5 },
                    { 22, 9, 5 },
                    { 5, 1, 5 },
                    { 17, 6, 3 },
                    { 14, 3, 4 },
                    { 11, 5, 4 },
                    { 8, 2, 4 },
                    { 4, 1, 4 },
                    { 28, 15, 5 },
                    { 10, 5, 3 },
                    { 7, 2, 3 },
                    { 3, 1, 3 },
                    { 16, 6, 2 },
                    { 6, 2, 2 },
                    { 2, 1, 2 },
                    { 1, 1, 1 },
                    { 18, 6, 4 },
                    { 29, 16, 5 }
                });

            migrationBuilder.InsertData(
                table: "LicniPodaci",
                columns: new[] { "Id", "Adresa", "BrojTelefona", "DatumRodjenja", "EmailAddress", "GradId", "Ime", "JMBG", "Pol", "Prezime", "ProfilePicture" },
                values: new object[,]
                {
                    { 1, "Gradacacka 10", "0624322123", new DateTime(1980, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(418), "doktor1@live.com", 1, "Fahir", "010202001", "M", "Dokt", null },
                    { 4, "Seiz 10", "064322233", new DateTime(1970, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2087), "medtehnicar1@live.com", 5, "Fahir", "1475856888", "M", "Tehnicar", null },
                    { 19, "Lumbago 100", "0624234123", new DateTime(1966, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2176), "pacijent21@live.com", 4, "Fahir", "9874563211", "M", "Pacdvajedan", null },
                    { 3, "Alojza Benca 10", "067231222", new DateTime(1973, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2081), "pacijent1@live.com", 4, "Fahir", "013475855", "M", "Pacijent", null },
                    { 12, "Topolska 18", "06585524", new DateTime(1979, 9, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2142), "pacijent7@live.com", 3, "Fahir", "84575856999", "M", "Pacsest", null },
                    { 10, "Leur 91", "06585524", new DateTime(1993, 8, 31, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2117), "pacijent5@live.com", 3, "Fahir", "2557766355", "M", "Paccetiri", null },
                    { 5, "Helst 12", "06123233", new DateTime(1991, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2092), "doktor2@live.com", 3, "Fahir", "1154651655", "M", "Doktdva", null },
                    { 18, "Sarajevska 100", "0624745855", new DateTime(1996, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2172), "pacijent20@live.com", 2, "Fahir", "1234567891", "M", "Pacdvadeset", null },
                    { 9, "Reu 17", "0612323333", new DateTime(1993, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2112), "pacijent4@live.com", 5, "Fahir", "25111020201", "M", "Pactri", null },
                    { 17, "Sarajevska 25", "068575853", new DateTime(1985, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2166), "pacijent12@live.com", 2, "Fahir", "8352121332", "M", "Pacjedanaest", null },
                    { 15, "Bosanskih gazija 9", "065234121", new DateTime(1956, 7, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2156), "pacijent10@live.com", 2, "Fahir", "2557766355", "M", "Pacdevet", null },
                    { 14, "Reu 12", "06585524", new DateTime(1956, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2152), "pacijent9@live.com", 2, "Fahir", "2551876355", "M", "Pacosam", null },
                    { 11, "Reu 12", "060365955", new DateTime(1979, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2138), "pacijent6@live.com", 2, "Fahir", "2574214855", "M", "Pacpet", null },
                    { 8, "Golubacka 12", "063412333", new DateTime(1993, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2108), "pacijent3@live.com", 2, "Fahir", "2534123332", "M", "Pacdva", null },
                    { 7, "Reu 12", "06585524", new DateTime(1966, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2103), "pacijentlecenje2@live.com", 2, "Fahir", "2557766355", "M", "Lecenjedva", null },
                    { 6, "Neumsd 12", "066585255", new DateTime(1996, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2098), "pacijentlecenje1@live.com", 2, "Fahir", "7584247777", "M", "Lecenje", null },
                    { 2, "Envera Seh 10", "062414322", new DateTime(1988, 8, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2037), "prijem1@live.com", 2, "Fahir", "013412333", "M", "Prijem", null },
                    { 16, "Frau Hermanova 2", "0625485477", new DateTime(1956, 5, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2161), "pacijent11@live.com", 2, "Fahir", "8422222211", "M", "Pacdeset", null },
                    { 13, "Envera Sehovica 19", "0675845555", new DateTime(1979, 5, 16, 23, 19, 42, 591, DateTimeKind.Local).AddTicks(2147), "pacijent8@live.com", 5, "Fahir", "85442222222", "M", "Pacsedam", null }
                });

            migrationBuilder.InsertData(
                table: "PacijentiNaLecenju",
                columns: new[] { "Id", "BrojSobe", "LicniPodaciId", "StacionarnoOdeljenjeId" },
                values: new object[,]
                {
                    { 1, 16, 6, 1 },
                    { 2, 16, 7, 1 }
                });

            migrationBuilder.InsertData(
                table: "Radnici",
                columns: new[] { "Id", "KorisnickiNalogId", "LicniPodaciId", "StacionarnoOdeljenjeId" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 3, 2, 1 },
                    { 4, 6, 5, 2 },
                    { 3, 5, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Doktori",
                columns: new[] { "Id", "NaucnaOblastId", "RadnikId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "MedicinskiTehnicari",
                columns: new[] { "Id", "RadnikId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "RadniciPrijem",
                columns: new[] { "Id", "RadnikId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "ZahteviZaPosetu",
                columns: new[] { "Id", "BrojTelefonaPosetioca", "DatumVremeKreiranja", "IsObradjen", "PacijentNaLecenjuId", "ZakazanoDatumVreme" },
                values: new object[,]
                {
                    { 1, "066985295", new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Local), true, 1, new DateTime(2020, 8, 11, 14, 30, 0, 0, DateTimeKind.Local) },
                    { 2, "066585777", new DateTime(2020, 8, 12, 23, 19, 42, 593, DateTimeKind.Local).AddTicks(3407), false, 2, null }
                });

            migrationBuilder.InsertData(
                table: "ZdravstvenaKnjizica",
                columns: new[] { "Id", "DoktorId", "LicniPodaciId" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 1, 8 },
                    { 3, 1, 9 },
                    { 4, 1, 10 },
                    { 5, 1, 11 },
                    { 6, 1, 12 },
                    { 7, 1, 13 },
                    { 8, 1, 14 },
                    { 9, 1, 15 },
                    { 10, 1, 16 },
                    { 11, 1, 17 },
                    { 12, 1, 18 },
                    { 13, 1, 19 }
                });

            migrationBuilder.InsertData(
                table: "Pacijenti",
                columns: new[] { "Id", "KorisnickiNalogId", "ZdravstvenaKnjizicaId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 7, 2 },
                    { 3, 8, 3 },
                    { 4, 9, 4 },
                    { 5, 10, 5 },
                    { 6, 11, 6 },
                    { 7, 12, 7 },
                    { 8, 13, 8 },
                    { 9, 14, 9 },
                    { 10, 15, 10 },
                    { 11, 16, 11 }
                });

            migrationBuilder.InsertData(
                table: "Uputnice",
                columns: new[] { "Id", "DatumVreme", "Napomena", "PacijentId", "Razlog", "UpucenKodDoktoraId", "UputioDoktorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 15, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(8668), "Pregledati urnarni trakt", 1, "Mucnina u stomaku", 2, 1 },
                    { 2, new DateTime(2020, 8, 15, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(9471), "Pregledati glavu", 1, "Bol u slepoocnici", 1, 2 },
                    { 3, new DateTime(2020, 8, 15, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(9497), "Pregledati urnarni trakt", 2, "Mucnina u stomaku", 2, 1 },
                    { 4, new DateTime(2020, 8, 15, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(9501), "Pregledati urnarni trakt", 2, "Mucnina u stomaku", 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ZahteviZaPregled",
                columns: new[] { "Id", "DatumVreme", "DoktorId", "IsObradjen", "Napomena", "PacijentId", "UputnicaId" },
                values: new object[,]
                {
                    { 20, new DateTime(2020, 8, 14, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2716), 1, false, "Blagi bolovi u zeludcu", 8, null },
                    { 18, new DateTime(2020, 8, 14, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2710), 2, false, "Blagi bolovi u zeludcu", 8, null },
                    { 14, new DateTime(2020, 7, 19, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2693), 2, true, "Blagi bolovi u ramenu", 8, null },
                    { 13, new DateTime(2020, 6, 16, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2689), 2, true, "Blagi bolovi u zeludcu", 7, null },
                    { 12, new DateTime(2020, 6, 16, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2685), 2, true, "Bolovi u stomaku", 6, null },
                    { 11, new DateTime(2020, 5, 16, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2681), 2, true, "Peckanje u ocima", 5, null },
                    { 10, new DateTime(2020, 7, 16, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2678), 2, true, "Blagi bolovi u grudima", 4, null },
                    { 9, new DateTime(2020, 6, 16, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2673), 1, true, "Blagi bolovi u slepoocnici", 3, null },
                    { 19, new DateTime(2020, 8, 14, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2713), 1, false, "Blagi bolovi u stomaku", 2, null },
                    { 8, new DateTime(2020, 6, 16, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2669), 1, true, "Blagi bolovi u vratu", 2, null },
                    { 15, new DateTime(2020, 6, 25, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2697), 2, true, "Blagi bolovi u ocima", 9, null },
                    { 7, new DateTime(2020, 4, 16, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2665), 1, true, "Bolovi u glavi", 2, null },
                    { 6, new DateTime(2019, 12, 16, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2660), 1, true, "Blagi bolovi u grudima", 1, null },
                    { 5, new DateTime(2020, 4, 16, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2655), 1, true, "Razredjena krv", 1, null },
                    { 4, new DateTime(2020, 6, 16, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2651), 1, true, "Problemi sa radom srca", 1, null },
                    { 3, new DateTime(2020, 7, 16, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2645), 1, true, "Problemi sa disanjem", 1, null },
                    { 2, new DateTime(2020, 8, 13, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2613), 1, false, "Problemi sa mokraćnim kanalima", 1, null },
                    { 1, new DateTime(2020, 8, 14, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(1592), 1, true, "Otežano disanje", 1, null },
                    { 17, new DateTime(2020, 8, 14, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2705), 2, false, "Blagi bolovi u stomaku", 2, null },
                    { 16, new DateTime(2020, 6, 16, 23, 19, 42, 592, DateTimeKind.Local).AddTicks(2701), 2, true, "Blagi bolovi u ceonom dijelu", 10, null }
                });

            migrationBuilder.InsertData(
                table: "Pregledi",
                columns: new[] { "Id", "DatumPregleda", "DoktorId", "IsOdradjen", "PacijentId", "VrijemePregledaUid", "ZahtevZaPregledId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 12, 10, 0, 0, 0, DateTimeKind.Local), 1, true, 1, 2L, 1 },
                    { 2, new DateTime(2020, 6, 13, 10, 0, 0, 0, DateTimeKind.Local), 1, true, 1, 2L, 3 },
                    { 3, new DateTime(2020, 6, 14, 10, 0, 0, 0, DateTimeKind.Local), 1, true, 1, 2L, 4 },
                    { 4, new DateTime(2020, 6, 15, 10, 0, 0, 0, DateTimeKind.Local), 1, true, 1, 2L, 5 },
                    { 5, new DateTime(2020, 6, 16, 10, 0, 0, 0, DateTimeKind.Local), 1, true, 1, 2L, 6 },
                    { 6, new DateTime(2020, 7, 18, 12, 0, 0, 0, DateTimeKind.Local), 1, true, 2, 6L, 7 },
                    { 7, new DateTime(2020, 7, 18, 12, 0, 0, 0, DateTimeKind.Local), 1, true, 2, 6L, 8 },
                    { 8, new DateTime(2020, 7, 18, 12, 0, 0, 0, DateTimeKind.Local), 1, true, 3, 6L, 9 },
                    { 9, new DateTime(2020, 7, 18, 12, 0, 0, 0, DateTimeKind.Local), 2, true, 4, 6L, 10 },
                    { 10, new DateTime(2020, 7, 18, 14, 0, 0, 0, DateTimeKind.Local), 2, true, 5, 10L, 11 },
                    { 11, new DateTime(2020, 7, 18, 14, 0, 0, 0, DateTimeKind.Local), 2, true, 6, 10L, 12 },
                    { 12, new DateTime(2020, 7, 18, 14, 0, 0, 0, DateTimeKind.Local), 2, true, 7, 10L, 13 },
                    { 13, new DateTime(2020, 7, 18, 15, 0, 0, 0, DateTimeKind.Local), 2, true, 8, 12L, 14 },
                    { 14, new DateTime(2020, 7, 18, 15, 0, 0, 0, DateTimeKind.Local), 2, true, 9, 12L, 15 },
                    { 15, new DateTime(2020, 7, 18, 15, 0, 0, 0, DateTimeKind.Local), 2, true, 10, 12L, 16 }
                });

            migrationBuilder.InsertData(
                table: "LekarskaUverenja",
                columns: new[] { "Id", "DoktorId", "OpisStanja", "PregledId", "ZdravstvenoStanjeId" },
                values: new object[,]
                {
                    { 1, null, "Stanje je za sada pod kontrolom", 1, 3 },
                    { 2, null, "Test opis", 2, 2 },
                    { 3, null, "Stanje je za sada pod kontrolom", 3, 3 },
                    { 4, null, "Stanje je za sada pod kontrolom", 4, 3 },
                    { 5, null, "Stanje je za sada pod kontrolom", 5, 3 }
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
                name: "IX_PacijentiNaLecenju_LicniPodaciId",
                table: "PacijentiNaLecenju",
                column: "LicniPodaciId");

            migrationBuilder.CreateIndex(
                name: "IX_PacijentiNaLecenju_StacionarnoOdeljenjeId",
                table: "PacijentiNaLecenju",
                column: "StacionarnoOdeljenjeId");

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
                name: "IX_ZahteviZaPosetu_PacijentNaLecenjuId",
                table: "ZahteviZaPosetu",
                column: "PacijentNaLecenjuId");

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
                name: "RadniciPrijem");

            migrationBuilder.DropTable(
                name: "RolesKorisnickiNalozi");

            migrationBuilder.DropTable(
                name: "ZahteviZaPosetu");

            migrationBuilder.DropTable(
                name: "Pregledi");

            migrationBuilder.DropTable(
                name: "ZdravstvenaStanja");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "PacijentiNaLecenju");

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
