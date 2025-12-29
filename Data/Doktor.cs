namespace SAT242516005.Data
{
    public class Doktor
    {
        public int DoktorId { get; set; }
        public string Ad { get; set; } = "";
        public string Soyad { get; set; } = "";
        public string Brans { get; set; } = "";
        public List<Vardiya> Vardiyalar { get; set; } = new();
    }
}