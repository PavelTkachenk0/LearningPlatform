using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningPlatform.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItem_Content_CatItemId",
                table: "CategoryItem");

            migrationBuilder.DropIndex(
                name: "IX_CategoryItem_CatItemId",
                table: "CategoryItem");

            migrationBuilder.DropColumn(
                name: "CatItemId",
                table: "CategoryItem");

            migrationBuilder.CreateIndex(
                name: "IX_Content_CatItemId",
                table: "Content",
                column: "CatItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_CategoryItem_CatItemId",
                table: "Content",
                column: "CatItemId",
                principalTable: "CategoryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_CategoryItem_CatItemId",
                table: "Content");

            migrationBuilder.DropIndex(
                name: "IX_Content_CatItemId",
                table: "Content");

            migrationBuilder.AddColumn<int>(
                name: "CatItemId",
                table: "CategoryItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_CatItemId",
                table: "CategoryItem",
                column: "CatItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItem_Content_CatItemId",
                table: "CategoryItem",
                column: "CatItemId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
