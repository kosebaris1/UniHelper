using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addQuestionLike_Düzeltme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionLike_Questions_QuestionId",
                table: "QuestionLike");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionLike_Users_UserId",
                table: "QuestionLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionLike",
                table: "QuestionLike");

            migrationBuilder.RenameTable(
                name: "QuestionLike",
                newName: "QuestionLikes");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionLike_QuestionId",
                table: "QuestionLikes",
                newName: "IX_QuestionLikes_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionLikes",
                table: "QuestionLikes",
                columns: new[] { "UserId", "QuestionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionLikes_Questions_QuestionId",
                table: "QuestionLikes",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionLikes_Users_UserId",
                table: "QuestionLikes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionLikes_Questions_QuestionId",
                table: "QuestionLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionLikes_Users_UserId",
                table: "QuestionLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionLikes",
                table: "QuestionLikes");

            migrationBuilder.RenameTable(
                name: "QuestionLikes",
                newName: "QuestionLike");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionLikes_QuestionId",
                table: "QuestionLike",
                newName: "IX_QuestionLike_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionLike",
                table: "QuestionLike",
                columns: new[] { "UserId", "QuestionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionLike_Questions_QuestionId",
                table: "QuestionLike",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionLike_Users_UserId",
                table: "QuestionLike",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
