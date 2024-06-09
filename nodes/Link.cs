
namespace DocDino
{
    public class Link(string text, string linkText) : IDocDinoNode
    {
        public string Text { get; set; } = text;
        public string URLText { get; set; } = linkText;

        public void DebugPrint()
        {
            Console.WriteLine("Link:");
            Console.WriteLine($"\t{Text}");
            Console.WriteLine($"\t{URLText}");
        }

        public string FormatHTML()
        {
            string html = string.Empty;

            html += $"<a href='{URLText}'>{Text}</a>";

            return html;
        }
    }
}
