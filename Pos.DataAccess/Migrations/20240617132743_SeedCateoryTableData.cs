using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pos.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCateoryTableData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryCode", "DeptCode", "Id", "NameEN", "NameKO" },
                values: new object[,]
                {
                    { "201", "1", 1, "Eggplant", "가지류" },
                    { "202", "1", 1, "Potato", "감자류" },
                    { "203", "1", 1, "Sweet Potato", "고구마류" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
