 using System.ComponentModel.DataAnnotations.Schema;
 
 namespace brewing.Models
{
    [Table("recipes")]
    public class Recipe
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public string Description {get; set;} =null!;
        public double MaltAmount {get; set;}
        public double HopAmount {get; set; }
        
        public virtual ICollection<Malt>? Malts {get; set;}
        public virtual ICollection<Hop>? Hops {get; set; }
    }
}