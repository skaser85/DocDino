
namespace DocDino
{
    public class OrderedList : IDocDinoNode
    {
        public List<string> Items { get; set; } = [];

        public void DebugPrint()
        {
            Console.WriteLine("OrderedList:");
            foreach (string s in Items)
                Console.WriteLine($"\t{s}");
        }

        public string FormatHTML()
        {
            string html = string.Empty;

            html += "<ol>";
            foreach (string s in Items)
                html += $"<li>{s}</li>";
            html += "</ol>";

            return html;
        }
    }
}
