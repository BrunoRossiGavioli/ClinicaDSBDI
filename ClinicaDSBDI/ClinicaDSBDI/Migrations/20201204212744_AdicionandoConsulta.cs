using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaDSBDI.Migrations
{
    public partial class AdicionandoConsulta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(nullable: false),
                    DataDaConsulta = table.Column<DateTime>(nullable: false),
                    HorarioDaConsulta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_AnimalId",
                table: "Consulta",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");
        }
    }
}
