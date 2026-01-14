using System.ComponentModel.DataAnnotations;
using SAT242516005.Localization; // AppResource burada tanımlı

namespace SAT242516005.Data
{
    public class Doktor
    {
        public int DoktorId { get; set; }

        [Display(Name = "Ad", ResourceType = typeof(AppResource))]
        public string Ad { get; set; } = "";

        [Display(Name = "Soyad", ResourceType = typeof(AppResource))]
        public string Soyad { get; set; } = "";

        [Display(Name = "Brans", ResourceType = typeof(AppResource))]
        public string Brans { get; set; } = "";

        public List<Vardiya> Vardiyalar { get; set; } = new();
    }
}