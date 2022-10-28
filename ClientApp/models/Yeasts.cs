 using System.ComponentModel.DataAnnotations.Schema;
 
 namespace brewing.Models
{
    [Table("yeasts")]
    public class Yeast
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public double MinFermentationTemp {get;set;}
        public double MaxFermentationTemp {get; set;}
        public virtual ICollection<Recipe>? Recipes {get; set;}
        public IngredientType? IngredientType {get; set;}
    }
}