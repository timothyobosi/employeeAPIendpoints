using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace empAI.Migrations
{
    /// <inheritdoc />
    public partial class RevertRemoveExtraColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the columns that were added in RemoveExtraColumns
            migrationBuilder.DropColumn(
                name: "Age",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Route",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "location",
                table: "employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // If you need to rollback this migration, you would re-add the columns here.
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "employees",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "employees",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "employees",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Rank",
                table: "employees",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Route",
                table: "employees",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "employees",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "employees",
                type: "longtext",
                nullable: false);
        }
    }

}
