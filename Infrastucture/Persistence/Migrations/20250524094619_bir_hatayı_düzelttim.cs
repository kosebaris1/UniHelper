using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class bir_hatayı_düzelttim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Universitites_Universitites_UniversityId1",
                table: "Universitites");

            migrationBuilder.DropIndex(
                name: "IX_Universitites_UniversityId1",
                table: "Universitites");

            migrationBuilder.DropColumn(
                name: "UniversityId1",
                table: "Universitites");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UniversityId1",
                table: "Universitites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universitites_UniversityId1",
                table: "Universitites",
                column: "UniversityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Universitites_Universitites_UniversityId1",
                table: "Universitites",
                column: "UniversityId1",
                principalTable: "Universitites",
                principalColumn: "UniversityId");
        }
    }
}
