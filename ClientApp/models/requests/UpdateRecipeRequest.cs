using System.ComponentModel.DataAnnotations;
using brewing.Models;

namespace brewing.Requests {
   
    public class UpdateRecipeRequest{
        [Required]
        public string? Name {get; set;}
        
        [Required]
        public string? Description {get; set;}
        
        [Required]
        public double MaltAmount {get; set;} 

        [Required]
        public double HopAmount {get; set;}
        public virtual ICollection<Malt>? Malts {get; set;}
        public virtual ICollection<Hop>? Hops {get; set; }

        public DateTime UpdateDate {get; set;} =DateTime.Now;

    }
}