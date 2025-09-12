using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TravelBlogs.Infrastructure.Migrators.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    TimeRead = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    DestinationId = table.Column<long>(type: "bigint", nullable: false),
                    ThumbnailId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Catalog",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blogs_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalSchema: "External",
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blogs_FileStorages_ThumbnailId",
                        column: x => x.ThumbnailId,
                        principalSchema: "Common",
                        principalTable: "FileStorages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlogAttachments",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    FileStorageId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorId",
                schema: "Catalog",
                table: "Blogs",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                schema: "Catalog",
                table: "Blogs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_DestinationId",
                schema: "Catalog",
                table: "Blogs",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ThumbnailId",
                schema: "Catalog",
                table: "Blogs",
                column: "ThumbnailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogAttachments",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Blogs",
                schema: "Catalog");
        }
    }
}
