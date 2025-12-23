using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAT242516005.Models
{
    public class Doktor
    {
        public int DoktorId { get; set; }

        [Required]
        public string Ad { get; set; } = string.Empty;

        [Required]
        public string Soyad { get; set; } = string.Empty;

        [Required]
        public string Brans { get; set; } = string.Empty;

        public List<Vardiya> Vardiyalar { get; set; } = new();
    }
}
