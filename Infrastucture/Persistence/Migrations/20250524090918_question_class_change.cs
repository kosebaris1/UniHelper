using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class question_class_change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Universitites_UniversityId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UniversityId1",
                table: "Universitites",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Questşons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Questşons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Universitites_UniversityId1",
                table: "Universitites",
                column: "UniversityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Questşons_UniversityId",
                table: "Questşons",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Questşons_UserId",
                table: "Questşons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Universitites_Universitites_UniversityId1",
                table: "Universitites",
                column: "UniversityId1",
                principalTable: "Universitites",
                principalColumn: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Universitites_UniversityId",
                table: "Users",
                column: "UniversityId",
                principalTable: "Universitites",
                principalColumn: "UniversityId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questşons_Universitites_UniversityId",
                table: "Questşons");

            migrationBuilder.DropForeignKey(
                name: "FK_Questşons_Users_UserId",
                table: "Questşons");

            migrationBuilder.DropForeignKey(
                name: "FK_Universitites_Universitites_UniversityId1",
                table: "Universitites");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Universitites_UniversityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Universitites_UniversityId1",
                table: "Universitites");

            migrationBuilder.DropIndex(
                name: "IX_Questşons_UniversityId",
                table: "Questşons");

            migrationBuilder.DropIndex(
                name: "IX_Questşons_UserId",
                table: "Questşons");

            migrationBuilder.DropColumn(
                name: "UniversityId1",
                table: "Universitites");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Questşons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Questşons");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Universitites_UniversityId",
                table: "Users",
                column: "UniversityId",
                principalTable: "Universitites",
                principalColumn: "UniversityId");
        }
    }
}
