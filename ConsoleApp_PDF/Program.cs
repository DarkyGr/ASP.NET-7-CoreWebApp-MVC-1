using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Creae new Document
Document.Create(document =>
{
    document.Page(page =>
    {
        // page content
    });
}).ShowInPreviewer();