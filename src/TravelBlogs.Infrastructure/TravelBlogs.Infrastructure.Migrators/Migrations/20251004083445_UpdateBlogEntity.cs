using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBlogs.Infrastructure.Migrators.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBlogEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogAttachments",
                schema: "Catalog");

            migrationBuilder.AlterColumn<int>(
                name: "TimeRead",
                schema: "Catalog",
                table: "Blogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                schema: "Catalog",
                table: "Blogs",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TimeRead",
                schema: "Catalog",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                schema: "Catalog",
                table: "Blogs",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BlogAttachments",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    FileStorageId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogAttachments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalSchema: "Catalog",
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogAttachments_FileStorages_FileStorageId",
                        column: x => x.FileStorageId,
                        principalSchema: "Common",
                        principalTable: "FileStorages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogAttachments_BlogId",
                schema: "Catalog",
                table: "BlogAttachments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogAttachments_FileStorageId",
                schema: "Catalog",
                table: "BlogAttachments",
                column: "FileStorageId");
        }
    }
}
