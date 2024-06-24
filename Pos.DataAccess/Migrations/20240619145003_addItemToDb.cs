using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pos.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addItemToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameKO",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameEN",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameKO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryCode", "DeptCode", "ItemCode", "NameEN", "NameKO" },
                values: new object[,]
                {
                    { 1, "201", "1", "12010001", "Korean Eggplant", "한국 가지" },
                    { 2, "201", "1", "12010002", "American Eggplant", "미국 가지" },
                    { 3, "202", "1", "12020003", "Idaho Potato", "아이다호 감자" },
                    { 4, "203", "1", "12020004", "Korean Sweet Potato", "한국 고구마" },
                    { 5, "203", "1", "12020005", "American Sweet Potato", "미국 고구마" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "NameKO",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "NameEN",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
