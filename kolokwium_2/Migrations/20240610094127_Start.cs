using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kolokwium_2.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beverage",
                columns: table => new
                {
                    IdBeverage = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Beverage_pk", x => x.IdBeverage);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IdIngredient = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NonAlcoholic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Ingredient_pk", x => x.IdIngredient);
                });

            migrationBuilder.CreateTable(
                name: "BeverageIngredient",
                columns: table => new
                {
                    IdBeverage = table.Column<int>(type: "int", nullable: false),
                    IdIngredient = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BeverageIngredient_pk", x => new { x.IdBeverage, x.IdIngredient });
                    table.ForeignKey(
                        name: "BecerageIngredient_Beverage",
                        column: x => x.IdBeverage,
                        principalTable: "Beverage",
                        principalColumn: "IdBeverage",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "BecerageIngredient_Ingredient",
                        column: x => x.IdIngredient,
                        principalTable: "Ingredient",
                        principalColumn: "IdIngredient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Beverage",
                columns: new[] { "IdBeverage", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Lemoniada", 4.5m },
                    { 2, "Wudka", 7.99m },
                    { 3, "Sok z gumijagudek", 15.3m }
                });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "IdIngredient", "Name", "NonAlcoholic" },
                values: new object[,]
                {
                    { 1, "Cytryna", true },
                    { 2, "Nie pamietam co", false },
                    { 3, "Gumijagoda", false }
                });

            migrationBuilder.InsertData(
                table: "BeverageIngredient",
                columns: new[] { "IdBeverage", "IdIngredient", "Amount" },
                values: new object[,]
                {
                    { 1, 1, "20" },
                    { 2, 2, "15" },
                    { 3, 3, "10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeverageIngredient_IdIngredient",
                table: "BeverageIngredient",
                column: "IdIngredient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeverageIngredient");

            migrationBuilder.DropTable(
                name: "Beverage");

            migrationBuilder.DropTable(
                name: "Ingredient");
        }
    }
}
