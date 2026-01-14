using System;

namespace SAT242516005.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Class)]
    public class ColorAttribute : Attribute
    {
        public string HexCode { get; }

        public ColorAttribute(string hexCode)
        {
            HexCode = hexCode;
        }
    }
}