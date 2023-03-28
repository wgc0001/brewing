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
                name: "grain_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "malt_color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Color = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_malt_color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "yeasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MinFermentationTemp = table.Column<double>(type: "double precision", nullable: false),
                    MaxFermentationTemp = table.Column<double>(type: "double precision", nullable: false),
                    IngredientTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yeasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_yeasts_ingredient_type_IngredientTypeId",
                        column: x => x.IngredientTypeId,
                        principalTable: "ingredient_type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    MaltAmount = table.Column<double>(type: "double precision", nullable: false),
                    HopAmount = table.Column<double>(type: "double precision", nullable: false),
                    YeastId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recipes_yeasts_YeastId",
                        column: x => x.YeastId,
                        principalTable: "yeasts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "hops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    alphaAcid = table.Column<decimal>(type: "numeric", nullable: false),
                    betaAcid = table.Column<decimal>(type: "numeric", nullable: false),
                    internationalBitteringUnits = table.Column<int>(type: "integer", nullable: false),
                    IngredientTypeId = table.Column<int>(type: "integer", nullable: false),
                    RecipeId = table.Column<int>(type: "integer", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_hops_recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "malts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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

            migrationBuilder.CreateTable(
                name: "flavor_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Flavor = table.Column<string>(type: "text", nullable: true),
                    MaltId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flavor_type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_flavor_type_malts_MaltId",
                        column: x => x.MaltId,
                        principalTable: "malts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_flavor_type_MaltId",
                table: "flavor_type",
                column: "MaltId");

            migrationBuilder.CreateIndex(
                name: "IX_hops_IngredientTypeId",
                table: "hops",
                column: "IngredientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_hops_RecipeId",
                table: "hops",
                column: "RecipeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_recipes_YeastId",
                table: "recipes",
                column: "YeastId");

            migrationBuilder.CreateIndex(
                name: "IX_yeasts_IngredientTypeId",
                table: "yeasts",
                column: "IngredientTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flavor_type");

            migrationBuilder.DropTable(
                name: "hops");

            migrationBuilder.DropTable(
                name: "malt_color");

            migrationBuilder.DropTable(
                name: "malts");

            migrationBuilder.DropTable(
                name: "grain_type");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "yeasts");

            migrationBuilder.DropTable(
                name: "ingredient_type");
        }
    }
}
