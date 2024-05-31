using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationProject.Migrations
{
    /// <inheritdoc />
    public partial class refreshTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRefreshToken_AspNetUsers_AppUserId",
                table: "AppRefreshToken");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "TodoCategories");

            migrationBuilder.DropTable(
                name: "TodoPriorities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppRefreshToken",
                table: "AppRefreshToken");

            migrationBuilder.RenameTable(
                name: "AppRefreshToken",
                newName: "RefreshTokens");

            migrationBuilder.RenameIndex(
                name: "IX_AppRefreshToken_AppUserId",
                table: "RefreshTokens",
                newName: "IX_RefreshTokens_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_AppUserId",
                table: "RefreshTokens",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_AppUserId",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                newName: "AppRefreshToken");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshTokens_AppUserId",
                table: "AppRefreshToken",
                newName: "IX_AppRefreshToken_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppRefreshToken",
                table: "AppRefreshToken",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TodoCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    CategorySort = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoPriorities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PriorityName = table.Column<string>(type: "text", nullable: false),
                    PrioritySort = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoPriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    PriorityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Sort = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_TodoCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TodoCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Todos_TodoPriorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "TodoPriorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_CategoryId",
                table: "Todos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_PriorityId",
                table: "Todos",
                column: "PriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRefreshToken_AspNetUsers_AppUserId",
                table: "AppRefreshToken",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
