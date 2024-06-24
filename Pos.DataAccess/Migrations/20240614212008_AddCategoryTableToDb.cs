using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pos.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameKO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
