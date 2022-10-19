 namespace brewing.Models
{
    public class Malts
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public decimal ExtractPercentage {get;set;}
        public decimal MaxGrainUsage {get; set;}
        public int DiastaticPower {get; set;}
        public grainType? GrainType {get; set;}
        public virtual ICollection<FlavorType>? FlavorType {get; set;}
        public IngredientType? IngredientType {get; set;}
    }
}