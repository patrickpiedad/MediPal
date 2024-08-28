using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediPal.Migrations
{
    /// <inheritdoc />
    public partial class RemovePatientsFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Patients_PatientID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PatientID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PatientID",
                table: "AspNetUsers",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Patients_PatientID",
                table: "AspNetUsers",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
