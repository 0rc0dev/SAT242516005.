using System.ComponentModel.DataAnnotations;
using SAT242516005.Localization;

namespace SAT242516005.Data
{
    public class Vardiya
    {
        public int VardiyaId { get; set; }

        public int DoktorId { get; set; }
        public Doktor? Doktor { get; set; }

        [Required]
        [Display(Name = "Tarih", ResourceType = typeof(AppResource))]
        public DateTime Tarih { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "BaslangicSaati", ResourceType = typeof(AppResource))]
        public TimeSpan BaslangicSaati { get; set; } = new TimeSpan(9, 0, 0);

        [Required]
        [Display(Name = "BitisSaati", ResourceType = typeof(AppResource))]
        public TimeSpan BitisSaati { get; set; } = new TimeSpan(17, 0, 0);
    }
}