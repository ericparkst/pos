using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pos.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDepartmentTableData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptCode", "NameEN", "NameKO" },
                values: new object[,]
                {
                    { 1, "1", "Produce", "청과" },
                    { 2, "2", "Fish", "수산" },
                    { 3, "3", "Meat", "정육" },
                    { 4, "4", "Deli", "델리" },
                    { 5, "5", "Houseware", "하우스웨어" },
                    { 6, "6", "Grocery", "그로서리" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
