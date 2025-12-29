using System;
using System.ComponentModel;
using System.Reflection;

namespace SAT242516005.Models.Extensions
{
    public static class Extensions_Enum
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo? field = value.GetType().GetField(value.ToString());
            DescriptionAttribute? attr =
                field?.GetCustomAttribute<DescriptionAttribute>();

            return attr?.Description ?? value.ToString();
        }
    }
}
