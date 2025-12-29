using System.Data;
using Microsoft.Data.SqlClient;

namespace SAT242516005.Models.Extensions
{
    public static class Extensions_SqlParameter
    {
        public static SqlParameter ToSqlParameter(
            this object value,
            string name,
            SqlDbType type)
        {
            return new SqlParameter(name, type)
            {
                Value = value ?? DBNull.Value
            };
        }
    }
}
