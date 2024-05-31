using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationProject.Migrations
{
    /// <inheritdoc />
    public partial class typoWithGrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInSubject_Grades_FinalGradeIdId",
                table: "UsersInSubject");

            migrationBuilder.RenameColumn(
                name: "FinalGradeIdId",
                table: "UsersInSubject",
                newName: "GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInSubject_FinalGradeIdId",
                table: "UsersInSubject",
                newName: "IX_UsersInSubject_GradeId");

            migrationBuilder.AddColumn<Guid>(
                name: "FinalGradeId",
                table: "UsersInSubject",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInSubject_Grades_GradeId",
                table: "UsersInSubject",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInSubject_Grades_GradeId",
                table: "UsersInSubject");

            migrationBuilder.DropColumn(
                name: "FinalGradeId",
                table: "UsersInSubject");

            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "UsersInSubject",
                newName: "FinalGradeIdId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInSubject_GradeId",
                table: "UsersInSubject",
                newName: "IX_UsersInSubject_FinalGradeIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInSubject_Grades_FinalGradeIdId",
                table: "UsersInSubject",
                column: "FinalGradeIdId",
                principalTable: "Grades",
                principalColumn: "Id");
        }
    }
}
