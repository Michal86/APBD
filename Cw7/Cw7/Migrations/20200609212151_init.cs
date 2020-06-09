using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw7.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    IdKlient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(maxLength: 50, nullable: true),
                    Nazwisko = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.IdKlient);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    IdPracownik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(maxLength: 50, nullable: true),
                    Nazwisko = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.IdPracownik);
                });

            migrationBuilder.CreateTable(
                name: "WyrobCukierniczy",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 200, nullable: true),
                    CenaZaSzt = table.Column<float>(nullable: false),
                    Typ = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WyrobCukierniczy", x => x.IdWyrobuCukierniczego);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    IdKlient = table.Column<int>(nullable: false),
                    IdPracownik = table.Column<int>(nullable: false),
                    IdZamowienia = table.Column<int>(nullable: false),
                    DataPrzyjecia = table.Column<DateTime>(nullable: false),
                    DataRealizacji = table.Column<DateTime>(nullable: false),
                    Uwagi = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => new { x.IdKlient, x.IdPracownik });
                    table.ForeignKey(
                        name: "FK_Zamowienie_Klient_IdKlient",
                        column: x => x.IdKlient,
                        principalTable: "Klient",
                        principalColumn: "IdKlient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Pracownicy_IdPracownik",
                        column: x => x.IdPracownik,
                        principalTable: "Pracownicy",
                        principalColumn: "IdPracownik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie_WyrobCukierniczy",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(nullable: false),
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false),
                    ZamowienieIdKlient = table.Column<int>(nullable: true),
                    ZamowienieIdPracownik = table.Column<int>(nullable: true),
                    WyrobCukierniczyIdWyrobuCukierniczego = table.Column<int>(nullable: true),
                    Ilosc = table.Column<int>(nullable: false),
                    Uwagi = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie_WyrobCukierniczy", x => new { x.IdWyrobuCukierniczego, x.IdZamowienia });
                    table.ForeignKey(
                        name: "FK_Zamowienie_WyrobCukierniczy_WyrobCukierniczy_WyrobCukierniczyIdWyrobuCukierniczego",
                        column: x => x.WyrobCukierniczyIdWyrobuCukierniczego,
                        principalTable: "WyrobCukierniczy",
                        principalColumn: "IdWyrobuCukierniczego",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zamowienie_WyrobCukierniczy_Zamowienie_ZamowienieIdKlient_ZamowienieIdPracownik",
                        columns: x => new { x.ZamowienieIdKlient, x.ZamowienieIdPracownik },
                        principalTable: "Zamowienie",
                        principalColumns: new[] { "IdKlient", "IdPracownik" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdPracownik",
                table: "Zamowienie",
                column: "IdPracownik");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_WyrobCukierniczy_WyrobCukierniczyIdWyrobuCukierniczego",
                table: "Zamowienie_WyrobCukierniczy",
                column: "WyrobCukierniczyIdWyrobuCukierniczego");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_WyrobCukierniczy_ZamowienieIdKlient_ZamowienieIdPracownik",
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "ZamowienieIdKlient", "ZamowienieIdPracownik" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.DropTable(
                name: "WyrobCukierniczy");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "Pracownicy");
        }
    }
}
