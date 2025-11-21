using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBlogs.Infrastructure.Migrators.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                schema: "Catalog",
                table: "Blogs");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                schema: "Catalog",
                table: "Blogs",
                column: "CategoryId",
                principalSchema: "Catalog",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                schema: "Catalog",
                table: "Blogs");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                schema: "Catalog",
                table: "Blogs",
                column: "CategoryId",
                principalSchema: "Catalog",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
