using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Nutrition_Union.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class avgKcalDailyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvgKcalDailyResults",
                columns: table => new
                {
                    AvgKcalDailyResultsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    DailyMacro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BurnKcal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyTakenKcal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResultKcal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvgKcalDailyResults", x => x.AvgKcalDailyResultsId);
                    table.ForeignKey(
                        name: "FK_AvgKcalDailyResults_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvgKcalDailyResults_AppUserId",
                table: "AvgKcalDailyResults",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvgKcalDailyResults");
        }
    }
}
