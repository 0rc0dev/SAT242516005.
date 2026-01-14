namespace SAT242516005.Models.MyDbModels.Entities
{
    public class Log
    {
        public int LogId { get; set; }

        public string Islem { get; set; } = string.Empty;

        public string Detay { get; set; } = string.Empty;

        public DateTime Tarih { get; set; }
    }
}
