using Microsoft.EntityFrameworkCore;
using brewing.Models;


namespace BrewingContext
{
    public class ProjectContext : DbContext
    {
    
        public class BrewingDatabase: DbContext
        {
            protected readonly IConfiguration _configuration;

            public BrewingDatabase(IConfiguration configuration)
            {
                _configuration =configuration;
            }

            public DbSet<Recipe>? Recipes {get; set;}
            public DbSet<Yeast>? Yeasts {get; set;}
            public DbSet<Malt>? Malts {get; set;}
            public DbSet<MaltColor>? MaltColors {get; set;}
            public DbSet<IngredientType>? IngredientTypes {get; set;}
            public DbSet<Hop>? Hops {get; set;}
            public DbSet<GrainType>? GrainTypes {get; set;}
            public DbSet<FlavorType>? FlavorTypes {get; set;}
            
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgreSQL"));
            }
        }
    
    }

}