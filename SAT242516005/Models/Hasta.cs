using System;
using System.ComponentModel.DataAnnotations;

namespace SAT242516005.Models
{
    public class Hasta
    {
        public int HastaId { get; set; }

        [Required]
        public string Ad { get; set; } = string.Empty;

        [Required]
        public string Soyad { get; set; } = string.Empty;

        [Required]
        public DateTime DogumTarihi { get; set; }
    }
}
