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
        page.Header().Height(100).Background(Colors.Blue.Medium);
        page.Content().Background(Colors.Yellow.Medium);
        page.Footer().Height(50).Background(Colors.Red.Medium);
    });
}).ShowInPreviewer();