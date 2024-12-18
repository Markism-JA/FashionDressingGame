using FashionDressingGame.Database;
using FashionDressingGame.Service;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TUI;

namespace FashionDressingGame.UI;

public class Load
{
    private static string[] _characterListText =
    [
        " ▗▄▄▖▗▖ ▗▖ ▗▄▖ ▗▄▄▖  ▗▄▖  ▗▄▄▖▗▄▄▄▖▗▄▄▄▖▗▄▄▖     ▗▖   ▗▄▄▄▖ ▗▄▄▖▗▄▄▄▖",
        "▐▌   ▐▌ ▐▌▐▌ ▐▌▐▌ ▐▌▐▌ ▐▌▐▌     █  ▐▌   ▐▌ ▐▌    ▐▌     █  ▐▌     █  ",
        "▐▌   ▐▛▀▜▌▐▛▀▜▌▐▛▀▚▖▐▛▀▜▌▐▌     █  ▐▛▀▀▘▐▛▀▚▖    ▐▌     █   ▝▀▚▖  █  ",
        "▝▚▄▄▖▐▌ ▐▌▐▌ ▐▌▐▌ ▐▌▐▌ ▐▌▝▚▄▄▖  █  ▐▙▄▄▖▐▌ ▐▌    ▐▙▄▄▖▗▄█▄▖▗▄▄▞▘  █  "
    ];

    private static string[] _loadText =
    [
        "██╗      ██████╗  █████╗ ██████╗ ",
        "██║     ██╔═══██╗██╔══██╗██╔══██╗",
        "██║     ██║   ██║███████║██║  ██║",
        "██║     ██║   ██║██╔══██║██║  ██║",
        "███████╗╚██████╔╝██║  ██║██████╔╝",
        "╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝ ",
        "                                 "
    ];

    private static Dictionary<int, string> _menuActionsSpecific = new Dictionary<int, string>()
    {
        {1, "Delete"},
        {2, "Update"},
        {3, "Show Details"},
        {4, "Back"}
    };

    private static Dictionary<int, string> _menuActionsAll = new Dictionary<int, string>()
    {
        {1, "Delete"},
        {2, "Update"},
        {3, "Back"},
    };

    private static Dictionary<int, string> _loadMenu = new Dictionary<int, string>()
    {
        { 1, "View All Characters" },
        { 2, "View a specific character" },
        { 3, "Back to Main Menu" },
    };

    private static Dictionary<int, string> _YesNo = new Dictionary<int, string>()
    {
        { 1, "Yes" },
        { 2, "No" }
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

    private Title _characterListTitle = new Title(_characterListText, null, 5, null, null, Align.Center);
    private Title _loadTitle = new Title(_loadText, null, 9, null, null, Align.Center);
    
    private Dictionary<int, ECharacter> _characters;

    //MainMenu
    private Menu _menu = new Menu(_loadMenu, 35, 15, 30, 0);
    
    //YesNo
    private Menu _yesNoMenu = new Menu(_YesNo, 45, 18, 5, 0)
    {
        Columns = 2
    };
    
    //ActionsMenu
    private Menu _actions;
    
    //All Characters
    private Table _table;
    
    //SingleCharacter
    private TableMenu _tableMenu;
    private Title _details;
    private Title _jewelry;
    private Title _appearance;
    private Title _clothing;
    private Label _name;
    private List<ECharacter> _charactersList;

    public void ViewSpecific()
    {
        LoadCharactersViewSpecific();
        do
        {
            _loadWindow.AddChild(_tableMenu);
            _loadWindow.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            
            if (_characters.Count > 0) _tableMenu.HandleInput(key);

            if (_tableMenu.SelectionMade)
            {
                ECharacter character = _tableMenu.GetSelectedItem();
                if (_characters.Count > 0) ActionsSpecific(character);
                _tableMenu.SelectionMade = false;
            }

            if (key == ConsoleKey.Escape) break;
        } while (true);

        _tableMenu.SelectionMade = false;
        _loadWindow.RemoveChild(_tableMenu);
        _loadWindow.RemoveChild(_characterListTitle);
        _loadWindow.RenderAll();
    }

    public void ViewAll() 
    {
    LoadCharactersViewAll();
    _loadWindow.RemoveChild(_menu);
    _loadWindow.RemoveChild(_loadTitle);
    
    _loadWindow.AddChild(_characterListTitle);
    LoadCharactersViewAll();
    
    int currentIndex = 0;

    Action<int> UpdateCharacterDetails = (index) => 
    {
    // Validate if the list is empty or if the index is invalid
    if (_charactersList == null || _charactersList.Count == 0)
    {
        return; // Exit the method if the list is empty
    }

    if (index < 0 || index >= _charactersList.Count)
    {
        return; // Exit the method if the index is out of range
    }

    // Proceed with updating character details if validation passes
    ECharacter character = _charactersList[index];

    _name = new Label($"Name: {character.Name}", 0, 11, ConsoleColor.Black, ConsoleColor.Yellow, Align.Center);
    string[] characterDetails = new[]
    {
        "Character Details",
        $"Gender: {character.Gender}",
        $"Age: {character.Age}",
        $"Height: {character.Height}",
        $"Grade: {character.CharacterGrade}"
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
        $"Skin Tone: {GetValue(character.Appearance.SkinTone)}",
        $"Eye Color: {GetValue(character.Appearance.EyeColor)}",
        $"Hair Style: {GetValue(character.Appearance.HairStyle)}",
        $"Hair Color: {GetValue(character.Appearance.HairColor)}",
        $"Face Shape: {GetValue(character.Appearance.FaceShape)}",
        $"Freckles: {GetValue(character.Appearance.Freckles.ToString())}",
        $"Dimples: {GetValue(character.Appearance.Dimples.ToString())}",
        $"Acne: {GetValue(character.Appearance.Acne.ToString())}"
    };

    string[] clothingDetails = new[]
    {
        "Clothing",
        $"Top: {GetValue(character.Clothing.Top.Type + " " + character.Clothing.Top.Material)}",
        $"Bottom: {GetValue(character.Clothing.Bottom.Type + " " + character.Clothing.Bottom.Material)}",
        $"Outerwear: {GetValue(character.Clothing.OuterWear.OuterWearName + " " + character.Clothing.OuterWear.OuterWearType)}",
        $"Shoe: {GetValue(character.Clothing.Shoe)}",
        $"Accessory: {GetValue(character.Clothing.Accessory)}",
        $"Gloves: {GetValue(character.Clothing.Gloves)}",
        $"Outfit Themes: {GetValue(character.Clothing.OutfitTheme)}",
        $"Formal Wear: {GetValue(character.Clothing.FormalWear)}",
        $"Hat: {GetValue(character.Clothing.Hat)}",
    };

    // Add the new character details
    _details = new Title(characterDetails, 53, 25, null, null, Align.Left);
    _jewelry = new Title(jewelryDetails, 20, 23, null, null, Align.Left);
    _appearance = new Title(appearanceDetails, 19, 13, null, null, Align.Left);
    _clothing = new Title(clothingDetails, 48, 13, null, null, Align.Left);

    _loadWindow.AddChild(_name);
    _loadWindow.AddChild(_clothing);
    _loadWindow.AddChild(_appearance);
    _loadWindow.AddChild(_jewelry);
    _loadWindow.AddChild(_details);
};

    Pane pane = new Pane(15, 10, 67, 22, null)
    {
        BorderOn = true
    };
    _loadWindow.AddChild(pane);
    Label pressAny = new Label("Press left/right arrow to browse, Enter to select and Escape to go back.", 0, 33, null, null, Align.Center);
    _loadWindow.AddChild(pressAny);
    
    UpdateCharacterDetails(currentIndex);

    if (_charactersList.Count == 0)
    {   _loadWindow.RemoveChild(_name);
        _loadWindow.RemoveChild(_details);
        _loadWindow.RemoveChild(_jewelry);
        _loadWindow.RemoveChild(_appearance);
        _loadWindow.RemoveChild(_clothing);
        _loadWindow.RemoveChild(pane);
        _loadWindow.RemoveChild(pressAny);
        Label noCharacters = new Label("No Characters, Press Escape to go back to load menu to reload or add characters.", 0, 10, ConsoleColor.Black, ConsoleColor.Red, Align.Center);
        _loadWindow.AddChild(noCharacters);
        _loadWindow.RenderAll();
        Console.ReadKey();
        
        _loadWindow.RemoveChild(_characterListTitle);
        _loadWindow.RemoveChild(noCharacters);
        return; // Exit early if no characters are available
    }
    
    while (true)
    {
        // Check if the character list is empty within the loop
        if (_charactersList.Count == 0)
        {
            Label noCharacters = new Label("No Characters, Press Escape to go back to load menu to reload or add characters.", 0, 10, ConsoleColor.Black, ConsoleColor.Red, Align.Center);
            _loadWindow.AddChild(noCharacters);
            _loadWindow.RenderAll();
            Console.ReadKey();
            _loadWindow.RemoveChild(_characterListTitle);
            _loadWindow.RemoveChild(noCharacters);

            break; // Exit the loop if the list is empty
        }

        _loadWindow.RenderAll();
        var key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.LeftArrow)
        {
            if (currentIndex > 0) currentIndex--;
            _loadWindow.RemoveChild(_name);
            _loadWindow.RemoveChild(_details);
            _loadWindow.RemoveChild(_jewelry);
            _loadWindow.RemoveChild(_appearance);
            _loadWindow.RemoveChild(_clothing);

            UpdateCharacterDetails(currentIndex);
        } 
        else if (key == ConsoleKey.RightArrow)
        {
            if (currentIndex < _charactersList.Count - 1) currentIndex++;
            _loadWindow.RemoveChild(_name);
            _loadWindow.RemoveChild(_details);
            _loadWindow.RemoveChild(_jewelry);
            _loadWindow.RemoveChild(_appearance);
            _loadWindow.RemoveChild(_clothing);

            UpdateCharacterDetails(currentIndex);
        } 
        else if (key == ConsoleKey.Enter)
        {
            _loadWindow.RemoveChild(_name);
            _loadWindow.RemoveChild(_details);
            _loadWindow.RemoveChild(_jewelry);
            _loadWindow.RemoveChild(_appearance);
            _loadWindow.RemoveChild(_clothing);
            _loadWindow.RemoveChild(pane);
            _loadWindow.RemoveChild(pressAny);
            
            ECharacter selectedCharacter = _charactersList[currentIndex];
            ActionsAll(selectedCharacter);

            if (_charactersList.Count != 0)
            {
                _loadWindow.AddChild(pane);
                _loadWindow.AddChild(pressAny);
                _loadWindow.AddChild(_name);
                _loadWindow.AddChild(_clothing);
                _loadWindow.AddChild(_appearance);
                _loadWindow.AddChild(_jewelry);
                _loadWindow.AddChild(_details);
            }
       
        }
        else if (key == ConsoleKey.Escape) break;
    }

    _loadWindow.RemoveChild(_name);
    _loadWindow.RemoveChild(_details);
    _loadWindow.RemoveChild(_jewelry);
    _loadWindow.RemoveChild(_appearance);
    _loadWindow.RemoveChild(_clothing);
    _loadWindow.RemoveChild(_characterListTitle);
    _loadWindow.RemoveChild(pane);
    _loadWindow.RemoveChild(pressAny);
}

    public void LoadGame()
    {
        Console.Write("\x1B[?47h");
        do
        {
            _loadWindow.AddChild(_loadTitle);
            _loadWindow.AddChild(_menu);
            _loadWindow.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            _menu.HandleInput(key);

            if (_menu.SelectionMade)
            {
                string selectedItem = _menu.GetSelectedItem();
                if (selectedItem == "Back to Main Menu")
                {
                    _menu.SelectionMade = false;
                    break;
                } else if (Utilities.ConvertDictionaryValuesToList(_loadMenu).Contains(selectedItem))
                {
                    _loadWindow.RemoveChild(_menu);
                    _loadWindow.RemoveChild(_loadTitle);
                    _menu.SelectionMade = false;
                    if (selectedItem == "View All Characters") ViewAll();
                    else if (selectedItem == "View a specific character") ViewSpecific();
                }
            }
        } while (true);
        Console.Clear();
        Console.Write("\x1B[?47l");
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
    private void Delete(ECharacter character)
    {
        int x = 25;
        int y = 13;
        Pane pane = new Pane(x, y, 50, 10, ConsoleColor.Red)
        {
            BorderVertical = '|',
            BorderHorizontal = '=',
            BorderBackgroundColor = ConsoleColor.Red,
            BorderForegroundColor = ConsoleColor.Black,
        };

        string[] warning = new[]
        {
            "Delete this character?"
        };
        Title confirmation = new Title(warning, null, y + 3, ConsoleColor.Black, ConsoleColor.Red, Align.Center );
        
        _loadWindow.AddChild(pane);
        _loadWindow.AddChild(confirmation);

        do
        {
            _loadWindow.AddChild(_yesNoMenu);
            _loadWindow.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            _yesNoMenu.HandleInput(key);

            if (_yesNoMenu.SelectionMade)
            {
                if (_yesNoMenu.GetSelectedItem() == "Yes")
                {
                    int id = character.Id;
                    string message = DatabaseUtils.DeleteCharacter(id);
                    Label deleteMessage = new Label(message, 0, 24, null, null, Align.Center);
                    Label pressAny = new Label("Press any key to go back to Character Selection", 0, 33, null, null,
                        Align.Center);
                    _loadWindow.AddChild(deleteMessage);
                    _loadWindow.AddChild(pressAny);
                    _loadWindow.RemoveChild(_actions);
                    _loadWindow.RenderAll();
                    Console.ReadKey();
                    _loadWindow.RemoveChild(deleteMessage);
                    _loadWindow.RemoveChild(pressAny);
                    _loadWindow.RenderAll();
                    break;
                }
                else if (_yesNoMenu.GetSelectedItem() == "No")
                {
                    break;
                }
            }
            
        } while (true);
        
        _yesNoMenu.SelectionMade = false;
        _loadWindow.RemoveChild(confirmation);
        _loadWindow.RemoveChild(pane);
        _loadWindow.RemoveChild(_yesNoMenu);
        _loadWindow.RenderAll();
    }

    public void ActionsAll(ECharacter character)
    {
        _actions = new(_menuActionsAll, 43, 16, 14, 1);
        do
        {
            _loadWindow.AddChild(_actions);
            _loadWindow.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            _actions.HandleInput(key);

            if (_actions.SelectionMade)
            {
                string selectedItem = _actions.GetSelectedItem();
                if (Utilities.ConvertDictionaryValuesToList(_menuActionsAll).Contains(selectedItem))
                {
                    if (selectedItem == "Delete")
                    {
                        Delete(character);
                        _actions.SelectionMade = false;
                        LoadCharactersViewAll();
                    }
                    else if (selectedItem == "Update")
                    {
                        _actions.SelectionMade = false;
                        Update _update = new Update();
                        _loadWindow.RemoveChild(_actions);
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
                                _loadWindow.RemoveChild(_actions);
                                LoadCharactersViewSpecific();
                                break;
                        }
                        LoadCharactersViewAll();
                    }
                    else if (selectedItem == "Back")
                    {
                        _actions.SelectionMade = false;
                        break;
                    }

                }

            }
        } while (true);
        
        _actions.SelectionMade = false;
        _loadWindow.RemoveChild(_actions);
    }
    
    //SpecificOptions
    public void ActionsSpecific(ECharacter character)
    {
        _actions = new(_menuActionsSpecific, 43, 16, 14, 1);
        _loadWindow.RemoveChild(_tableMenu);
        do
        {
            _loadWindow.AddChild(_actions);
            _loadWindow.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            _actions.HandleInput(key);

            if (_actions.SelectionMade)
            {
                string selectedItem = _actions.GetSelectedItem();
            
                if (Utilities.ConvertDictionaryValuesToList(_menuActionsSpecific).Contains(selectedItem))
                {
                    if (selectedItem == "Delete")
                    {
                        Delete(character);
                        _actions.SelectionMade = false;
                    }
                    else if (selectedItem == "Update")
                    {
                        Update _update = new Update();
                        _loadWindow.RemoveChild(_actions);
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
                                _loadWindow.RemoveChild(_actions);
                                LoadCharactersViewSpecific();
                                break;
                        }
                    }
                    else if (selectedItem == "Show Details")
                    {
                        _loadWindow.RemoveChild(_actions);

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
                            $"Outerwear: {GetValue(character.Clothing.OuterWear.OuterWearName + " " + character.Clothing.OuterWear.OuterWearType)}",
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
                        Title appearance = new Title(appearanceDetails, 19 + padLeft, 13 + moveDown, null, null, Align.Left);
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
                        
                    }
                    else if (selectedItem == "Back")
                    {
                        break;
                    }

                    _actions.SelectionMade = false;
                }
            }
        
        } while (true);

        _actions.SelectionMade = false;
        _loadWindow.RemoveChild(_actions);
        _loadWindow.RenderAll();
    }
    private void LoadCharactersViewSpecific()
    {
        _loadWindow.AddChild(_characterListTitle);
        _characters = DatabaseUtils.GetAllCharactersAsDictionary().characters.OrderByDescending(pair => pair.Value.CharacterGrade).ToDictionary(pair => pair.Key, pair => pair.Value);
        _tableMenu = new TableMenu(_characters, 25, 10, 30, 1);
    }

    //AllOptions
    private void LoadCharactersViewAll()
    {
        _charactersList = DatabaseUtils.GetAllCharactersAsDictionary().characters.Values.ToList();
    }

    public void Start()
    {
        LoadGame();
    }
    
    private static string GetValue(string s)
    {
        if (s.Length > 22) return s.Substring(0, 19) + "...";
        else return s;
    }
    
}