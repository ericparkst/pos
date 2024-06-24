using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pos.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RecreateItemTable_re : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(nullable: true),
                    NameEN = table.Column<string>(nullable: false),
                    NameKO = table.Column<string>(nullable: false),
                    DeptCode = table.Column<string>(nullable: true),
                    CategoryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryCode",
                        column: x => x.CategoryCode,
                        principalTable: "Categories",
                        principalColumn: "CategoryCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ItemCode", "NameEN", "NameKO", "DeptCode", "CategoryCode" },
                values: new object[,]
                {
                    { 1, "12010001", "Korean Eggplant", "한국 가지", "1", "201" },
                    { 2, "12010002", "American Eggplant", "미국 가지", "1", "201" },
                    { 3, "12020003", "Idaho Potato", "아이다호 감자", "1", "202" },
                    { 4, "12020004", "Korean Sweet Potato", "한국 고구마", "1", "203" },
                    { 5, "12020005", "American Sweet Potato", "미국 고구마", "1", "203" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryCode",
                table: "Items",
                column: "CategoryCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
