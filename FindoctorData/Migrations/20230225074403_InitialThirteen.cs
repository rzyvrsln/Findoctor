using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindoctorData.Migrations
{
    public partial class InitialThirteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "View",
                table: "Doctors",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "View",
                table: "Doctors");
        }
    }
}
