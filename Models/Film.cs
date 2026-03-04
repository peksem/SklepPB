using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SklepPB.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nie podano tytułu")]
        public string Title { get; set; }

        public string Director { get; set; }

        [StringLength(500)]
        public string Desc { get; set; }

        public decimal? Price { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
