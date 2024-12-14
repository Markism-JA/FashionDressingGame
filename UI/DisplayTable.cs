using TUI;

namespace FashionDressingGame.UI
{
    public class DisplayTable : DisplayWidget
    {
        private int _padding;
        private int _spacing;
        private char _horizontalSeparator;
        private char _verticalSeparator;
        private ConsoleColor _separatorBackground;
        private ConsoleColor _separatorForeground;
        private Dictionary<string, string> _content;
        private string _title;

        public DisplayTable(Dictionary<string, string> content, string Title, int x, int y, int padding = 4, int spacing = 1, ConsoleColor? background = null, ConsoleColor? foreground = null)
        {
            _title = Title;
            _content = content;
            X = x;
            Y = y;
            _padding = padding;
            _spacing = spacing;
            BackgroundColor = background;
            ForegroundColor = foreground;
            _horizontalSeparator = '-';
            _verticalSeparator = '|';
            _separatorBackground = ConsoleColor.Black;
            _separatorForeground = ConsoleColor.White;
        }

        public override void AddToBuffer(TerminalBuffer? buffer)
        {
            if (buffer == null) return;
            RenderTable(buffer, _title, _content, Y);
        }

        private void RenderTable(TerminalBuffer? buffer, string title, Dictionary<string, string> items, int y)
        {
            if (buffer == null) return;

            // Render the title
            RenderTitle(buffer, title, y);
            y += 2; // Move y position below the title

            // Render the column headers (keys in the dictionary)
            RenderRow(buffer, items.Keys, y);
            y += 2; // Space between header and content

            // Render the content (values in the dictionary)
            RenderRow(buffer, items.Values, y);
        }

        private void RenderTitle(TerminalBuffer? buffer, string title, int y)
        {
            if (buffer == null) return;

            // Center the title in the width of the terminal
            int titleWidth = title.Length + (_padding * 2);
            int x = X + (80 - titleWidth) / 2;

            // Draw the title with padding
            for (int i = 0; i < title.Length; i++)
            {
                buffer.UpdateCell(x + i + _padding, y, title[i], ForegroundColor, BackgroundColor);
            }
        }

        private void RenderRow(TerminalBuffer? buffer, IEnumerable<string> items, int y)
        {
            if (buffer == null) return;

            int x = X;

            foreach (var item in items)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    buffer.UpdateCell(x + i + _padding, y, item[i], ForegroundColor, BackgroundColor);
                }

                // Move to the next column (with spacing between columns)
                x += item.Length + (_spacing * 2) + _padding * 2; // Item width + padding + spacing
            }
        }
    }
}
