using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Nutrition_Union.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class second_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUsersBodyDetail",
                columns: table => new
                {
                    AppUserBodyDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Chest = table.Column<int>(type: "int", nullable: false),
                    LeftArm = table.Column<int>(type: "int", nullable: false),
                    RightArm = table.Column<int>(type: "int", nullable: false),
                    Waist = table.Column<int>(type: "int", nullable: false),
                    Hips = table.Column<int>(type: "int", nullable: false),
                    LeftThigh = table.Column<int>(type: "int", nullable: false),
                    RightThigh = table.Column<int>(type: "int", nullable: false),
                    LeftCalf = table.Column<int>(type: "int", nullable: false),
                    RightCalf = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shoulder = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsersBodyDetail", x => x.AppUserBodyDetailId);
                    table.ForeignKey(
                        name: "FK_AppUsersBodyDetail_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUsersDetail",
                columns: table => new
                {
                    AppUserDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BeforeImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AfterImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sex = table.Column<bool>(type: "bit", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsersDetail", x => x.AppUserDetailId);
                    table.ForeignKey(
                        name: "FK_AppUsersDetail_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUsersDetail_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId");
                });

            migrationBuilder.CreateTable(
                name: "AppUsersExerciseProgram",
                columns: table => new
                {
                    AppUserExerciseProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseRepeat = table.Column<int>(type: "int", nullable: false),
                    ExerciseSet = table.Column<int>(type: "int", nullable: false),
                    ExerciseTotalBurnedKcal = table.Column<int>(type: "int", nullable: false),
                    ExerciseDetailId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsersExerciseProgram", x => x.AppUserExerciseProgramId);
                    table.ForeignKey(
                        name: "FK_AppUsersExerciseProgram_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUsersExerciseProgram_ExerciseDetails_ExerciseDetailId",
                        column: x => x.ExerciseDetailId,
                        principalTable: "ExerciseDetails",
                        principalColumn: "ExerciseDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUsersTrainingTime",
                columns: table => new
                {
                    AppUserTrainingTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalTrainingTime = table.Column<int>(type: "int", nullable: false),
                    TotalKcalBurned = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsersTrainingTime", x => x.AppUserTrainingTimeId);
                    table.ForeignKey(
                        name: "FK_AppUsersTrainingTime_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyNutrition",
                columns: table => new
                {
                    DailyNutritionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyNutritionStatus = table.Column<bool>(type: "bit", nullable: false),
                    DailyNutritionTotalKcal = table.Column<int>(type: "int", nullable: false),
                    DailyNutritionTotalCarbohydrate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyNutritionTotalProtein = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyNutritionTotalFat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyNutrition", x => x.DailyNutritionID);
                    table.ForeignKey(
                        name: "FK_DailyNutrition_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUsersBodyMassIndex",
                columns: table => new
                {
                    AppUserBodyMassIndexId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyMassIndex = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeanBodyMass = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BodyFatPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasalMetabolicRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AppUserDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsersBodyMassIndex", x => x.AppUserBodyMassIndexId);
                    table.ForeignKey(
                        name: "FK_AppUsersBodyMassIndex_AppUsersDetail_AppUserDetailId",
                        column: x => x.AppUserDetailId,
                        principalTable: "AppUsersDetail",
                        principalColumn: "AppUserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyNutritionDetails",
                columns: table => new
                {
                    DailyNutritionDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NutrientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutrientImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutrientKcal = table.Column<int>(type: "int", nullable: false),
                    NutrientCarbohydrate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NutrientProtein = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NutrientFat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyNutritionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyNutritionDetails", x => x.DailyNutritionDetailsId);
                    table.ForeignKey(
                        name: "FK_DailyNutritionDetails_DailyNutrition_DailyNutritionId",
                        column: x => x.DailyNutritionId,
                        principalTable: "DailyNutrition",
                        principalColumn: "DailyNutritionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsersBodyDetail_AppUserId",
                table: "AppUsersBodyDetail",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsersBodyMassIndex_AppUserDetailId",
                table: "AppUsersBodyMassIndex",
                column: "AppUserDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsersDetail_AppUserId",
                table: "AppUsersDetail",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsersDetail_ExerciseId",
                table: "AppUsersDetail",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsersExerciseProgram_AppUserId",
                table: "AppUsersExerciseProgram",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsersExerciseProgram_ExerciseDetailId",
                table: "AppUsersExerciseProgram",
                column: "ExerciseDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsersTrainingTime_AppUserId",
                table: "AppUsersTrainingTime",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyNutrition_AppUserId",
                table: "DailyNutrition",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyNutritionDetails_DailyNutritionId",
                table: "DailyNutritionDetails",
                column: "DailyNutritionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsersBodyDetail");

            migrationBuilder.DropTable(
                name: "AppUsersBodyMassIndex");

            migrationBuilder.DropTable(
                name: "AppUsersExerciseProgram");

            migrationBuilder.DropTable(
                name: "AppUsersTrainingTime");

            migrationBuilder.DropTable(
                name: "DailyNutritionDetails");

            migrationBuilder.DropTable(
                name: "AppUsersDetail");

            migrationBuilder.DropTable(
                name: "DailyNutrition");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
