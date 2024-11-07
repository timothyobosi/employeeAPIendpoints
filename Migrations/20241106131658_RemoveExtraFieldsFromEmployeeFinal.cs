using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace empAI.Migrations
{
    public partial class RemoveExtraFieldsFromEmployeeFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Remove the unwanted columns
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Route",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "location",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Optionally, re-add the columns if the migration is rolled back
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "Employees",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "Employees",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Rank",
                table: "Employees",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Route",
                table: "Employees",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Employees",
                type: "double",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "Employees",
                type: "longtext",
                nullable: false);
        }
    }
}
