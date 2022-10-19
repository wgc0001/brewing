using System.ComponentModel.DataAnnotations.Schema;

namespace brewing.Models
{
   [Table("flavor_type")]
    public class FlavorType
    {
        public int Id {get;set;}
        public string? Flavor {get; set;}
    }
}