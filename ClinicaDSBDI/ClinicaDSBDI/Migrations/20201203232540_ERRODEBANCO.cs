using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaDSBDI.Migrations
{
    public partial class ERRODEBANCO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "Consulta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_HospitalId",
                table: "Consulta",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Hospital_HospitalId",
                table: "Consulta",
                column: "HospitalId",
                principalTable: "Hospital",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Hospital_HospitalId",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_HospitalId",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "Consulta");
        }
    }
}
