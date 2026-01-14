namespace SAT242516005.Services
{
    public class FileLogService
    {
        private readonly string _path = Path.Combine("Logs", "app-log.txt");

        public void LogYaz(string islem, string detay)
        {
            var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {islem} | {detay}";
            File.AppendAllText(_path, line + Environment.NewLine);
        }
    }
}
