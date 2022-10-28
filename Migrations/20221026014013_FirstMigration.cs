using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace brewing.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "flavor_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Flavor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flavor_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "grain_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grain_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingredient_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    alphaAcid = table.Column<decimal>(type: "numeric", nullable: false),
                    betaAcid = table.Column<decimal>(type: "numeric", nullable: false),
                    internationalBitteringUnits = table.Column<int>(type: "integer", nullable: false),
                    IngredientTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hops_ingredient_type_IngredientTypeId",
                        column: x => x.IngredientTypeId,
                        principalTable: "ingredient_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hops_IngredientTypeId",
                table: "hops",
                column: "IngredientTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flavor_type");

            migrationBuilder.DropTable(
                name: "grain_type");

            migrationBuilder.DropTable(
                name: "hops");

            migrationBuilder.DropTable(
                name: "ingredient_type");
        }
    }
}
