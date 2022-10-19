using System.ComponentModel.DataAnnotations.Schema;

namespace brewing.Models
{
    [Table("grain_type")]
    public class grainType
    {
        public int Id {get;set;}
        public string? Description {get; set;}
    }
}