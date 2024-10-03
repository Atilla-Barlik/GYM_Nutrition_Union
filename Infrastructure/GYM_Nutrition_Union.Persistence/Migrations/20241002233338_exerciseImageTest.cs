using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Nutrition_Union.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class exerciseImageTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExerciseImage",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseImage",
                table: "Exercises");
        }
    }
}
