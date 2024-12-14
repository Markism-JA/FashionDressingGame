using FashionDressingGame.Database;
using FashionDressingGame.Service;
using TUI;

namespace FashionDressingGame.UI;

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
        {3, "Show Details"},
        {4, "Back"}
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

    private Title _loadTitle = new Title(_loadAscii, null, 5, null, null, Align.Center);
    private Dictionary<int, ECharacter> _characters; 
    
    private TableMenu _tableMenu;

    public void characterList()
    {
        Console.Write("\x1B[?47h");
        _loadWindow.AddChild(_loadTitle);
        
        _characters = DatabaseUtils.GetAllCharactersAsDictionary().characters;
        _tableMenu = new TableMenu(_characters, 25, 10, 30, 1);
            
        do
        {
            _loadWindow.AddChild(_tableMenu);
            _loadWindow.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            _tableMenu.HandleInput(key);

            if (_tableMenu.SelectionMade)
            {
                ECharacter character = _tableMenu.GetSelectedItem();
                if (_characters.Count > 0) characterActions(character, _tableMenu, _loadWindow);
                _tableMenu.SelectionMade = false;
            }

            if (key == ConsoleKey.Escape) break;
        } while (true);
        _loadWindow.RemoveChild(_tableMenu);
        Console.Clear();
        Console.Write("\x1B[?47l");
    }

    public void characterActions(ECharacter character, TableMenu tableMenu, Window window)
    {
        Menu actions = new(_menuActions, 43, 16, 14, 1);
        window.RemoveChild(_tableMenu);
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
                        string message = DatabaseUtils.DeleteCharacter(id);
                        Label deleteMessage = new Label(message, 0, 20, null, null, Align.Center);
                        Label pressAny = new Label("Press any key to go back to Character Selection", 0, 33, null, null, Align.Center);
                        _loadWindow.AddChild(deleteMessage);
                        _loadWindow.AddChild(pressAny);
                        _loadWindow.RemoveChild(actions);
                        _loadWindow.RenderAll();
                        _characters.Remove(id);
                        Console.ReadKey();
                        _loadWindow.RemoveChild(deleteMessage);
                        _loadWindow.RemoveChild(pressAny);
                        _loadWindow.RenderAll();
                        
                        break;
                    }
                    else if (selectedItem == "Update")
                    {
                        Update _update = new Update();
                        _loadWindow.RemoveChild(actions);
                        Console.Clear();
                        _update.InjectState(character); 
                        int result = _update.Start();
                        switch (result)
                        {
                            case 0:
                                Console.Clear();
                                break;
                            case 1:
                                _update.SetCharacter();
                                Update(character.Id, _update.NewCharacter);
                                _loadWindow.RemoveChild(actions);
                                break;
                        }
                    }
                    else if (selectedItem == "Show Details")
                    {
                        _loadWindow.RemoveChild(actions);

                        Pane pane = new Pane(15, 10, 67, 22, null)
                        {
                            BorderOn = true
                        };
                        _loadWindow.AddChild(pane);
                        
                        Label name = new Label($"Name: {character.Name}", 0, 12, ConsoleColor.Black, ConsoleColor.Yellow, Align.Center);
                        Label pressAny = new Label("Press any key to go back to Character Selection", 0, 33, null, null, Align.Center);
                        string[] characterDetails = new[]
                        {
                            "Character Details",
                            $"Gender: {character.Gender}",
                            $"Age: {character.Age}",
                            $"Height: {character.Height}",
                        };
                        string[] jewelryDetails = new[]
                        {
                            "Jewelry",
                            $"Watches: {character.Clothing.Jewelry.Watches}",
                            $"Earrings: {character.Clothing.Jewelry.Earrings}",
                            $"Chains: {character.Clothing.Jewelry.Chains}",
                            $"Anklets: {character.Clothing.Jewelry.Anklets}",
                            $"Cufflinks: {character.Clothing.Jewelry.Cufflinks}",
                        };

                        string[] appearanceDetails = new[]
                        {
                            "Appearance",
                            $"Skin Tone: {character.Appearance.SkinTone}",
                            $"Eye Color: {character.Appearance.EyeColor}",
                             $"Hair Style: {character.Appearance.HairStyle}",
                            $"Hair Color: {character.Appearance.HairColor}",
                            $"Faceshape: {character.Appearance.FaceShape}",
                            $"Freckles: {character.Appearance.Freckles}",
                            $"Dimples: {character.Appearance.Dimples}",
                            $"Acne: {character.Appearance.Acne}"
                        };

                        string[] clothingDetails = new[]
                        {
                            "Clothing",
                            $"Top: {character.Clothing.Top.Type} {character.Clothing.Top.Material}",
                            $"Bottom: {character.Clothing.Bottom.Type} {character.Clothing.Bottom.Material}",
                            $"Outerwear: {character.Clothing.OuterWear.OuterWearName} {character.Clothing.OuterWear.OuterWearType}",
                            $"Shoe: {character.Clothing.Shoe}",
                            $"Accessory: {character.Clothing.Accessory}",
                            $"Gloves: {character.Clothing.Gloves}",
                            $"Outfit Themes: {character.Clothing.OutfitTheme}",
                            $"Formal Wear: {character.Clothing.FormalWear}",
                            $"Hat: {character.Clothing.Hat}",
                        };

                        int padLeft = 0;
                        int moveDown = 1;
                        Title details = new Title(characterDetails, 53 + padLeft, 25 + moveDown, null, null, Align.Left);
                        Title jewelry = new Title(jewelryDetails, 20 + padLeft, 23 + moveDown, null, null, Align.Left);
                        Title appearance = new Title(appearanceDetails, 20 + padLeft, 13 + moveDown, null, null, Align.Left);
                        Title clothing = new Title(clothingDetails, 48 + padLeft, 13 + moveDown, null, null, Align.Left);
                        
                        _loadWindow.AddChild(clothing);
                        _loadWindow.AddChild(appearance);
                        _loadWindow.AddChild(jewelry);
                        _loadWindow.AddChild(details);
                        
                        _loadWindow.AddChild(pressAny);
                        _loadWindow.AddChild(name);
                        _loadWindow.RenderAll();

                        Console.ReadKey();
                        
                        _loadWindow.RemoveChild(clothing);
                        _loadWindow.RemoveChild(appearance);
                        _loadWindow.RemoveChild(jewelry);
                        _loadWindow.RemoveChild(details);
                        _loadWindow.RemoveChild(name);
                        _loadWindow.RemoveChild(clothing);
                        _loadWindow.RemoveChild(pressAny);
                        _loadWindow.RemoveChild(pane);
                        
                        _loadWindow.RenderAll();
                        
                        // Console.Clear();
                    }
                    else if (selectedItem == "Back")
                    {
                        break;
                    }

                    actions.SelectionMade = false;
                }
            }
        
        } while (true);
        window.RemoveChild(actions);
        window.RenderAll();
    }

    private void Update(int id, ECharacter character)
    {
        Console.Clear();
        string message = DatabaseUtils.UpdateCharacter(id, character);
        Label deleteMessage = new Label(message, 0, 20, null, null, Align.Center);
        Label pressAny = new Label("Press any key to go back to Character Selection", 0, 33, null, null, Align.Center);
        _loadWindow.AddChild(deleteMessage);
        _loadWindow.AddChild(pressAny);
        _loadWindow.RenderAll();
        _characters.Remove(id);
        Console.ReadKey();
        
        _characters = DatabaseUtils.GetAllCharactersAsDictionary().characters;
        _loadWindow.RemoveChild(deleteMessage);
        _loadWindow.RemoveChild(pressAny);
        _loadWindow.RenderAll();
        
    }

    public void Start()
    {
        characterList();
    }
    
}