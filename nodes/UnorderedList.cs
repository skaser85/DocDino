
namespace DocDino
{
    public class UnorderedList : IDocDinoNode
    {
        public List<string> Items { get; set; } = [];

        public void DebugPrint()
        {
            Console.WriteLine("UnorderedList:");
            foreach (string s in Items)
                Console.WriteLine($"\t{s}");
        }

        public string FormatHTML()
        {
            string html = string.Empty;

            html += "<ul>";
            foreach (string s in Items)
                html += $"<li>{s}</li>";
            html += "</ul>";

            return html;
        }
    }
}
