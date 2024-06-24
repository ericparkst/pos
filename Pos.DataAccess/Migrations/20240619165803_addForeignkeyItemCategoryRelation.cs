using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pos.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addForeignkeyItemCategoryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryCode",
                table: "Items",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryCode",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Categories_CategoryCode",
                table: "Categories",
                column: "CategoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryCode",
                table: "Items",
                column: "CategoryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryCode",
                table: "Items",
                column: "CategoryCode",
                principalTable: "Categories",
                principalColumn: "CategoryCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryCode",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryCode",
                table: "Items");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Categories_CategoryCode",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryCode",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryCode",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
