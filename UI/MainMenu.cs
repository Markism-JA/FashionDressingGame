using TUI;

namespace FashionDressingGame.UI;

public class MainMenu
{
    private static readonly int WindowHeight = 37;
    private static readonly int WindowWidth = 100;
    
    private static string[] _titleArt =
    [
        "▗▄▄▄ ▗▄▄▖ ▗▄▄▄▖ ▗▄▄▖ ▗▄▄▖▗▄▄▄▖▗▖  ▗▖ ▗▄▄▖     ▗▄▄▖ ▗▄▖ ▗▖  ▗▖▗▄▄▄▖",
        "▐▌  █▐▌ ▐▌▐▌   ▐▌   ▐▌     █  ▐▛▚▖▐▌▐▌       ▐▌   ▐▌ ▐▌▐▛▚▞▜▌▐▌   ",
        "▐▌  █▐▛▀▚▖▐▛▀▀▘ ▝▀▚▖ ▝▀▚▖  █  ▐▌ ▝▜▌▐▌▝▜▌    ▐▌▝▜▌▐▛▀▜▌▐▌  ▐▌▐▛▀▀▘",
        "▐▙▄▄▀▐▌ ▐▌▐▙▄▄▖▗▄▄▞▘▗▄▄▞▘▗▄█▄▖▐▌  ▐▌▝▚▄▞▘    ▝▚▄▞▘▐▌ ▐▌▐▌  ▐▌▐▙▄▄▖",
        "                                                                  "
    ];

    private static Window _mainMenu = new Window(null, null, WindowWidth, WindowHeight)
    {
        BorderOn = true,
        BorderHorizontal = '*',
        BorderVertical = '*',
        BorderBackgroundColor = ConsoleColor.White,
        BorderForegroundColor = ConsoleColor.Black,
    };
    
    private static Dictionary<int, string> _menuItems = new Dictionary<int, string>()
    {
        {1, "New Game"},
        {2, "Load Game"},
        {3, "Campaign"},
        {4, "Credits"},
        {5, "Exit"},
    };
    
    private static Title _mainMenuTitle = new Title(_titleArt, null, 8, null, null, Align.Center);
    
    public static void Start()
    {
        var menu = new Menu(_menuItems, 40, 15, 13, 10);
        _mainMenu.AddChild(_mainMenuTitle);

        do
        {
            _mainMenu.AddChild(menu);
            _mainMenu.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            menu.HandleInput(key);
            if (menu.SelectionMade)
            {
                string selectedItem = menu.GetSelectedItem();
                break;
            }
            
        } while (true);
    }

}