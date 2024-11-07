using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace empAI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveExtraFieldsFromEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Location",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Location",
                table: "Employees",
                type: "longtext",
                nullable: false);
        }
    }

}
