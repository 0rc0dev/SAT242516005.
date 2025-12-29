namespace SAT242516005.Models.Attributes;

public class ColorAttribute(string color) : Attribute
{
    public string Color { get; set; } = color;
}