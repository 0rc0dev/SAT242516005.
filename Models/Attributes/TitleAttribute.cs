namespace SAT242516005.Models.Attributes;

public class TitleAttribute(string title) : Attribute
{
    public string Title { get; set; } = title;
}