using System.ComponentModel.DataAnnotations.Schema;

namespace brewing.Models
{
    [Table("grain_type")]
    public class GrainType
    {
        public int Id {get;set;}
        public string? Description {get; set;}
    }
}