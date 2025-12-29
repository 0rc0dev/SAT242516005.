using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SAT242516005.Data;

public class RaporServis
{
    public byte[] DoktorListesiPdfOlustur(List<Doktor> doktorlar)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(50);
                page.Header().Text("HASTANE OTOMASYON - DOKTOR LİSTESİ").FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    table.Header(header =>
                    {
                        header.Cell().Text("Ad");
                        header.Cell().Text("Soyad");
                        header.Cell().Text("Branş");
                    });

                    foreach (var d in doktorlar)
                    {
                        table.Cell().Text(d.Ad);
                        table.Cell().Text(d.Soyad);
                        table.Cell().Text(d.Brans);
                    }
                });
            });
        }).GeneratePdf();
    }
}