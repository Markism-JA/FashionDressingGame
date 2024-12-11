using FashionDressingGame.UI;

namespace FashionDressingGame;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        try
        {
            Console.CursorVisible = false;
            // MainMenu();
            // New.NewPlayer();
            // New.GetClothing();
            // New.GetAppearance();
            New.GetCharacterInfo();
            New.GetAppearanceInfo();
            New.GetCharacterInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
        finally
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();  
        }
    }
}