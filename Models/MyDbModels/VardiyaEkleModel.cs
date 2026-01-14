using System.ComponentModel.DataAnnotations;

namespace SAT242516005.Models.MyDbModels
{
    public class VardiyaEkleModel
    {
        [Required]
        public int DoktorId { get; set; }
        [Required]
        public DateTime Tarih { get; set; } = DateTime.Today;
        [Required]
        public TimeOnly? BaslangicSaati { get; set; } = new TimeOnly(9, 0);
        [Required]
        public TimeOnly? BitisSaati { get; set; } = new TimeOnly(17, 0);
    }
}