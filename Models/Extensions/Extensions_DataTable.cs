using System.Data;

namespace SAT242516005.Models.Extensions
{
    public static class Extensions_DataTable
    {
        public static List<T> DataTableToList<T>(this DataTable table)
            where T : new()
        {
            return new List<T>();
        }
    }
}
