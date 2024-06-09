using System.Text.RegularExpressions;
using DocDino;

string inputFP = "./md/test.md";
DocDinoDoc doc = new(inputFP, "output.html");
bool listInProgress = false;

string contents = GetFileContents("./md/test.md");

for (int i = 0; i < contents.Length; i++)
{
    char c = contents[i];
    if (c == '\n' || Char.IsWhiteSpace(c))
        continue;
    if (c == '#')
    {
        listInProgress = false;
        // HEADER
        int headerLevel = 1;
        int k = i;
        do
        {
            char next = contents[++k];
            if (next == '#')
                headerLevel += 1;
            else
                break;
        } while (headerLevel <= Header.HeaderLevelMax);

        i = k;
        Header h = new(headerLevel);
        h.Text = ReadToEndOfLine(contents, ref i);
        doc.Nodes.Add(h);
    }
    else if (c == '>')
    {
        listInProgress = false;
        // BLOCKQUOTE
        string text = ReadToEndOfLine(contents, ref i);
        Blockquote b = new(text);
        doc.Nodes.Add(b);
    }
    else if (c == '-')
    {
        // UNORDERED LIST
        string text = ReadToEndOfLine(contents, ref i);
        if (!listInProgress)
        {
            UnorderedList u = new();
            u.Items.Add(text);
            doc.Nodes.Add(u);
            listInProgress = true;
        }
        else
        {
            UnorderedList u = (UnorderedList)doc.Nodes.Last();
            u.Items.Add(text);
        }
    }
    else if (IsNumber(c))
    {
        // ORDERED LIST
        string text = ReadToEndOfLine(contents, ref i);
        if (text.StartsWith('.'))
            text = text[1..].Trim();
        if (!listInProgress)
        {
            OrderedList o = new();
            o.Items.Add(text);
            doc.Nodes.Add(o);
            listInProgress = true;
        }
        else
        {
            OrderedList o = (OrderedList)doc.Nodes.Last();
            o.Items.Add(text);
        }
    }
    else if (c == '[')
    {
        listInProgress = false;
        // LINK
        string text = ReadToChar(contents, ref i, ']');
        ++i;
        string linkText = ReadToChar(contents, ref i , ')');
        Link l = new(text, linkText);
        doc.Nodes.Add(l);
    }
    else if (!Char.IsWhiteSpace(c))
    {
        listInProgress = false;
        // PARAGRAPH
        char firstChar = c;
        string text = ReadToEndOfLine(contents, ref i);
        Paragraph p = new(text.Insert(0, Char.ToString(c)));
        doc.Nodes.Add(p);
    }
}

doc.GenerateOutputFile();

string ReadToChar(string contents, ref int start, char end)
{
    ++start;
    string text = String.Empty;
    while (contents[start] != '\n' && contents[start] != end)
    {
        text += contents[start++];
    }
    return text.Trim();
}

bool IsNumber(char c)
{
    return c >= '0' && c <= '9';
}

string ReadToEndOfLine(string contents, ref int start)
{
    ++start;
    string text = String.Empty;
    while (contents[start] != '\n')
    {
        text += contents[start++];
    }
    return text.Trim();
}

string GetFileContents(string filePath)
{
    string text = String.Empty;
    try
    {
        using StreamReader reader = new(filePath);
        text = reader.ReadToEnd();
    }
    catch (IOException e)
    {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
    }
    return text;
}

