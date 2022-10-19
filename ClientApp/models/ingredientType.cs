using System.ComponentModel.DataAnnotations.Schema;

namespace brewing.Models
{
    [Table("ingredient_type")]
    public class IngredientType
    {
        public int Id {get;set;}
        public string? Description {get; set;}
    }
}