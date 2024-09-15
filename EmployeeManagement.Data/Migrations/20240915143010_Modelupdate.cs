using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class Modelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Departments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignationId",
                table: "Designations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
