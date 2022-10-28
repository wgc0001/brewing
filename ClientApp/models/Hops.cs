using System.ComponentModel.DataAnnotations.Schema;

namespace brewing.Models
{
    [Table("hops")]
    public class Hop
    {
        public int Id {get;set;}
        public string? Description {get; set;}
        public decimal alphaAcid {get;set;}
        public decimal betaAcid {get; set;}
        public int internationalBitteringUnits {get; set;}
        public int IngredientTypeId {get; set;}
        public IngredientType? IngredientType {get; set;}
    }
}