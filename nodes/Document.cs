namespace DocDino
{
    public class DocDinoDoc(string inputFP, string outputFP)
    {
        public string InputFilePath { get; set; } = inputFP;
        public string OutputFilePath { get; set; } = outputFP;
        public List<IDocDinoNode> Nodes { get; set; } = [];

        public void GenerateOutputFile()
        {
            List<string> html = [];
            foreach (IDocDinoNode n in Nodes)
                html.Add(n.FormatHTML());

            System.IO.File.WriteAllLines(OutputFilePath, html);
        }
    }
}
