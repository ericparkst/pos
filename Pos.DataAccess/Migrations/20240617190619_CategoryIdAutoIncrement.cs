using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pos.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CategoryIdAutoIncrement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryCode",
                keyValue: "201");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryCode",
                keyValue: "202");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryCode",
                keyValue: "203");

            // Drop the existing Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Categories");

            // Recreate Id column with identity
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryCode",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryCode", "DeptCode", "NameEN", "NameKO" },
                values: new object[,]
                {
            { 1, "201", "1", "Eggplant", "가지류" },
            { 2, "202", "1", "Potato", "감자류" },
            { 3, "203", "1", "Sweet Potato", "고구마류" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            // Drop the existing Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Categories");

            // Recreate Id column without identity
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", false); // Ensure identity is false for down migration

            migrationBuilder.AlterColumn<string>(
                name: "CategoryCode",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryCode");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryCode", "DeptCode", "Id", "NameEN", "NameKO" },
                values: new object[,]
                {
            { "201", "1", 1, "Eggplant", "가지류" },
            { "202", "1", 2, "Potato", "감자류" },
            { "203", "1", 3, "Sweet Potato", "고구마류" }
                });
        }

    }
}
