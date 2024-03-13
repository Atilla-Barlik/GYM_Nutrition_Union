using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Nutrition_Union.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class third_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsersDetail_Exercises_ExerciseId",
                table: "AppUsersDetail");

            migrationBuilder.DropIndex(
                name: "IX_AppUsersDetail_ExerciseId",
                table: "AppUsersDetail");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "AppUsersDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "AppUsersDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsersDetail_ExerciseId",
                table: "AppUsersDetail",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsersDetail_Exercises_ExerciseId",
                table: "AppUsersDetail",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId");
        }
    }
}
