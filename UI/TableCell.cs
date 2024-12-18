using TUI;

namespace FashionDressingGame.UI;

public class TableCell
{
    public string Content { get; set; }
    public int Width { get; set; }
    public int Span { get; set; } = 1; // Default span is 1 column

    public TableCell(string content, int width, int span = 1)
    {
        Content = content;
        Width = width;
        Span = span;
    }
}

public class TableRow
{
    public List<TableCell> Cells { get; } = new List<TableCell>();

    public void AddCell(string content, int width)
    {
        Cells.Add(new TableCell(content, width));
    }

    public int GetTotalWidth()
    {
        return Cells.Sum(c => c.Width) + (Cells.Count - 1);
    }
}

public class Table : DisplayWidget
{
    public Table(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public List<TableRow> Rows { get; } = new List<TableRow>();

    public void AddRow(TableRow row)
    {
        Rows.Add(row);
    }

    public TableRow GetRow(int index) => Rows[index];
}
