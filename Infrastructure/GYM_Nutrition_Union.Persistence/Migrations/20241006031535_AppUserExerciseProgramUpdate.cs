using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Nutrition_Union.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AppUserExerciseProgramUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "AppUsersExerciseProgram",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "DayNo",
                table: "AppUsersExerciseProgram",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "AppUsersExerciseProgram");

            migrationBuilder.DropColumn(
                name: "DayNo",
                table: "AppUsersExerciseProgram");
        }
    }
}
