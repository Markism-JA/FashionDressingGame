using TUI;

namespace FashionDressingGame.UI;

public class Campaign
{
    public void  Start()
    {
        Console.Write("\x1B[?47h"); //Move to a different buffer
        Window campaignWindow = new Window(0, 0, 100, 37)
            {
                BorderOn = true,
                BorderHorizontal = '*',
                BorderVertical = '*',
                BorderBackgroundColor = ConsoleColor.White,
                BorderForegroundColor = ConsoleColor.Black,
            };

            Pane pane = new Pane(5, 5, 90, 30, ConsoleColor.Cyan)
            {
                BorderOn = true,
                BorderHorizontal = ' ',
                BorderVertical = ' ',
                BorderBackgroundColor = ConsoleColor.White,
                BorderForegroundColor = ConsoleColor.Black,
            };

            string[] campaignTitle =
            [
                "┏┓         •    ",
                "┃ ┏┓┏┳┓┏┓┏┓┓┏┓┏┓",
                "┗┛┗┻┛┗┗┣┛┗┻┗┗┫┛┗",
                "       ┛     ┛  "
            ];
            
            string[] campaignStory =
            {
                "In the bustling city of Sirius, where style was everything and the streets buzzed",
                "with fashionistas, a hidden boutique held a secret that could completely change the",
                "game of fashion forever. Tucked away on a quiet street, Mystic Atelier appeared",
                "like an ordinary shop, but its magical aura set it apart from anything else.",
                "Yet, its enchanted fitting room whispered promises of magical transformation,",
                "transforming ordinary into extraordinary. Legend had it that anyone brave enough to",
                "step inside and complete the boutique's trial would emerge as a new person with",
                "an unbelievable sense of fashion and style. Not only would they possess an",
                "unparalleled sense of style, but they would also radiate confidence and creativity",
                "like never before, standing out in any crowd with grace and poise.",
                "",
                "One day, while looking for a job, a curious visitor stumbled upon the boutique.",
                "With a heart full of questions and curiosity, they pushed open the door and were",
                "greeted by a mysterious shopkeeper whose smile seemed to know everything without",
                "a word. \"Welcome,\" the shopkeeper said with a gentle and reassuring voice. \"Inside",
                "this wardrobe, your creativity will come alive. Are you ready to master the art",
                "of fashion and style?\" A sudden sense of excitement gushed like the wind, filling",
                "the room with possibilities.",
                "",
                "Intrigued, the visitor stepped into the fitting room, where walls of sparkling light",
                "revealed endless possibilities. Floating challenges appeared before them: mix and",
                "match pieces to create bold themes, layer textures to perfection, and accessorize to",
                "elevate every design to a new level. Each choice mattered, from bold patterns to",
                "subtle hues, and every completed look felt like unlocking a new level of artistic",
                "mastery. With each completed look, they unlocked a deeper understanding of the",
                "artistry behind styling, gaining confidence in their choices. As they immersed ",
                "themselves in the trials, they realized this wasn’t just a game—it was a life-changing ",
                "journey to master the art of styling and discover the power of true self-expression."
            };

            Typewritter campaignType = new Typewritter(campaignStory, 6, 6, 30, 90,5,ConsoleColor.Black, ConsoleColor.Cyan);


            Title title = new Title(campaignTitle, null,1, null, null, Align.Center);
            
            campaignWindow.AddChild(title);
            campaignWindow.AddChild(pane);
            
            campaignWindow.RenderAll();
            
            Thread.Sleep(50);
            campaignWindow.AddChild(campaignType);
            campaignWindow.RenderAll();
            
            Console.SetCursorPosition(33, 35);
            Console.WriteLine("Press any key to go back to Main Menu...");
            Console.ReadKey();
            
            Console.Clear();
            Console.Write("\x1B[?47l");
    }
}