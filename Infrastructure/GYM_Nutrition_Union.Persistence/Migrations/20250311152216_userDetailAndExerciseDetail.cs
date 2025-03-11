using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Nutrition_Union.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userDetailAndExerciseDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BaseMET",
                table: "ExerciseDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AppUsersDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseMET",
                table: "ExerciseDetails");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AppUsersDetail");
        }
    }
}
