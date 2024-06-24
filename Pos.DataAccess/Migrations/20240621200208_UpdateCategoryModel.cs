using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pos.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DepartmentId", "Description", "ImageUrl" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DepartmentId", "Description", "ImageUrl" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DepartmentId", "Description", "ImageUrl" },
                values: new object[] { null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DepartmentId",
                table: "Categories",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Departments_DepartmentId",
                table: "Categories",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Departments_DepartmentId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DepartmentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Categories");
        }
    }
}
