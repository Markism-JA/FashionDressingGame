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

    private Window _mainWindow = new Window(null, null, WindowWidth, WindowHeight)
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
    private Title _mainMenuTitle = new Title(_titleArt, null, 8, null, null, Align.Center);
    
    private Menu _mainMenu = new Menu(_menuItems, 44, 15, 13, 10);
    public void Start()
    {
        Load newLoad = new Load();
        Campaign newCampaign = new Campaign(); 
        Credits newCredits = new Credits();
        Label newLabel = new Label("Use Arrow Keys For Navigation", 0, 30, null, null, Align.Center); 
        Label newlabel1 = new Label("Enter to select and Escape to go back", 0, 31, null, null, Align.Center);
        _mainWindow.AddChild(newlabel1);
        _mainWindow.AddChild(newLabel);
        
        _mainWindow.AddChild(_mainMenuTitle);
        do
        {
            try
            {
                _mainWindow.AddChild(_mainMenu);
                _mainWindow.RenderAll();
                ConsoleKey key = Console.ReadKey(true).Key;
                _mainMenu.HandleInput(key);
                if (_mainMenu.SelectionMade)
                {
                    string selectedItem = _mainMenu.GetSelectedItem();
                    if (selectedItem == "Exit")
                    {
                        break;
                    }
                    else if (Utilities.ConvertDictionaryValuesToList(_menuItems).Contains(selectedItem))
                    {
                        if (selectedItem == "New Game")
                        {
                            New newGame = new New();
                            newGame.Start();
                        }
                        else if (selectedItem == "Load Game") newLoad.Start();
                        else if (selectedItem == "Campaign") newCampaign.Start();
                        else if (selectedItem == "Credits") newCredits.Start();
                    }

                    _mainMenu.SelectionMade = false;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Label label = new Label("Error" , 0, 10, null, null, Align.Center);
                Label pressAny = new Label("Press any key to go back to Character Selection", 0, 33, null, null, Align.Center);
                
                Console.WriteLine(e.StackTrace);

                _mainWindow.AddChild(label);
                _mainWindow.AddChild(pressAny);
                _mainWindow.RenderAll();

                Console.ReadKey();
            }
        } while (true);
    }

}