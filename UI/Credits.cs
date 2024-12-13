using TUI;

namespace FashionDressingGame.UI;

public class Credits
{
    public void Start()
    {
        Console.Write("\x1B[?47h");
        string[] art = {
                " ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄ ",
                "▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌",
                "▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▀▀▀▀█░█▀▀▀▀  ▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀ ",
                "▐░▌          ▐░▌       ▐░▌▐░▌          ▐░▌       ▐░▌    ▐░▌          ▐░▌     ▐░▌          ",
                "▐░▌          ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░▌       ▐░▌    ▐░▌          ▐░▌     ▐░█▄▄▄▄▄▄▄▄▄ ",
                "▐░▌          ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌    ▐░▌          ▐░▌     ▐░░░░░░░░░░░▌",
                "▐░▌          ▐░█▀▀▀▀█░█▀▀ ▐░█▀▀▀▀▀▀▀▀▀ ▐░▌       ▐░▌    ▐░▌          ▐░▌      ▀▀▀▀▀▀▀▀▀█░▌",
                "▐░▌          ▐░▌     ▐░▌  ▐░▌          ▐░▌       ▐░▌    ▐░▌          ▐░▌               ▐░▌",
                "▐░█▄▄▄▄▄▄▄▄▄ ▐░▌      ▐░▌ ▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌▄▄▄▄█░█▄▄▄▄      ▐░▌      ▄▄▄▄▄▄▄▄▄█░▌",
                "▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░▌     ▐░░░░░░░░░░░▌",
                " ▀▀▀▀▀▀▀▀▀▀▀  ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀       ▀▀▀▀▀▀▀▀▀▀▀ ",
            };
            
            Title credits = new Title(art, 0, 3, null, null, Align.Center);
            Window creditsWindow = new Window(0, 0, 100, 37)
            {
                BorderOn = true,
                BorderHorizontal = '*',
                BorderVertical = '*',
                BorderBackgroundColor = ConsoleColor.White,
                BorderForegroundColor = ConsoleColor.Black,
            };

            int paneLoc = 31;
            Pane pane1 = new Pane(paneLoc, 15, 18, 5, ConsoleColor.Cyan)
            {
                BorderOn = true,
                BorderHorizontal = '~',
                BorderVertical = '|',
                BorderBackgroundColor = ConsoleColor.White,
                BorderForegroundColor = ConsoleColor.Black,
            };

            Pane pane2 = new Pane(paneLoc, 21, 18, 5, ConsoleColor.Cyan)
            {
                BorderOn = true,
                BorderHorizontal = '~',
                BorderVertical = '|',
                BorderBackgroundColor = ConsoleColor.White,
                BorderForegroundColor = ConsoleColor.Black,
            };
            Pane pane3 = new Pane(paneLoc, 27, 18, 5, ConsoleColor.Cyan)
            {
                BorderOn = true,
                BorderHorizontal = '~',
                BorderVertical = '|',
                BorderBackgroundColor = ConsoleColor.White,
                BorderForegroundColor = ConsoleColor.Black,
            };

            string[] markText = new[]
            {
                "Mark Joseph D. Amarille"
            };
            string[] siludText = new[]
            {
                "Andrei Silud"
            };

            string[] vinoyaText = new[]
            {
                "Mark Chester Vinoya"
            };

            Label mark = new Label("Mark Joseph D. Amarille", 51, 27, ConsoleColor.Black, ConsoleColor.Green, Align.Left);
            Label silud = new Label("Luis Andrei Silud", 51, 15, ConsoleColor.Black, ConsoleColor.Green, Align.Left);
            Label chester = new Label("Mark Chester Vinoya", 51, 21, ConsoleColor.Black, ConsoleColor.Green, Align.Left);

            Label chesterCat = new Label("(⸝⸝ᴗ﹏ᴗ⸝⸝)ᶻᶻᶻ", 33, 23, ConsoleColor.Black, ConsoleColor.Cyan, Align.Left);
            Label markCat = new Label("ฅ/ᐠ.﹏.ᐟ\\ฅ", 34, 29, ConsoleColor.Black, ConsoleColor.Cyan, Align.Left);
            Label siludCat = new Label("/ᐠ-\u02d5-ᐟ\\", 35, 17, ConsoleColor.Black, ConsoleColor.Cyan, Align.Left);

            Label messageMark = new Label("Chillax lang", 50, 29, null, null, Align.Left);
            Label messageChester = new Label("Kagigising ko lang...", 50, 23, null, null, Align.Left);
            Label messageSilud = new Label("Nanatiling mabuting tao", 50, 17, null, null, Align.Left);


            
            creditsWindow.AddChild(credits);
            creditsWindow.AddChild(pane1);
            creditsWindow.AddChild(pane2);
            creditsWindow.AddChild(pane3);
            creditsWindow.AddChild(silud);
            creditsWindow.AddChild(chester);
            creditsWindow.AddChild(mark);
            
            creditsWindow.AddChild(chesterCat);
            creditsWindow.AddChild(markCat);
            creditsWindow.AddChild(siludCat);
            
            creditsWindow.AddChild(messageMark);
            creditsWindow.AddChild(messageChester);
            creditsWindow.AddChild(messageSilud);

            
            creditsWindow.RenderAll();

            
            Console.SetCursorPosition(33, 33);
            Console.WriteLine("Press any key to go back to Main Menu...");
            Console.ReadKey();
            Console.Clear();
            Console.Write("\x1B[?47l");
    }
}