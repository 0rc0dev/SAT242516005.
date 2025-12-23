using System;

namespace SAT242516005.Models
{
    public class Vardiya
    {
        public int VardiyaId { get; set; }
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }

        public DateTime Tarih { get; set; }
        public DateTime BaslangicSaati { get; set; }
        public DateTime BitisSaati { get; set; }
    }
}