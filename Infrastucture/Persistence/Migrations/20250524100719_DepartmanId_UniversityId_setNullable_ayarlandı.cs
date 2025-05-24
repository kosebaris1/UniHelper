using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DepartmanId_UniversityId_setNullable_ayarlandı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questşons_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTags_Questşons_QuestionId",
                table: "QuestionTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Questşons_Departments_DepartmentId",
                table: "Questşons");

            migrationBuilder.DropForeignKey(
                name: "FK_Questşons_Universitites_UniversityId",
                table: "Questşons");

            migrationBuilder.DropForeignKey(
                name: "FK_Questşons_Users_UserId",
                table: "Questşons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questşons",
                table: "Questşons");

            migrationBuilder.RenameTable(
                name: "Questşons",
                newName: "Questions");

            migrationBuilder.RenameIndex(
                name: "IX_Questşons_UserId",
                table: "Questions",
                newName: "IX_Questions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Questşons_UniversityId",
                table: "Questions",
                newName: "IX_Questions_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_Questşons_DepartmentId",
                table: "Questions",
                newName: "IX_Questions_DepartmentId");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Departments_DepartmentId",
                table: "Questions",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Universitites_UniversityId",
                table: "Questions",
                column: "UniversityId",
                principalTable: "Universitites",
                principalColumn: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTags_Questions_QuestionId",
                table: "QuestionTags",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Departments_DepartmentId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Universitites_UniversityId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTags_Questions_QuestionId",
                table: "QuestionTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Questşons");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_UserId",
                table: "Questşons",
                newName: "IX_Questşons_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_UniversityId",
                table: "Questşons",
                newName: "IX_Questşons_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_DepartmentId",
                table: "Questşons",
                newName: "IX_Questşons_DepartmentId");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Questşons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Questşons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questşons",
                table: "Questşons",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questşons_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questşons",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTags_Questşons_QuestionId",
                table: "QuestionTags",
                column: "QuestionId",
                principalTable: "Questşons",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questşons_Departments_DepartmentId",
                table: "Questşons",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questşons_Universitites_UniversityId",
                table: "Questşons",
                column: "UniversityId",
                principalTable: "Universitites",
                principalColumn: "UniversityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questşons_Users_UserId",
                table: "Questşons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
