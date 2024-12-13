using FashionDressingGame.Database;
using FashionDressingGame.Service;
using FashionDressingGame.UI;
using TUI;

namespace FashionDressingGame;

public class Load
{
    private static string[] _loadAscii = new string[]
    {
        " ▗▄▄▖▗▖ ▗▖ ▗▄▖ ▗▄▄▖  ▗▄▖  ▗▄▄▖▗▄▄▄▖▗▄▄▄▖▗▄▄▖     ▗▖   ▗▄▄▄▖ ▗▄▄▖▗▄▄▄▖",
        "▐▌   ▐▌ ▐▌▐▌ ▐▌▐▌ ▐▌▐▌ ▐▌▐▌     █  ▐▌   ▐▌ ▐▌    ▐▌     █  ▐▌     █  ",
        "▐▌   ▐▛▀▜▌▐▛▀▜▌▐▛▀▚▖▐▛▀▜▌▐▌     █  ▐▛▀▀▘▐▛▀▚▖    ▐▌     █   ▝▀▚▖  █  ",
        "▝▚▄▄▖▐▌ ▐▌▐▌ ▐▌▐▌ ▐▌▐▌ ▐▌▝▚▄▄▖  █  ▐▙▄▄▖▐▌ ▐▌    ▐▙▄▄▖▗▄█▄▖▗▄▄▞▘  █  "
    };

    private static Dictionary<int, string> _menuActions = new Dictionary<int, string>()
    {
        {1, "Delete"},
        {2, "Update"},
        {3, "Back"}
    };
    
    public static int WindowHeight = 37;
    public static int WindowWidth = 100;
    
    private Window _loadWindow = new(null, null, WindowWidth, WindowHeight)
    {
        BorderOn = true,
        BorderHorizontal = '*',
        BorderVertical = '*',
        BorderBackgroundColor = ConsoleColor.White,
        BorderForegroundColor = ConsoleColor.Black,
    };

    private Title _loadTitle = new Title(_loadAscii, null, 6, null, null, Align.Center);
    private Dictionary<int, ECharacter> _characters; 
    
    private TableMenu _tableMenu;

    public void characterList()
    {
        Console.Write("\x1B[?47h");
        _loadWindow.AddChild(_loadTitle);
    
        _characters = DatabaseUtils.GetAllCharactersAsDictionary() ?? new Dictionary<int, ECharacter>();
        if (_characters.Count == 0)
        {
            Label warning = new Label("No characters", 0, 18, null, null, Align.Center);
            Label pressAny = new Label("Press any key to go back to Main Menu....", 0, 33, null, null, Align.Center);
            _loadWindow.AddChild(warning);
            _loadWindow.AddChild(pressAny);
            _loadWindow.RenderAll();
            Console.ReadKey();
            
            _loadWindow.RemoveChild(warning);
            _loadWindow.RemoveChild(pressAny);
            Console.Clear();
            Console.Write("\x1B[?47l");
            return;
        }
        else
        {
            _tableMenu = new TableMenu(_characters, 25, 13, 30, 1);
            do
            {
                _loadWindow.AddChild(_tableMenu);
                _loadWindow.RenderAll();
                ConsoleKey key = Console.ReadKey(true).Key;
                _tableMenu.HandleInput(key);

                if (_tableMenu.SelectionMade)
                {
                    ECharacter character = _tableMenu.GetSelectedItem();
                    characterActions(character, _tableMenu, _loadWindow);
                    _tableMenu.SelectionMade = false;
                }

                if (key == ConsoleKey.Escape) break;
            } while (true);
            _loadWindow.RemoveChild(_tableMenu);
        }
    
        

        Console.Clear();
        Console.Write("\x1B[?47l");
    }
    public void characterActions(ECharacter character, TableMenu tableMenu, Window window)
    {
        Menu actions = new(_menuActions, 45, 20, 10, 1);
        do
        {
            window.AddChild(actions);
            window.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            actions.HandleInput(key);

            if (actions.SelectionMade)
            {
                string selectedItem = actions.GetSelectedItem();
            
                if (Utilities.ConvertDictionaryValuesToList(_menuActions).Contains(selectedItem))
                {
                    if (selectedItem == "Delete")
                    {
                        int id = character.Id;
                        DatabaseUtils.DeleteCharacter(id);
                        _characters.Remove(id);
                        break;
                    }
                    else if (selectedItem == "Update")
                    {
                        New update = new New();
                        update.SetState(character);
                        update.NewCharacter = (Character)character;
                        update.Start();

                        if (update.NewCharacter != null)
                        {
                            DatabaseUtils.UpdateCharacter(update.NewCharacter.Id, update.NewCharacter);
                        }
                        else
                        {
                            Console.WriteLine("Update failed: Invalid character data.");
                        }
                    }
                    else if (selectedItem == "Back")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection, please choose a valid option.");
                        Thread.Sleep(1000); // Optional delay
                    }
                }
            }
        
        } while (true);
        window.RemoveChild(actions);
        window.RenderAll();
    }

    public void Start()
    {
        characterList();
    }
    
}