using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SAT242516005.Data;

namespace SAT242516005.Services
{
    public class RaporService
    {
        public RaporService()
        {
           
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public byte[] DoktorListesiPdfOlustur(List<Doktor> doktorlar)
        {
           
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);

             
                    page.Header().Text("DOKTOR LİSTESİ")
                        .FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

                  
                    page.Content().PaddingVertical(10).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                    
                        table.Header(header =>
                        {
                            header.Cell().Background(Colors.Grey.Lighten2).Text("Ad");
                            header.Cell().Background(Colors.Grey.Lighten2).Text("Soyad");
                            header.Cell().Background(Colors.Grey.Lighten2).Text("Branş");
                        });

                    
                        foreach (var d in doktorlar)
                        {
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten4).Padding(5).Text(d.Ad);
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten4).Padding(5).Text(d.Soyad);
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten4).Padding(5).Text(d.Brans);
                        }
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Sayfa ");
                        x.CurrentPageNumber();
                    });
                });
            }).GeneratePdf();
        }
    }
}