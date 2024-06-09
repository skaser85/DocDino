
namespace DocDino
{
    public class Paragraph(string text) : IDocDinoNode
    {
        public string Text { get; set; } = text;

        public void DebugPrint()
        {
            Console.WriteLine("Paragraph:");
            Console.WriteLine($"\t{Text}");
        }

        public string FormatHTML()
        {
            string html = "";

            html += $"<p>{Text}</p>";

            return html;
        }
    }
}
