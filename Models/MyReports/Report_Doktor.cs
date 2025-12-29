using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace MyReports;

public class Doktor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}


public class Report_Student
{
    static IContainer CellStyle(IContainer container) =>
        container
            .Padding(5)
            .BorderBottom(1)
            .BorderColor(Colors.Grey.Lighten2);

    public byte[] Generate(List<Doktor> students)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var imagePath = "wwwroot/logo_siyah.png";
        var imageData = File.ReadAllBytes(imagePath);

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(50);
                page.Header().Text("Header : Student List")
                    .FontSize(20)
                    .Bold();

                page.Content().Column(col =>
                {
                    col.Item().Row(row =>
                    {
                        // logo + boşluk + başlık alanı
                        row.ConstantColumn(100)
                            .Image(imageData)
                            .FitArea();

                        row.ConstantColumn(20);

                        row.RelativeColumn().Column(c =>
                        {
                            c.Item().Text("Header").FontSize(16).Bold();
                            c.Item().Text($"DateTime: {DateTime.Now:d}");
                        });
                    });

                    col.Item().PaddingTop(20);
                    // tablo ile üst kısım arasında boşluk

                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        // Başlık
                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).Text("Id").Bold();
                            header.Cell().Element(CellStyle).Text("Name").Bold();
                            header.Cell().Element(CellStyle).Text("Surname").Bold();
                        });

                        foreach (var student in students)
                        {
                            table.Cell().Element(CellStyle).Text(student.Id.ToString());
                            table.Cell().Element(CellStyle).Text(student.Name);
                            table.Cell().Element(CellStyle).Text(student.Surname);
                        }

                    });
                });

                page.Footer().Row(row =>
                {
                    row.RelativeColumn().AlignLeft().Text("Footer Left").FontSize(10);
                    row.RelativeColumn().AlignCenter().Text(text =>
                    {
                        text.Span("Page: ").FontSize(10);
                        text.CurrentPageNumber().FontSize(10).Bold();
                        text.Span(" / ").FontSize(10);
                        text.TotalPages().FontSize(10).Bold();
                    });
                    row.RelativeColumn().AlignRight().Text($"DateTime: {DateTime.Now:d}").FontSize(10);
                });
            });
        })
            .GeneratePdf();
    }
}