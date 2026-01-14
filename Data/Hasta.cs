using System.ComponentModel.DataAnnotations;
using SAT242516005.Localization;

namespace SAT242516005.Data
{
    public class Hasta
    {
        [Key]
        public int HastaId { get; set; }

        [Required(ErrorMessageResourceName = "AdGerekli", ErrorMessageResourceType = typeof(AppResource))]
        [Display(Name = "Ad", ResourceType = typeof(AppResource))]
        public string Ad { get; set; }

        [Required(ErrorMessageResourceName = "SoyadGerekli", ErrorMessageResourceType = typeof(AppResource))]
        [Display(Name = "Soyad", ResourceType = typeof(AppResource))]
        public string Soyad { get; set; }

        [Required]
        [Display(Name = "DogumTarihi", ResourceType = typeof(AppResource))]
        public DateTime DogumTarihi { get; set; } = DateTime.Now;
    }
}