using Microsoft.EntityFrameworkCore;
using brewing.Models;


namespace BrewingContext
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            
        }
         public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
            {

            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost;Database=brewing_database;port =5432; Username =postgres; password=fiji1848");
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.UseSerialColumns();
            }
        public DbSet<FlavorType>? FlavorTypes {get; set;}
        public DbSet<GrainType>? GrainTypes {get; set;}
        public DbSet<Hop>? Hops {get; set;}
        public DbSet<IngredientType>? IngredientTypes {get; set;}
        public DbSet<MaltColor>? MaltColors {get; set;}
        public DbSet<Malt>? Malts {get; set;}
        public DbSet<Recipe> Recipes {get; set;}
    }
}