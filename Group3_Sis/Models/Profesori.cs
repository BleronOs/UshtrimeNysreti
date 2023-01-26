using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3_Sis.Models
{
    [Table("Profesori")]
    public class Profesori
    {
        public int Id { get; set; }
        [Required]
        public string Emri { get; set; }
        [Required]
        public string Mbiemri { get; set; }
    }
}
