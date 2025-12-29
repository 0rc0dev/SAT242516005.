using System;
using System.ComponentModel.DataAnnotations;

namespace SAT242516005.Data
{
    public class Vardiya
    {
        public int VardiyaId { get; set; }

        public int DoktorId { get; set; }
        public Doktor? Doktor { get; set; }

        [Required]
        public DateTime Tarih { get; set; } = DateTime.Now;

        [Required]
        
        public TimeSpan BaslangicSaati { get; set; } = new TimeSpan(9, 0, 0);

        [Required]
        public TimeSpan BitisSaati { get; set; } = new TimeSpan(17, 0, 0);
    }
}