using System.Text.Json;

namespace SAT242516005.Models.Extensions
{
    public static class Extensions_Json
    {
        public static string ToJson<T>(this T obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static T? FromJson<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
