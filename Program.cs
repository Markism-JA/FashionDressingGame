using FashionDressingGame.Service;
using FashionDressingGame.UI;
using TUI;

namespace FashionDressingGame;

class Program
{
    public static readonly int windowHeight = 37;
    public static readonly int windowWidth = 100;

    private static Dictionary<string, Action> mainActions = new Dictionary<string, Action>()
    {
        {"New Game", New.NewPlayer},
        {"Load Game", LoadGame},
        {"Campaign", Campaign},
        {"Credits", Credits},
        {"Exit", (() => isRunning = false)},
    };
    private static bool isRunning = true;
    
    public static void Main(string[] args)
    {
        MainMenu();
        // New.NewPlayer();
        // New.GetClothing();
        
    }

    

    public static void MainMenu()
    {
        Window window = new Window(null, null, windowWidth, windowHeight, null)
        {
            BorderOn = true,
            BorderHorizontal = '*',
            BorderVertical = '*',
            BorderBackgroundColor = ConsoleColor.White,
            BorderForegroundColor = ConsoleColor.Black,
        };
            
        string[] asciiArt =
        {
            "▗▄▄▄ ▗▄▄▖ ▗▄▄▄▖ ▗▄▄▖ ▗▄▄▖▗▄▄▄▖▗▖  ▗▖ ▗▄▄▖     ▗▄▄▖ ▗▄▖ ▗▖  ▗▖▗▄▄▄▖",
            "▐▌  █▐▌ ▐▌▐▌   ▐▌   ▐▌     █  ▐▛▚▖▐▌▐▌       ▐▌   ▐▌ ▐▌▐▛▚▞▜▌▐▌   ",
            "▐▌  █▐▛▀▚▖▐▛▀▀▘ ▝▀▚▖ ▝▀▚▖  █  ▐▌ ▝▜▌▐▌▝▜▌    ▐▌▝▜▌▐▛▀▜▌▐▌  ▐▌▐▛▀▀▘",
            "▐▙▄▄▀▐▌ ▐▌▐▙▄▄▖▗▄▄▞▘▗▄▄▞▘▗▄█▄▖▐▌  ▐▌▝▚▄▞▘    ▝▚▄▞▘▐▌ ▐▌▐▌  ▐▌▐▙▄▄▖",
            "                                                                  "
        };
        
        Title game = new Title(asciiArt, null, 8,null, null,Align.Center);
        var menuItems = new Dictionary<int, string>()
        {
            {1, "New Game"},
            {2, "Load Game"},
            {3, "Campaign"},
            {4, "Credits"},
            {5, "Exit"},
        };
        
        var menu = new Menu(menuItems, 43, 15, 13, 10);
        window.AddChild(game);
        ConsoleKey key;
        Console.CursorVisible = false;
        do
        {
            window.AddChild(menu);
            window.RenderAll();
            key = Console.ReadKey(true).Key;
            menu.HandleInput(key);
            if (menu.SelectionMade)
            {
                if (mainActions.TryGetValue(menu.FinalKey, out var action))
                {
                    action();
                }
                else
                {
                    throw new Exception($"Unknown menu item: {menu.GetSelectedItem()}");
                }
                if (key == ConsoleKey.Escape || menu.SelectionMade)
                {
                    isRunning = false;
                }
            }
        } while (isRunning);
    }

    public static void LoadGame()
    {
    }
    public static void Credits()
    {
        Console.Clear();
        Console.WriteLine("=> Credits \nMembers are:");
        Console.WriteLine("Andrei Silud - Nanatiling mabuting tao hanggang sa dulo");
        Console.WriteLine("Mark Joseph D. Amarille - Chillax lang, basta kayang matulog ng 12 hrs sa isang oras");
        Console.WriteLine("Mark Chester Vinoya - Sorry, kagigising ko lang......");
        Thread.Sleep(10000);

    }
    public static void Campaign()
    {
        Console.WriteLine("=> Campaign\n");
        TypewriterEffect("In the bustling city of Sirius, where style was everything and the streets buzzed with " +
                          "\nfashionistas, a hidden boutique held a secret that could change the game of fashion forever. " +
                          "\nTucked away on a quiet street, Mystic Atelier appeared like an ordinary shop. Yet, its enchanted " +
                          "\nfitting room whispered promises of magical transformation. Legend had it that anyone brave enough " +
                          "\nto step inside and complete the boutique's trial would emerge as a new person with an unbelievable " +
                          "\nsense of fashion and style. Not only would they possess an unparalleled sense of style, but they " +
                          "\nwould also radiate confidence and creativity like never before.\n");
        
        TypewriterEffect("One day, while looking for a job, a curious visitor stumbled upon the boutique. With a heart full of " +
                          "\nquestions and curiosity, they pushed open the door and were greeted by a mysterious shopkeeper whose " +
                          "\nsmile seemed to know everything without a word. \"Welcome,\" the shopkeeper said with a gentle and " +
                          "\nreassuring voice. \"Inside this wardrobe, your creativity will come alive. Are you ready to master the " +
                          "\nart of fashion and style?\" A sudden sense of excitement gushed like the wind.\n");
        
        TypewriterEffect("Intrigued, the visitor stepped into the fitting room, where walls of sparkling light revealed " +
                          "\nendless possibilities. Floating challenges appeared before them: mix and match pieces to create " +
                          "\nthemes, layer textures to perfection, and accessorize to elevate every design. Each choice mattered, " +
                          "\nfrom bold patterns to subtle hues, and every completed look felt like unlocking a new level of " +
                          "\nartistic mastery. With each completed look, they unlocked a deeper understanding of the artistry " +
                          "\nbehind styling, gaining confidence in their choices. As they immersed themselves in the trials, " +
                          "\nthey realized this wasn’t just a game—it was a journey to master the art of styling and discover " +
                          "\nthe power of true self-expression.\n");
    }
    public static void TypewriterEffect(string text, int delay = 30)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay); // Adjust delay for speed (milliseconds)
        }
        Console.WriteLine(); // Ensure a newline after the text block
    }
    
}