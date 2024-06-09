
namespace DocDino
{
    public class Header(int level) : IDocDinoNode
    {
        public int Level { get; set; } = level;
        public string Text { get; set; } = String.Empty;

        public static int HeaderLevelMax = 6;

        public void DebugPrint()
        {
            Console.WriteLine("Header:");
            Console.WriteLine($"\t{Level}");
            Console.WriteLine($"\t{Text}");
        }

        public string FormatHTML()
        {
            string html = string.Empty;

            html += $"<h{Level}>{Text}</h{Level}>";

            return html;
        }
    }
}
