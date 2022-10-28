using System.ComponentModel.DataAnnotations.Schema;

namespace brewing.Models
{
    [Table("malt_color")]
    public class MaltColor
    {
        public int Id {get;set;}
        public string? Color {get; set;}
    }
}