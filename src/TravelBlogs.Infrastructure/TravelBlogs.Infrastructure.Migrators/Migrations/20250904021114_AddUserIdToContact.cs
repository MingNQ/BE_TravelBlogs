using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBlogs.Infrastructure.Migrators.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_userId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Contacts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_userId",
                table: "Contacts",
                newName: "IX_Contacts_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Contacts",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                newName: "IX_Contacts_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_userId",
                table: "Contacts",
                column: "userId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
