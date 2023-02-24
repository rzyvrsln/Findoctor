using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindoctorData.Migrations
{
    public partial class InitialTen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Doctors_DoctorId",
                table: "DoctorPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Patients_PatientId",
                table: "DoctorPatient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient");

            migrationBuilder.RenameTable(
                name: "DoctorPatient",
                newName: "DoctorPatients");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorPatient_PatientId",
                table: "DoctorPatients",
                newName: "IX_DoctorPatients_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorPatient_DoctorId",
                table: "DoctorPatients",
                newName: "IX_DoctorPatients_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorPatients",
                table: "DoctorPatients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatients_Doctors_DoctorId",
                table: "DoctorPatients",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatients_Patients_PatientId",
                table: "DoctorPatients",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatients_Doctors_DoctorId",
                table: "DoctorPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatients_Patients_PatientId",
                table: "DoctorPatients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorPatients",
                table: "DoctorPatients");

            migrationBuilder.RenameTable(
                name: "DoctorPatients",
                newName: "DoctorPatient");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorPatients_PatientId",
                table: "DoctorPatient",
                newName: "IX_DoctorPatient_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorPatients_DoctorId",
                table: "DoctorPatient",
                newName: "IX_DoctorPatient_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Doctors_DoctorId",
                table: "DoctorPatient",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Patients_PatientId",
                table: "DoctorPatient",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
