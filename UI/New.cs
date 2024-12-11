using FashionDressingGame.Service;
using TUI;

namespace FashionDressingGame.UI;

public class New
{
    public static Character NewCharacter { get; set; } = null!;
    private static Appearance NewAppearance { get; set; } = null!;
    private static Clothing NewClothing { get; set; } = null!;
    private static Top NewTop { get; set; } = null!;
    private static Bottom NewBottom { get; set; } = null!;
    private static Jewelry NewJewelry { get; set; } = null!;
    private static OuterWear NewOuterWear { get; set; } = null!;

    private static Stack<Func<int>> NewActions { get; set; } = null!;
    private static List<Func<int>> NewActionsList { get; set; } = null!;

    public static int WindowHeight = 37;
    public static int WindowWidth = 100;
    
    //Holding Variable
    private static (string Name, string Gender, string Height, string Age) _characterInfo = (null, null, null, null)!;
    
    private static (string Skintone, string Eyecolor, string Haircolor, string Hairstyle, string Faceshape,
        bool Freckles, bool Dimple, bool Acne) _appearanceInfo = (null, null, null, null, null, false, false, false)!;
    
    private static (string? FormalWear, string? ShoeType, string? Accessory, 
        string? Gloves, string? OutfitThemes, string? Hat) _clothingInfo = 
            (null, null, null, null, null, null);

    private static (string? TopType, string? TopMaterial) _topInfo = (null, null);
    private static (string? BottomType, string? BottomMaterial) _bottomInfo = (null, null);
    private static (string? Watches, string? Earrings, string? Chains, string? Anklets, string? Cufflinks)
        _jewelryInfo = (null, null, null, null, null);
    private static (string? Outerwear, string? OuterwearType) _outerwearInfo = (null, null);
    
    //Title 
    private static string[] _whoAreYou =
    [
        "▗▖ ▗▖▗▖ ▗▖ ▗▄▖      ▗▄▖ ▗▄▄▖ ▗▄▄▄▖    ▗▖  ▗▖▗▄▖ ▗▖ ▗▖",
        "▐▌ ▐▌▐▌ ▐▌▐▌ ▐▌    ▐▌ ▐▌▐▌ ▐▌▐▌        ▝▚▞▘▐▌ ▐▌▐▌ ▐▌",
        "▐▌ ▐▌▐▛▀▜▌▐▌ ▐▌    ▐▛▀▜▌▐▛▀▚▖▐▛▀▀▘      ▐▌ ▐▌ ▐▌▐▌ ▐▌",
        "▐▙█▟▌▐▌ ▐▌▝▚▄▞▘    ▐▌ ▐▌▐▌ ▐▌▐▙▄▄▖      ▐▌ ▝▚▄▞▘▝▚▄▞▘",
        "                                                     "
    ];
    
    private static string[] _yourLook =
    [
        "                                                                                   ",
        "                                                                                   ",
        " ██╗   ██╗ ██████╗ ██╗   ██╗██████╗     ██╗      ██████╗  ██████╗ ██╗  ██╗██████╗  ",
        "  ╚██╗ ██╔╝██╔═══██╗██║   ██║██╔══██╗    ██║     ██╔═══██╗██╔═══██╗██║ ██╔╝╚════██╗",
        "  ╚████╔╝ ██║   ██║██║   ██║██████╔╝    ██║     ██║   ██║██║   ██║█████╔╝   ▄███╔╝ ",
        "   ╚██╔╝  ██║   ██║██║   ██║██╔══██╗    ██║     ██║   ██║██║   ██║██╔═██╗   ▀▀══╝  ",
        "    ██║   ╚██████╔╝╚██████╔╝██║  ██║    ███████╗╚██████╔╝╚██████╔╝██║  ██╗  ██╗    ",
        "    ╚═╝    ╚═════╝  ╚═════╝ ╚═╝  ╚═╝    ╚══════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝  ╚═╝    ",
        "                                                                                   "
    ];
    
    private static string[] _yourOotd =
    [
        "                                            ",
        "▗▖  ▗▖▗▄▖ ▗▖ ▗▖▗▄▄▖      ▗▄▖  ▗▄▖▗▄▄▄▖▗▄▄▄  ",
        " ▝▚▞▘▐▌ ▐▌▐▌ ▐▌▐▌ ▐▌    ▐▌ ▐▌▐▌ ▐▌ █  ▐▌  █ ",
        "  ▐▌ ▐▌ ▐▌▐▌ ▐▌▐▛▀▚▖    ▐▌ ▐▌▐▌ ▐▌ █  ▐▌  █ ",
        "  ▐▌ ▝▚▄▞▘▝▚▄▞▘▐▌ ▐▌    ▝▚▄▞▘▝▚▄▞▘ █  ▐▙▄▄▀ ",
        "                                            ",
        "                                            "
    ];
    
    private static Window _characterWindow = new(null, null, WindowWidth, WindowHeight)
    {
        BorderOn = true,
        // GridOn = true,
        BorderHorizontal = '*',
        BorderVertical = '*',
        BorderBackgroundColor = ConsoleColor.White,
        BorderForegroundColor = ConsoleColor.Black,
    };

    private static Window _appearanceWindow = new(null, null, WindowWidth, WindowHeight)
    {
        BorderOn = true,
        BorderHorizontal = '*',
        BorderVertical = '*',
        BorderBackgroundColor = ConsoleColor.White,
        BorderForegroundColor = ConsoleColor.Black,
    };

    private static Window _clothingWindow = new(null, null, WindowWidth, WindowHeight)
    {
        BorderOn = true,
        BorderHorizontal = '*',
        BorderVertical = '*',
        BorderBackgroundColor = ConsoleColor.White,
        BorderForegroundColor = ConsoleColor.Black,
    };

    
    private static Label _valueMissingWarning = new("Values Missing", null,28,null,null, Align.Center);

    private static int _menuWidth = 25;
    private static int _menuX = 25;
    
    //Character Info state
    private static Title _characterTitle = new(_whoAreYou, null, 6, ConsoleColor.Black, ConsoleColor.Magenta, Align.Center);
    private static Label _namelabel = new Label("Name:", 33,14,ConsoleColor.Black,ConsoleColor.DarkBlue, Align.Left);
    private static Label _nameWarning = new Label("", null,15,null,null, Align.Center);
    private static TextBox _nameText = new TextBox(40, 14, 30, 1, 30);
    private static MenuForms _characterMenu = new(Service.Info.Character.CharacterMenu, _menuX, 18, _menuWidth, 10);
    private static Action _addName = () => { _nameText.IsFinalized = false; _characterWindow.AddChild(_nameWarning); 
        _characterWindow.RenderAll(); };
    private static Action _removeName = () => { _characterWindow.RemoveChild(_nameWarning); };
    
    //Appearance Info state
    private static Title _appearanceTitle = new(_yourLook, null, 6, null, null, Align.Center);
    private static MenuForms _appearanceMenu = new(Service.Info.Appearance.AppearanceMenu, _menuX, 16, _menuWidth, 10);
    
    //Clothing Info state
    private static Title _clothingTitle = new(_yourOotd, null, 6, null, null, Align.Center);
    private static MenuForms _clothingMainMenu = new(Service.Info.Clothing.ClothingMenu, _menuX, 12, _menuWidth, 10);
    
    //Top Info state
    private static MenuForms _topMenu = new(Service.Info.Top.TopMenu, _menuX, 13, _menuWidth, 10);
    private static Label _topWarning = new("Values Missing", null,19,null,null, Align.Center);
    
    //Bottom Info state
    private static MenuForms _bottomMenu = new(Service.Info.Bottom.BottomMenu, _menuX, 13, _menuWidth, 10);
    private static Label _bottomWarning = new("Values Missing", null,19,null,null, Align.Center);
    
    //Outerwear Info state
    private static MenuForms _outerWearMenu = new MenuForms(Service.Info.OuterWear.OuterWearMenu, 20, 13, 30, 10);
    private static Label _outerwearWarning = new("Values Missing", null,19,null,null, Align.Center);

    //Jewelry Info state
    private static MenuForms _jewelMenu = new MenuForms(Service.Info.Jewelry.JewelryMenu, _menuX, 13, _menuWidth, 10);
    private static Label _optional = new("OPTIONAL", null,25,null,null, Align.Center);
    
    public static void SetCharacter()
    {
        NewCharacter = new Character(_characterInfo.Name, _characterInfo.Gender, _characterInfo.Height, _characterInfo.Age);
        NewAppearance = new Appearance(_appearanceInfo.Skintone, _appearanceInfo.Eyecolor, _appearanceInfo.Haircolor,
            _appearanceInfo.Hairstyle, _appearanceInfo.Faceshape);
        NewTop = new Top(_topInfo.TopType!, _topInfo.TopMaterial!);
        NewBottom = new Bottom(_bottomInfo.BottomType!, _bottomInfo.BottomMaterial!);
        NewJewelry = new Jewelry(_jewelryInfo.Watches, _jewelryInfo.Earrings, _jewelryInfo.Chains, _jewelryInfo.Anklets, _jewelryInfo.Cufflinks);
        NewOuterWear = new OuterWear(_outerwearInfo.Outerwear!, _outerwearInfo.OuterwearType!);
        NewClothing = new Clothing(NewTop, NewBottom, _clothingInfo.ShoeType!, _clothingInfo.Accessory!, _clothingInfo.Gloves!,
            NewJewelry, _clothingInfo.OutfitThemes!, _clothingInfo.FormalWear!, NewOuterWear, _clothingInfo.Hat!);
    }
    public static void GetCharacterInfo()
    {
        Console.Clear();
        _characterWindow.AddChild(_characterTitle);
        _characterWindow.AddChild(_namelabel);
        _characterWindow.AddChild(_nameWarning);
        _characterWindow.AddChild(_nameText);
        
        bool finalizedName = true;
        ConsoleKeyInfo keyInfo;

        do
        {
            _characterWindow.RenderAll();
            keyInfo = Console.ReadKey(true); 
            _nameText.HandleInput(keyInfo);
            if (_nameText.IsFinalized)
            {
                _characterInfo.Name = _nameText.Text;
                string warningMessage = (_characterInfo.Name switch
                {
                    "" => "Entered name is empty.",
                    var s when string.IsNullOrWhiteSpace(s) => "Name contains only whitespace.",
                    var s when System.Text.RegularExpressions.Regex.IsMatch(s, @"[^\w\s-]") => "Name contains special characters.",
                    _ => null
                })!;

                if (warningMessage != null)
                {
                    _nameWarning.Content = new[] { warningMessage };
                    _addName();
                }
                else
                {
                    finalizedName = false;
                    _removeName();
                }
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                finalizedName = false;
            }
        } while (finalizedName);
        
        do
        {
            _characterWindow.AddChild(_characterMenu);
            _characterWindow.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            _characterMenu.HandleInput(key);

            if (_characterMenu.SelectionMade)
            {
                string selectedItem = _characterMenu.GetSelectedItem();
                if (selectedItem == "Next")
                {
                    if (!_isTupleNullOrEmpty(_characterInfo))
                    {
                        _nameText.IsFinalized = false;
                        _characterMenu.SelectionMade = false;
                        break;
                    }
                    else
                    {
                        _characterWindow.AddChild(_valueMissingWarning);
                    }
                }
                else if (Utilities.ConvertDictionaryValuesToList(Service.Info.Character.CharacterMenu).Contains(selectedItem))
                {
                    _characterWindow.RemoveChild(_valueMissingWarning);
                    var value = ProcessMenu(
                        selectedItem == "Gender" ? Service.Info.Character.Gender :
                        selectedItem == "Height" ? Service.Info.Character.Height :
                        selectedItem == "Age" ? Service.Info.Character.Age :
                        throw new InvalidOperationException("Unexpected selected item"),
                        _characterWindow, _characterMenu, 18, 40, 1);
                    
                    _characterMenu.SetFormValue(selectedItem, value);
                    if (selectedItem == "Gender") _characterInfo.Gender = value;
                    else if (selectedItem == "Height") _characterInfo.Height = value;
                    else _characterInfo.Age = value;
                }

                _characterMenu.SelectionMade = false;
            }
            if (key == ConsoleKey.Escape) break;
        } while (true);
    }
    public static void GetAppearanceInfo()
    {
        _valueMissingWarning.Y = 30;
        _appearanceWindow.AddChild(_appearanceTitle);

        do
        {
            _appearanceWindow.AddChild(_appearanceMenu);
            _appearanceWindow.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            _appearanceMenu.HandleInput(key);

            if (_appearanceMenu.SelectionMade)
            {
                string selectedItem = _appearanceMenu.GetSelectedItem();
                if (selectedItem == "Next")
                {
                    if (!_isTupleNullOrEmpty(_appearanceInfo))
                    {
                        _appearanceMenu.SelectionMade = false;
                        break;
                    }
                    else
                    {
                        _appearanceWindow.AddChild(_valueMissingWarning);
                    }
                }
                else if (selectedItem == "Optional")
                {
                    Dictionary<string, bool> dummy = ProcessCheckbox(Service.Info.Appearance.OptionalMenu, _appearanceWindow, _appearanceMenu, 18);
                    _appearanceMenu.SetFormValue("Optional", "SELECTED");
                    foreach (var kvp in dummy)
                    {
                        if (kvp.Key == "Freckles") _appearanceInfo.Freckles = kvp.Value;
                        else if (kvp.Key == "Dimples") _appearanceInfo.Dimple = kvp.Value;
                        else if (kvp.Key == "Acne") _appearanceInfo.Acne = kvp.Value;
                    }
                }
                else if (Utilities.ConvertDictionaryValuesToList(Service.Info.Appearance.AppearanceMenu).Contains(selectedItem))
                {
                    _appearanceWindow.RemoveChild(_valueMissingWarning);
                    var (dictionary, column, x, y) = selectedItem switch
                    {
                        "Skin Tone" => (Utilities.CreateSequentialDictionary(Service.Info.Appearance.SkinTone), 2, 30,16),
                        "Eye Color" => (Utilities.CreateSequentialDictionary(Service.Info.Appearance.EyeColor), 2, 30, 16),
                        "Hair Style" => (Utilities.CreateSequentialDictionary(Service.Info.Appearance.HairStyles), 3, 20, 15),
                        "Hair Color" => (Utilities.CreateSequentialDictionary(Service.Info.Appearance.HairColor), 3, 20, 16),
                        "Face Shape" => (Utilities.CreateSequentialDictionary(Service.Info.Appearance.FaceShape), 2, 30, 16),
                        _ => throw new InvalidOperationException("Unexpected selected item."),
                    };
                    
                    var value = ProcessMenu(dictionary, _appearanceWindow, _appearanceMenu, y, x, column);
                    
                    _appearanceMenu.SetFormValue(selectedItem, value);
                    if (selectedItem == "Skin Tone") _appearanceInfo.Skintone = value;
                    else if (selectedItem == "Eye Color") _appearanceInfo.Eyecolor = value;
                    else if (selectedItem == "Hair Style") _appearanceInfo.Hairstyle = value;
                    else if (selectedItem == "Hair Color") _appearanceInfo.Haircolor = value;
                    else if (selectedItem == "Face Shape") _appearanceInfo.Faceshape = value;
                }
                _appearanceMenu.SelectionMade = false;
            }

            if (key == ConsoleKey.Escape) break;
        } while (true);
    }
    public static void GetClothingInfo()
    {
        _valueMissingWarning.Y = 34;
        _clothingWindow.AddChild(_clothingTitle);

        do
        {
            _clothingWindow.AddChild(_clothingMainMenu);
            _clothingWindow.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            _clothingMainMenu.HandleInput(key);

            if (_clothingMainMenu.SelectionMade)
            {
                string selectedItem = _clothingMainMenu.GetSelectedItem();
                if (selectedItem == "Next")
                {
                    _clothingMainMenu.SelectionMade = false;
                    if (!_isTupleNullOrEmpty(_clothingInfo)) break;
                    else
                    {
                        _clothingWindow.AddChild(_valueMissingWarning);
                    }
                }
                else if (Utilities.ConvertDictionaryValuesToList(Service.Info.Clothing.ClothingMenu).Contains(selectedItem))
                {
                    _clothingWindow.RemoveChild(_valueMissingWarning);
                    var (dictionary, column, x, y, action) = selectedItem switch
                    {
                        "Top" => (null, 0, 0, 0, new Action(() => GetTopInfo())),
                        "Bottom" => (null, 0, 0, 0, new Action(() => GetBottomInfo())),
                        "Shoe" => (Utilities.CreateSequentialDictionary(Service.Info.Clothing.ShoeType), 3, 20, 13, (Action?)null),
                        "Accessory" => (Utilities.CreateSequentialDictionary(Service.Info.Clothing.Accessories), 3, 20, 13, (Action?)null),
                        "Gloves" => (Utilities.CreateSequentialDictionary(Service.Info.Clothing.Gloves), 1, 40, 13, null),
                        "Jewelry" => (null, 0, 0, 0, new Action((() => GetJewelryInfo()))),
                        "Outfit Themes" => (Utilities.CreateSequentialDictionary(Service.Info.Clothing.OutfitThemes), 3, 20, 13, (Action?)null),
                        "Outer Wear" => (null, 0, 0, 0, new Action( (() => GetOuterWearInfo()))),
                        "Hat" => (Utilities.CreateSequentialDictionary(Service.Info.Clothing.Hats), 3, 20, 13, (Action?)null),
                        "Formal Wear" => (Utilities.CreateSequentialDictionary(Service.Info.Clothing.FormalWear), 1, 40, 13, null),
                        _ => throw new InvalidOperationException("Unexpected selected item."),
                    };

                    if (action != null)
                    {
                        action();
                        if (selectedItem == "Top") _clothingMainMenu.SetFormValue(selectedItem, $"{_topInfo.TopType} : {_topInfo.TopMaterial}");
                        else if (selectedItem == "Bottom") _clothingMainMenu.SetFormValue(selectedItem, $"{_bottomInfo.BottomType} : {_bottomInfo.BottomMaterial}");
                        else if (selectedItem == "Jewelry") _clothingMainMenu.SetFormValue(selectedItem, GetJewelryEmojis(_jewelryInfo));
                        else if (selectedItem == "Outer Wear") _clothingMainMenu.SetFormValue(selectedItem, $"{_outerwearInfo.Outerwear} : {_outerwearInfo.OuterwearType}");
                    }
                    else
                    {
                        var value = ProcessMenu(dictionary!, _clothingWindow, _clothingMainMenu, y, x, column);
                        
                        _clothingMainMenu.SetFormValue(selectedItem, value);
                        if (selectedItem == "Shoe") _clothingInfo.ShoeType = value;
                        else if (selectedItem == "Accessory") _clothingInfo.Accessory = value;
                        else if (selectedItem == "Gloves") _clothingInfo.Gloves = value;
                        else if (selectedItem == "Outfit Themes") _clothingInfo.OutfitThemes = value;
                        else if (selectedItem == "Hat") _clothingInfo.Hat  = value;
                        else if (selectedItem == "Formal Wear") _clothingInfo.FormalWear = value;
                    }
                }
                _clothingMainMenu.SelectionMade = false;
            }
            if (key == ConsoleKey.Escape) break;
            
        } while (true);
        
    }
    private static void GetTopInfo()
    {
        do
        {
            _clothingWindow.RemoveChild(_clothingMainMenu);
            _clothingWindow.AddChild(_topMenu);
            _clothingWindow.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            _topMenu.HandleInput(key);

            if (_topMenu.SelectionMade)
            {
                string selectedItem = _topMenu.GetSelectedItem();
                if (selectedItem == "Next")
                {
                    _topMenu.SelectionMade = false;
                    if (!_isTupleNullOrEmpty(_topInfo)) break;
                    else
                    {
                        _clothingWindow.AddChild(_topWarning);
                    }
                }
                else if (Utilities.ConvertDictionaryValuesToList(Service.Info.Top.TopMenu).Contains(selectedItem))
                {
                    _clothingWindow.RemoveChild(_topWarning);
                    var (dictionary, column, x, y) = selectedItem switch
                    {
                        "Type" => (Utilities.CreateSequentialDictionary(Service.Info.Top.TopType), 3, 20, 13),
                        "Material" => (Utilities.CreateSequentialDictionary(Service.Info.Top.Materials), 3, 20, 13),
                        _ => throw new InvalidOperationException("Unexpected selected item."),
                    };

                    var value = ProcessMenu(dictionary!, _clothingWindow, _topMenu, y, x, column);

                    _topMenu.SetFormValue(selectedItem, value);
                    if (selectedItem == "Type") _topInfo.TopType = value;
                    else if (selectedItem == "Material") _topInfo.TopMaterial = value;
                }
                _topMenu.SelectionMade = false;
                
            }
            if (key == ConsoleKey.Escape) break;
        } while (true);
        
        _clothingWindow.RemoveChild(_topMenu);
        _clothingWindow.RenderAll();
    }
    private static void GetBottomInfo()
    {

        do
        {
            _clothingWindow.RemoveChild(_clothingMainMenu);
            _clothingWindow.AddChild(_bottomMenu);
            _clothingWindow.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            _bottomMenu.HandleInput(key);

            if (_bottomMenu.SelectionMade)
            {
                string selectedItem = _bottomMenu.GetSelectedItem();
                if (selectedItem == "Next")
                {
                    _bottomMenu.SelectionMade = false;
                    if (!_isTupleNullOrEmpty(_bottomInfo)) break;
                    else
                    {
                        _clothingWindow.AddChild(_bottomWarning);
                    }
                }
                else if (Utilities.ConvertDictionaryValuesToList(Service.Info.Bottom.BottomMenu).Contains(selectedItem))
                {
                    _clothingWindow.RemoveChild(_bottomWarning);
                    var (dictionary, column, x, y) = selectedItem switch
                    {
                        "Type" => (Utilities.CreateSequentialDictionary(Service.Info.Bottom.BottomType), 3, 20, 13),
                        "Material" => (Utilities.CreateSequentialDictionary(Service.Info.Bottom.Materials), 3, 20, 13),
                        _ => throw new InvalidOperationException("Unexpected selected item."),
                    };
                    var value = ProcessMenu(dictionary!, _clothingWindow, _bottomMenu, y, x, column);
                    
                    _bottomMenu.SetFormValue(selectedItem, value);
                    if (selectedItem == "Type") _bottomInfo.BottomType = value;
                    else if (selectedItem == "Material") _bottomInfo.BottomMaterial = value;
                }
                _bottomMenu.SelectionMade = false;
            }
            if (key == ConsoleKey.Escape) break;
            
        } while (true);
    
        _clothingWindow.RemoveChild(_bottomMenu);
        _clothingWindow.RenderAll();
    }
    private static void GetOuterWearInfo()
    {
        do
        {
            _clothingWindow.RemoveChild(_clothingMainMenu);
            _clothingWindow.AddChild(_outerWearMenu);
            _clothingWindow.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            _outerWearMenu.HandleInput(key);

            if (_outerWearMenu.SelectionMade)
            {
                string selectedItem = _outerWearMenu.GetSelectedItem();
                if (selectedItem == "Next")
                {
                    _outerWearMenu.SelectionMade = false;
                    if (!_isTupleNullOrEmpty(_outerwearInfo)) break;
                    else
                    {
                        _clothingWindow.AddChild(_outerwearWarning);
                    }
                }
                else if (Utilities.ConvertDictionaryValuesToList(Service.Info.OuterWear.OuterWearMenu)
                         .Contains(selectedItem))
                {
                    _clothingWindow.RemoveChild(_outerwearWarning);
                    var (dictionary, column, x, y) = selectedItem switch
                    {
                        "Outer Wear" => (Utilities.CreateSequentialDictionary(Service.Info.OuterWear.OuterWearName), 3, 20, 13),
                        "Outer Wear Type" => (Utilities.CreateSequentialDictionary(Service.Info.OuterWear.OuterWearType), 2, 29, 13),
                        _ => throw new InvalidOperationException("Unexpected selected item."),
                    };
                    
                    var value = ProcessMenu(dictionary!, _clothingWindow, _outerWearMenu, y, x, column);
                    
                    _outerWearMenu.SetFormValue(selectedItem, value);
                    if (selectedItem == "Outer Wear") _outerwearInfo.Outerwear = value;
                    else if (selectedItem == "Outer Wear Type") _outerwearInfo.OuterwearType = value;
                }
                _outerWearMenu.SelectionMade = false;
            }
            if (key == ConsoleKey.Escape) break;
            
        } while (true);
        _clothingWindow.RemoveChild(_outerWearMenu);
        _clothingWindow.RenderAll();
    }
    private static void GetJewelryInfo()
    {
        do
        {
            _clothingWindow.RemoveChild(_clothingMainMenu);
            _clothingWindow.AddChild(_optional);
            _clothingWindow.AddChild(_jewelMenu);
            _clothingWindow.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            _jewelMenu.HandleInput(key);
            if (_jewelMenu.SelectionMade)
            {
                string selectedItem = _jewelMenu.GetSelectedItem();
                if (selectedItem == "Next")
                {
                    _jewelMenu.SelectionMade = false; 
                    break;
                }
                else if (Utilities.ConvertDictionaryValuesToList(Service.Info.Jewelry.JewelryMenu).Contains(selectedItem))
                {
                    _clothingWindow.RemoveChild(_optional);
                    var (dictionary, column, x, y) = selectedItem switch
                    {
                        "Watches" => (Utilities.CreateSequentialDictionary(Service.Info.Jewelry.Watches), 1, 40, 13),
                        "Earrings" => (Utilities.CreateSequentialDictionary(Service.Info.Jewelry.Earrings), 1, 40, 13 ),
                        "Chains" => (Utilities.CreateSequentialDictionary(Service.Info.Jewelry.Chains), 1, 40, 13),
                        "Anklets" => (Utilities.CreateSequentialDictionary(Service.Info.Jewelry.Anklets), 1, 40, 13),
                        "Cufflinks" => (Utilities.CreateSequentialDictionary(Service.Info.Jewelry.Cufflinks), 1, 40, 13),
                        _ => throw new InvalidOperationException("Unexpected selected item."),
                    };
                    
                    var value = ProcessMenu(dictionary!, _clothingWindow, _jewelMenu, y, x, column);
                    
                    _jewelMenu.SetFormValue(selectedItem, value);
                    if (selectedItem == "Watches") _jewelryInfo.Watches = value;
                    else if (selectedItem == "Earrings") _jewelryInfo.Earrings = value;
                    else if (selectedItem == "Chains") _jewelryInfo.Chains = value;
                    else if (selectedItem == "Anklets") _jewelryInfo.Anklets = value;
                    else if (selectedItem == "Cufflinks") _jewelryInfo.Cufflinks = value;
                }
                _jewelMenu.SelectionMade = false;
            }
            if (key == ConsoleKey.Escape) break;
            
        } while (true);
    
        _clothingWindow.RemoveChild(_jewelMenu);
        _clothingWindow.RemoveChild(_optional);
        _clothingWindow.RenderAll();
    }
    private static string ProcessMenu(Dictionary<int, string> dictionary, Window window, MenuForms mainMenu,int y, int x, int column)
    {
        window.RemoveChild(mainMenu);
        window.RenderAll();

        Menu menu = new(dictionary, x, y, 20, 10) { Columns = column };
        string selectedValue = null;
    
        while (true)
        {
            window.AddChild(menu);
            window.RenderAll();
        
            ConsoleKey key = Console.ReadKey(true).Key;
            menu.HandleInput(key);
        
            if (menu.SelectionMade)
            {
                selectedValue = menu.GetSelectedItem();
                break;
            }
        
            if (key == ConsoleKey.Escape)
                break;
        }

        window.RemoveChild(menu);
        window.RenderAll();
    
        return selectedValue;
    }
    private static Dictionary<string, bool> ProcessCheckbox(Dictionary<int, string> dictionary, Window window, MenuForms mainMenu, int y)
    {
        window.RemoveChild(mainMenu);
        window.RenderAll();

        CheckBox checkboxWidget = new(dictionary, 42, y, 10, 1);

        while (true)
        {
            window.AddChild(checkboxWidget);
            window.RenderAll();
            ConsoleKey key = Console.ReadKey(true).Key;
            checkboxWidget.HandleInput(key);

            if (checkboxWidget.SelectionMade || key == ConsoleKey.Escape)
            {
                break;
            }
        }

        window.RemoveChild(checkboxWidget);
        window.RenderAll();

        return checkboxWidget.CheckedStates;
    }
    
    private static Func<object, bool> _isTupleNullOrEmpty = tuple =>
        tuple.GetType().GetFields().Any(f =>
        {
            var value = f.GetValue(tuple);
            return value switch
            {
                string s => string.IsNullOrEmpty(s), 
                int i => i == 0,                    
                bool b => false,
                _ => value == null                 
            };
        });

    public static Func<(string? Watches, string? Earrings, string? Chains, string? Anklets, string? Cufflinks), string> GetJewelryEmojis = jewelryInfo =>
    {
        var emojiMap = new (string? item, string emoji)[]
        {
            (jewelryInfo.Watches, "[Watch]"),        
            (jewelryInfo.Earrings, "[Earrings]"),    
            (jewelryInfo.Chains, "[Chain]"),         
            (jewelryInfo.Anklets, "[Anklet]"),       
            (jewelryInfo.Cufflinks, "[Cufflinks]")   
        };

        var selectedEmojis = emojiMap.Where(x => x.item != null).Take(2).Select(x => x.emoji).ToList();
    
        if (selectedEmojis.Count < emojiMap.Count(x => x.item != null))
        {
            selectedEmojis.Add("...");
        }

        return string.Join("", selectedEmojis);
    };

    public static void Start()
    {
        
    }
}