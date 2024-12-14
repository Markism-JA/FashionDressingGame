using FashionDressingGame.UI;
using System.Diagnostics;
using FashionDressingGame.Database;
using FashionDressingGame.Service;

namespace FashionDressingGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "FashionDressingGame";
            
            Console.CursorVisible = false;
            MainMenu newGame = new MainMenu();
            try
            {
                 newGame.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            
        }
        
    }
}