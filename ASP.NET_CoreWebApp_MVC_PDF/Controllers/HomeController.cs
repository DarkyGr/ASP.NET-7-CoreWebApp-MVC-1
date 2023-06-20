using ASP.NET_CoreWebApp_MVC_PDF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;

namespace ASP.NET_CoreWebApp_MVC_PDF.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _host;

        public HomeController(IWebHostEnvironment host)
        {
            _host = host;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Download Method
        public IActionResult DownloadPDF()
        {
            var data = Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Margin(30);

                    // Header
                    page.Header().ShowOnce().Row(row =>
                    {
                        // Get Logo
                        var logo = Path.Combine(_host.WebRootPath, "resources/logo.png");

                        // Convert logo
                        byte[] logoData = System.IO.File.ReadAllBytes(logo);

                        // Logo
                        row.ConstantItem(150).Image(logoData);

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


                    // Content
                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().Column(col2 =>
                        {
                            col2.Item().Text("Customer Information").Underline().Bold();

                            // Name
                            col2.Item().Text(txt =>
                            {
                                txt.Span("Name: ").SemiBold().FontSize(10);
                                txt.Span("Unknow").FontSize(10);
                            });

                            // DNI
                            col2.Item().Text(txt =>
                            {
                                txt.Span("DNI: ").SemiBold().FontSize(10);
                                txt.Span("00000001").FontSize(10);
                            });

                            // Address
                            col2.Item().Text(txt =>
                            {
                                txt.Span("Address: ").SemiBold().FontSize(10);
                                txt.Span("Street Unknow 1121").FontSize(10);
                            });
                        });

                        // Line
                        col1.Item().LineHorizontal(0.5f);

                        // Table
                        col1.Item().PaddingVertical(10).Table(table =>
                        {
                            // Table Columns
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            // Table headers
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

                        // Total
                        col1.Item().AlignRight().Text("Total: $25,000.00").FontSize(12);

                        // Comments
                        if (1 == 1)
                            col1.Item().Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
                            {
                                column.Item().Text("Comments").FontSize(14);
                                column.Item().Text(Placeholders.LoremIpsum());
                                column.Spacing(5);
                            });

                        // Spacing to col1
                        col1.Spacing(10);
                    });


                    // Footer
                    page.Footer().AlignRight().Text(txt =>
                    {
                        txt.Span("Page ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" of ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });
            }).GeneratePdf();

            // Convert data
            Stream stream = new MemoryStream(data);
            return File(stream, "application/pdf", "sellreport.pdf");
        }

    }
}