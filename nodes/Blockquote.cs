
namespace DocDino
{
    public class Blockquote(string text) : IDocDinoNode
    {
        public string Text { get; set; } = text;

        public void DebugPrint()
        {
            Console.WriteLine("Blockequote:");
            Console.WriteLine($"\t{Text}");
        }

        public string FormatHTML()
        {
            string html = "";
            
            html += $"<div class='blockquote'>{Text}</div>";

            return html;
        }
    }
}
