using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Week7.OrsolaLiccardo.Esercitazione.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CodiceFiscale = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CodiceFiscale);
                });

            migrationBuilder.CreateTable(
                name: "Polizza",
                columns: table => new
                {
                    numeroPolizza = table.Column<int>(type: "int", fixedLength: true, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataStipula = table.Column<DateTime>(type: "DateTime", nullable: false),
                    importoAssicurato = table.Column<double>(type: "float", nullable: false),
                    rataMensile = table.Column<double>(type: "float", nullable: false),
                    CodiceFiscale = table.Column<string>(type: "nchar(16)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PercentuelCoperta = table.Column<int>(type: "int", nullable: true),
                    Targa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cilindrata = table.Column<int>(type: "int", nullable: true),
                    AnniAssicurato = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizza", x => x.numeroPolizza);
                    table.ForeignKey(
                        name: "FK_Polizza_Cliente_CodiceFiscale",
                        column: x => x.CodiceFiscale,
                        principalTable: "Cliente",
                        principalColumn: "CodiceFiscale",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Polizza_CodiceFiscale",
                table: "Polizza",
                column: "CodiceFiscale");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polizza");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
