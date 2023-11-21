using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracjaTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TestType");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TestType",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TestType",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Testname",
                table: "TestType",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Testname",
                table: "TestType");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TestType",
                newName: "name");

            migrationBuilder.AlterColumn<int>(
                name: "name",
                table: "TestType",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TestType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
