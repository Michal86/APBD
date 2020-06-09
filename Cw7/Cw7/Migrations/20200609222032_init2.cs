using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw7.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienie_WyrobCukierniczy_Zamowienie_ZamowienieIdKlient_ZamowienieIdPracownik",
                table: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienie_WyrobCukierniczy_ZamowienieIdKlient_ZamowienieIdPracownik",
                table: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zamowienie",
                table: "Zamowienie");

            migrationBuilder.DropColumn(
                name: "ZamowienieIdKlient",
                table: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.DropColumn(
                name: "ZamowienieIdPracownik",
                table: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.AddColumn<int>(
                name: "ZamowienieIdZamowienia",
                table: "Zamowienie_WyrobCukierniczy",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdZamowienia",
                table: "Zamowienie",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zamowienie",
                table: "Zamowienie",
                column: "IdZamowienia");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_WyrobCukierniczy_ZamowienieIdZamowienia",
                table: "Zamowienie_WyrobCukierniczy",
                column: "ZamowienieIdZamowienia");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdKlient",
                table: "Zamowienie",
                column: "IdKlient");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienie_WyrobCukierniczy_Zamowienie_ZamowienieIdZamowienia",
                table: "Zamowienie_WyrobCukierniczy",
                column: "ZamowienieIdZamowienia",
                principalTable: "Zamowienie",
                principalColumn: "IdZamowienia",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienie_WyrobCukierniczy_Zamowienie_ZamowienieIdZamowienia",
                table: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienie_WyrobCukierniczy_ZamowienieIdZamowienia",
                table: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zamowienie",
                table: "Zamowienie");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienie_IdKlient",
                table: "Zamowienie");

            migrationBuilder.DropColumn(
                name: "ZamowienieIdZamowienia",
                table: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.AddColumn<int>(
                name: "ZamowienieIdKlient",
                table: "Zamowienie_WyrobCukierniczy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZamowienieIdPracownik",
                table: "Zamowienie_WyrobCukierniczy",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdZamowienia",
                table: "Zamowienie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zamowienie",
                table: "Zamowienie",
                columns: new[] { "IdKlient", "IdPracownik" });

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_WyrobCukierniczy_ZamowienieIdKlient_ZamowienieIdPracownik",
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "ZamowienieIdKlient", "ZamowienieIdPracownik" });

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienie_WyrobCukierniczy_Zamowienie_ZamowienieIdKlient_ZamowienieIdPracownik",
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "ZamowienieIdKlient", "ZamowienieIdPracownik" },
                principalTable: "Zamowienie",
                principalColumns: new[] { "IdKlient", "IdPracownik" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
