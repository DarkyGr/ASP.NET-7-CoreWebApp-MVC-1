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
        page.Header().Row(row =>
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
    });
}).ShowInPreviewer();