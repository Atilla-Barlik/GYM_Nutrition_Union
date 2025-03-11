using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Nutrition_Union.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AppUserBodyDetailUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "AppUsersBodyDetail",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "AppUsersBodyDetail",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
