using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Nutrition_Union.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class nutrientTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nutrient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kcal = table.Column<int>(type: "int", nullable: false),
                    carbonhydrate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    protein = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    sugar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fiber = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cholestrol = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    sodium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    potassium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    calcium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    vitamin_A = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    vitamin_C = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    iron = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrient", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nutrient");
        }
    }
}
