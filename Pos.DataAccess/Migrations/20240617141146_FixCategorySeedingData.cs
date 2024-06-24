using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pos.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixCategorySeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryCode",
                keyValue: "202",
                column: "Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryCode",
                keyValue: "203",
                column: "Id",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryCode",
                keyValue: "202",
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryCode",
                keyValue: "203",
                column: "Id",
                value: 1);
        }
    }
}
