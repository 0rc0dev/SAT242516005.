using System.ComponentModel.DataAnnotations;

namespace SAT242516005.Data
{
    public class Hasta
    {
        [Key]
        public int HastaId { get; set; }

        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Soyad { get; set; }

       
        [Required(ErrorMessage = "Doğum tarihi geçerli olmalı")]
        [Display(Name = "Doğum Tarihi")]
        public DateTime DogumTarihi { get; set; } = DateTime.Now;
    }
}