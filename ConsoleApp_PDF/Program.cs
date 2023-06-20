using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;
using System.Net.Http.Headers;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Creae new Document
Document.Create(document =>
{
    document.Page(page =>
    {

        //page.Header().Height(100).Background(Colors.Blue.Medium);
        //page.Content().Background(Colors.Yellow.Medium);
        //page.Footer().Height(50).Background(Colors.Red.Medium);
        
        page.Margin(30);

        // Header
        page.Header().ShowOnce().Row(row =>
        {
            // Logo
            row.ConstantItem(140).Height(60).Placeholder();

            // Information Business
            row.RelativeItem().Column(col =>
            {
                col.Item().AlignCenter().Text("DarkyGr Studios").Bold().FontSize(14);
                col.Item().AlignCenter().Text("Street Unknow 0000").FontSize(9);
                col.Item().AlignCenter().Text("000 000 0001 / 000 000 0002").FontSize(9);
                col.Item().AlignCenter().Text("example@example.com").FontSize(9);
            });

            // Information Report
            row.RelativeItem().Column(col =>
            {
                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text("RUC 101010410001");
                col.Item().Border(1).Background("#257272").AlignCenter().Text("Sell's Report").FontColor("#fff");
                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text("SR-010001");
            });            

        });

        page.Content().PaddingVertical(10).Column(col1 =>
        {
            col1.Item().Text("Customer Information").Underline().Bold();

            // Name
            col1.Item().Text(txt =>
            {
                txt.Span("Name: ").SemiBold().FontSize(10);
                txt.Span("Unknow").FontSize(10);
            });

            // DNI
            col1.Item().Text(txt =>
            {
                txt.Span("DNI: ").SemiBold().FontSize(10);
                txt.Span("00000001").FontSize(10);
            });

            // Address
            col1.Item().Text(txt =>
            {
                txt.Span("Address: ").SemiBold().FontSize(10);
                txt.Span("Street Unknow 1121").FontSize(10);
            });

            col1.Item().LineHorizontal(0.5f);

            col1.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();                    
                });

                // Table header
                table.Header(header =>
                {
                    header.Cell().Background("#257272").Padding(2).Text("Product").FontColor("#fff");
                    header.Cell().Background("#257272").Padding(2).Text("Unit Price").FontColor("#fff");
                    header.Cell().Background("#257272").Padding(2).Text("Amount").FontColor("#fff");
                    header.Cell().Background("#257272").Padding(2).Text("Total").FontColor("#fff");
                });

                // Values of the table
                foreach (var item in Enumerable.Range(1, 45))
                {
                    var amout = Placeholders.Random.Next(1, 10);
                    var price = Placeholders.Random.Next(5, 15);
                    var total = amout * price;

                    table.Cell().BorderBottom(0.5f).BorderColor("#d9d9d9").Padding(2).Text(Placeholders.Label()).FontSize(10);
                    table.Cell().BorderBottom(0.5f).BorderColor("#d9d9d9").Padding(2).Text(amout.ToString()).FontSize(10);
                    table.Cell().BorderBottom(0.5f).BorderColor("#d9d9d9").Padding(2).Text($"S/.{price}").FontSize(10);
                    table.Cell().BorderBottom(0.5f).BorderColor("#d9d9d9").Padding(2).Text($"S/.{total}").FontSize(10);
                }
            });
        });
    });
}).ShowInPreviewer();