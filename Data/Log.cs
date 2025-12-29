namespace SAT242516005.Data
{
    public class Log
    {
        public int Id { get; set; }
        public string Islem { get; set; } 
        public string Detay { get; set; } 
        public DateTime Tarih { get; set; } = DateTime.Now;
        public string Kullanici { get; set; } = "Yönetici";
    }
}