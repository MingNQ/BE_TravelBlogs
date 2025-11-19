using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBlogs.Infrastructure.Migrators.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "Identity",
                table: "UserVerifications",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ApproverId",
                schema: "Catalog",
                table: "Blogs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RejectorId",
                schema: "Catalog",
                table: "Blogs",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ApproverId",
                schema: "Catalog",
                table: "Blogs",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_RejectorId",
                schema: "Catalog",
                table: "Blogs",
                column: "RejectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_ApproverId",
                schema: "Catalog",
                table: "Blogs",
                column: "ApproverId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_RejectorId",
                schema: "Catalog",
                table: "Blogs",
                column: "RejectorId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_ApproverId",
                schema: "Catalog",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_RejectorId",
                schema: "Catalog",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_ApproverId",
                schema: "Catalog",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_RejectorId",
                schema: "Catalog",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                schema: "Catalog",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "RejectorId",
                schema: "Catalog",
                table: "Blogs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Identity",
                table: "UserVerifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
