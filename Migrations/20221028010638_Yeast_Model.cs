using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace brewing.Migrations
{
    /// <inheritdoc />
    public partial class YeastModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "hops",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaltId",
                table: "flavor_type",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "malt_color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Color = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_malt_color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MaltAmount = table.Column<double>(type: "double precision", nullable: false),
                    HopAmount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "malts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ExtractPercentage = table.Column<decimal>(type: "numeric", nullable: false),
                    MaxGrainUsage = table.Column<decimal>(type: "numeric", nullable: false),
                    DiastaticPower = table.Column<int>(type: "integer", nullable: false),
                    GrainTypeId = table.Column<int>(type: "integer", nullable: true),
                    IngredientTypeId = table.Column<int>(type: "integer", nullable: true),
                    RecipeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_malts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_malts_grain_type_GrainTypeId",
                        column: x => x.GrainTypeId,
                        principalTable: "grain_type",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_malts_ingredient_type_IngredientTypeId",
                        column: x => x.IngredientTypeId,
                        principalTable: "ingredient_type",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_malts_recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_hops_RecipeId",
                table: "hops",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_flavor_type_MaltId",
                table: "flavor_type",
                column: "MaltId");

            migrationBuilder.CreateIndex(
                name: "IX_malts_GrainTypeId",
                table: "malts",
                column: "GrainTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_malts_IngredientTypeId",
                table: "malts",
                column: "IngredientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_malts_RecipeId",
                table: "malts",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_flavor_type_malts_MaltId",
                table: "flavor_type",
                column: "MaltId",
                principalTable: "malts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_hops_recipes_RecipeId",
                table: "hops",
                column: "RecipeId",
                principalTable: "recipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flavor_type_malts_MaltId",
                table: "flavor_type");

            migrationBuilder.DropForeignKey(
                name: "FK_hops_recipes_RecipeId",
                table: "hops");

            migrationBuilder.DropTable(
                name: "malt_color");

            migrationBuilder.DropTable(
                name: "malts");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropIndex(
                name: "IX_hops_RecipeId",
                table: "hops");

            migrationBuilder.DropIndex(
                name: "IX_flavor_type_MaltId",
                table: "flavor_type");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "hops");

            migrationBuilder.DropColumn(
                name: "MaltId",
                table: "flavor_type");
        }
    }
}
