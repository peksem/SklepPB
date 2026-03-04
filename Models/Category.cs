using System.ComponentModel.DataAnnotations;

namespace SklepPB.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(500)]
        public string Desc { get; set; }

        public ICollection<Film> Films { get; set; }
    }
}
