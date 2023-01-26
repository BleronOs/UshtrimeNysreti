using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Group3_Sis.Models
{
    [Table("Student")]
    public class Studenti
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ju lutem shtypeni emrin")]
        public string Emri { get; set; }
        [Required(ErrorMessage = "Ju lutem shtypeni mbiemrin")]
        public string Mbiemri { get; set; }
        [Required(ErrorMessage = "Ju lutem zgjidhni komunen")]
        [Range(1,30,ErrorMessage = "Specifikoni komunen")]
        [Display(Name = "Komuna")]
        public int KomunaId { get; set; }
        [ForeignKey("KomunaId")]
        [ValidateNever]
        public Komuna Komuna { get; set; }

    }
}
