using FashionDressingGame.Service;
using FashionDressingGame.Service.Info;
using TUI;

namespace FashionDressingGame.UI;

public static class New
{
    public static Character NewCharacter { get; set; }
    public static int WindowHeight = 37;
    public static int WindowWidth = 100;

    public static void GetCharacterInfo()
    {
        // Initialize character properties
        string name = null, gender = null, height = null, age = null;

        // Initialize the window
        Window window = new(null, null, WindowWidth, WindowHeight)
        {
            // GridOn = true,
            BorderOn = true,
            BorderHorizontal = '*',
            BorderVertical = '*',
            BorderBackgroundColor = ConsoleColor.White,
            BorderForegroundColor = ConsoleColor.Black,
        };

        // Title
        string[] whoAreYou = new[]
        {
            "▗▖ ▗▖▗▖ ▗▖ ▗▄▖      ▗▄▖ ▗▄▄▖ ▗▄▄▄▖    ▗▖  ▗▖▗▄▖ ▗▖ ▗▖",
            "▐▌ ▐▌▐▌ ▐▌▐▌ ▐▌    ▐▌ ▐▌▐▌ ▐▌▐▌        ▝▚▞▘▐▌ ▐▌▐▌ ▐▌",
            "▐▌ ▐▌▐▛▀▜▌▐▌ ▐▌    ▐▛▀▜▌▐▛▀▚▖▐▛▀▀▘      ▐▌ ▐▌ ▐▌▐▌ ▐▌",
            "▐▙█▟▌▐▌ ▐▌▝▚▄▞▘    ▐▌ ▐▌▐▌ ▐▌▐▙▄▄▖      ▐▌ ▝▚▄▞▘▝▚▄▞▘",
            "                                                     "
        };

        Title gameTitle = new(whoAreYou, null, 6, ConsoleColor.Black, ConsoleColor.Magenta, Align.Center);
        window.AddChild(gameTitle);
        
        Label namelabel = new Label("Name:", 33,14,ConsoleColor.Black,ConsoleColor.DarkBlue, Align.Left);
        window.AddChild(namelabel);
        
        TextBox nameText = new TextBox(40, 14, 30, 1, 30);
        window.AddChild(nameText);

        // Main menu
        Menu mainMenu = new(CharacterInfo.CharacterMenu, 40, 18, 20, 10);

        bool finalizedName = true;
        ConsoleKeyInfo keyInfo;
        do
        {
            window.RenderAll();
            keyInfo = Console.ReadKey(true); 
            nameText.HandleInput(keyInfo);
            if (nameText.IsFinalized)
            {
                name = nameText.Text;
                finalizedName = false;
            } else if (keyInfo.Key == ConsoleKey.Escape)
            {
                finalizedName = false;
            }
            
        } while (finalizedName);

        Func<Dictionary<int, string>, int, string> ProcessMenu = (dictionary, y) =>
        {
            window.RemoveChild(mainMenu);
            window.RenderAll();
            Menu menu = new(dictionary, 40, y, 20, 10);
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
        };
        
        ConsoleKey key;
        bool isRunning = true;

        do
        {
            window.AddChild(mainMenu);
            window.RenderAll();
            key = Console.ReadKey(true).Key;
            mainMenu.HandleInput(key);

            if (mainMenu.SelectionMade)
            {
                string selectedItem = mainMenu.GetSelectedItem();
                switch (selectedItem)
                {
                    case "Gender":
                        gender = ProcessMenu(CharacterInfo.Gender, 18);
                        break;
                    case "Height":
                        height = ProcessMenu(CharacterInfo.Height, 18);
                        break;
                    case "Age":
                        age = ProcessMenu(CharacterInfo.Age, 18);
                        break;
                    case "Next":
                        isRunning = false;
                        break;
                }
                mainMenu.SelectionMade = false;

            }

            if (key == ConsoleKey.Escape)
                isRunning = false;

        } while (isRunning);
        NewCharacter = new Character(name, gender, height, age);
    }

    public static void GetAppearance()
    {
        Console.CursorVisible = false;
        string skintone = null, eyecolor = null, haircolor = null, hairstyle = null, faceshaper = null;
        bool freckles = false, dimple = false, acne = false;
        Window window = new(null, null, WindowWidth, WindowHeight)
        {
            // GridOn = true,
            BorderOn = true,
            BorderHorizontal = '*',
            BorderVertical = '*',
            BorderBackgroundColor = ConsoleColor.White,
            BorderForegroundColor = ConsoleColor.Black,
        };
        
        string[] asciiArt = new string[]
        { 
            "                                                                                   ", // Padding at the top
            "                                                                                   ", // More padding rows can be added as needed
            " ██╗   ██╗ ██████╗ ██╗   ██╗██████╗     ██╗      ██████╗  ██████╗ ██╗  ██╗██████╗  ",
            "  ╚██╗ ██╔╝██╔═══██╗██║   ██║██╔══██╗    ██║     ██╔═══██╗██╔═══██╗██║ ██╔╝╚════██╗",
            "  ╚████╔╝ ██║   ██║██║   ██║██████╔╝    ██║     ██║   ██║██║   ██║█████╔╝   ▄███╔╝ ",
            "   ╚██╔╝  ██║   ██║██║   ██║██╔══██╗    ██║     ██║   ██║██║   ██║██╔═██╗   ▀▀══╝  ",
            "    ██║   ╚██████╔╝╚██████╔╝██║  ██║    ███████╗╚██████╔╝╚██████╔╝██║  ██╗  ██╗    ",
            "    ╚═╝    ╚═════╝  ╚═════╝ ╚═╝  ╚═╝    ╚══════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝  ╚═╝    ",
            "                                                                                   "
        };

        Title appearanceTitle = new(asciiArt, null, 4, ConsoleColor.White, null, Align.Center);
        window.AddChild(appearanceTitle);
        
        Menu mainMenu = new(AppearanceInfo.AppearanceMenu, 40, 14, 20, 10);
        
        Func<Dictionary<int, string>, int, int, int, string> ProcessMenu = (dictionary, y, x , column) =>
        {
            window.RemoveChild(mainMenu);
            window.RenderAll();
            Menu menu = new(dictionary, x, y, 20, 10)
            {
                Columns = column
            };
            
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
        };
        
        Func<Dictionary<int, string>, int,  Dictionary<string, bool>> ProcessCheckbox = (dictionary, y) =>
        {
            window.RemoveChild(mainMenu);
            window.RenderAll();

            CheckBox checkboxWidget = new CheckBox(dictionary, 42, y, 10, 1);
            string selectedValue = null;

            while (true)
            {
                window.AddChild(checkboxWidget);
                window.RenderAll();
                ConsoleKey key = Console.ReadKey(true).Key;
                checkboxWidget.HandleInput(key);

                if (checkboxWidget.SelectionMade)
                {
                    break;
                }

                if (key == ConsoleKey.Escape)
                    break;
            }

            window.RemoveChild(checkboxWidget);
            window.RenderAll();
            return checkboxWidget.CheckedStates;
        };
        
        ConsoleKey key;
        bool isRunning = true;

        do
        {
            window.AddChild(mainMenu);
            window.RenderAll();
            key = Console.ReadKey(true).Key;
            mainMenu.HandleInput(key);

            if (mainMenu.SelectionMade)
            {
                string selectedItem = mainMenu.GetSelectedItem();
                switch (selectedItem)
                {
                    case "Skin Tone":
                        skintone = ProcessMenu(Utilities.CreateSequentialDictionary(AppearanceInfo.SkinTone), 14, 30, 2);
                        break;
                    case "Eye Color":
                        eyecolor = ProcessMenu(Utilities.CreateSequentialDictionary(AppearanceInfo.EyeColor), 14, 30 ,2);
                        break;
                    case "Hair Style":
                         hairstyle = ProcessMenu(Utilities.CreateSequentialDictionary(AppearanceInfo.HairStyles), 14, 20, 3);
                        break;
                    case "Hair Color":
                        haircolor = ProcessMenu(Utilities.CreateSequentialDictionary(AppearanceInfo.HairColor), 14, 20, 3);
                        break;
                    case "Face Shape":
                        faceshaper = ProcessMenu(Utilities.CreateSequentialDictionary(AppearanceInfo.FaceShape), 14, 30, 2);
                        break;
                    case "Optional":
                        Dictionary<string, bool> guineaPig = ProcessCheckbox(AppearanceInfo.OptionalMenu, 18);
                        foreach (var kvp in guineaPig)
                        {
                            switch (kvp.Key)
                            {
                                case "Freckles":
                                    freckles = kvp.Value;
                                    break;
                                case "Dimples":
                                    dimple = kvp.Value;
                                    break;
                                case "Acne":
                                    acne = kvp.Value;
                                    break;
                            }
                        }
                        // Console.WriteLine($"freckles = {freckles}, dimples = {dimple}, acne = {acne}");
                        break;
                    case "Next":
                        isRunning = false;
                        break;
                }
                mainMenu.SelectionMade = false;

            }

            if (key == ConsoleKey.Escape)
                isRunning = false;

        } while (isRunning);

        NewCharacter.Appearance = new Appearance(skintone, eyecolor, haircolor, hairstyle, faceshaper);
        NewCharacter.Appearance.Freckles = freckles;
        NewCharacter.Appearance.Dimples = dimple;
        NewCharacter.Appearance.Acne = acne;
    }

    public static void GetClothing()
    {
        Window window = new(null, null, WindowWidth, WindowHeight)
        {
            // GridOn = true,
            BorderOn = true,
            BorderHorizontal = '*',
            BorderVertical = '*',
            BorderBackgroundColor = ConsoleColor.White,
            BorderForegroundColor = ConsoleColor.Black,
        };

        string[] asciiArt = new[]
        {
            "                                            ",
            "▗▖  ▗▖▗▄▖ ▗▖ ▗▖▗▄▄▖      ▗▄▖  ▗▄▖▗▄▄▄▖▗▄▄▄  ",
            " ▝▚▞▘▐▌ ▐▌▐▌ ▐▌▐▌ ▐▌    ▐▌ ▐▌▐▌ ▐▌ █  ▐▌  █ ",
            "  ▐▌ ▐▌ ▐▌▐▌ ▐▌▐▛▀▚▖    ▐▌ ▐▌▐▌ ▐▌ █  ▐▌  █ ",
            "  ▐▌ ▝▚▄▞▘▝▚▄▞▘▐▌ ▐▌    ▝▚▄▞▘▝▚▄▞▘ █  ▐▙▄▄▀ ",
            "                                            ",
            "                                            ",
        };
        
        Title appearanceTitle = new(asciiArt, null, 4, ConsoleColor.Black, ConsoleColor.Magenta, Align.Center);
        window.AddChild(appearanceTitle);

        Menu mainMenu = new(ClothingInfo.ClothingMenu, 40, 14, 20, 10);
        
        Func<Dictionary<int, string>, int, int, int, string> ProcessMenu = (dictionary, y, x , column) =>
        {
            window.RemoveChild(mainMenu);
            window.RenderAll();
            Menu menu = new(dictionary, x, y, 20, 10)
            {
                Columns = column
            };
            
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
        };

        string? toptype = null, topMaterial = null;
        string? bottomtype = null, bottomMaterial = null;
        string shoeType = "";
        string accessory = "";
        string gloves = "";
        string outfitThemes = "";
        string hat = "";

        string? watches = null, earrings = null, chains = null, anklets = null, cufflinks = null;
        string? outerwear = null, outerweartype = null;
        
        ConsoleKey key;
        bool isRunning = true;
         do
        {
            window.AddChild(mainMenu);
            window.RenderAll();
            key = Console.ReadKey(true).Key;
            mainMenu.HandleInput(key);

            if (mainMenu.SelectionMade)
            {
                string selectedItem = mainMenu.GetSelectedItem();
                switch (selectedItem)
                {
                    case "Top":
                        bool topRunning = true;
                        while (topRunning)
                        {
                            switch (ProcessMenu(ClothingInfo.TopMenu, 14, 40, 1))
                            {
                                case "Type":
                                    toptype = ProcessMenu(Utilities.CreateSequentialDictionary(ClothingInfo.TopType), 14, 20, 3);
                                    break;
                                case "Material":
                                    topMaterial = ProcessMenu(Utilities.CreateSequentialDictionary(ClothingInfo.Materials), 14, 20, 3);
                                    break;
                            }
                            
                            if (toptype != null && topMaterial != null) { topRunning = false; }
                        }
                        break;
                    case "Bottom":
                        bool bottomRunning = true;
                        while (bottomRunning)
                        {
                            switch (ProcessMenu(ClothingInfo.TopMenu, 14, 40, 1))
                            {
                                case "Type":
                                    bottomtype = ProcessMenu(Utilities.CreateSequentialDictionary(ClothingInfo.BottomType), 14, 20, 3);
                                    break;
                                case "Material":
                                    bottomMaterial = ProcessMenu(Utilities.CreateSequentialDictionary(ClothingInfo.Materials), 14, 20, 3);
                                    break;
                            }
                            if (bottomtype != null && bottomMaterial != null) { bottomRunning = false; }
                        }
                        break;
                    case "Shoe":
                        shoeType = ProcessMenu(Utilities.CreateSequentialDictionary(ClothingInfo.ShoeType), 14, 20, 3);
                        break;
                    case "Accessory":
                        accessory = ProcessMenu(Utilities.CreateSequentialDictionary(ClothingInfo.Accessories), 14, 20, 3);
                        break;
                    case "Gloves":
                        gloves = ProcessMenu(Utilities.CreateSequentialDictionary(ClothingInfo.Gloves), 14, 20, 3);
                        break;
                    case "Jewelry":
                        bool jewelryRunning = true;
                        while (jewelryRunning)
                        {
                            switch (ProcessMenu(JewelryInfo.JewelryMenu, 14, 40, 1))
                            {
                                case "Watches":
                                    watches = ProcessMenu(Utilities.CreateSequentialDictionary(JewelryInfo.Watches), 14, 20, 3);
                                    break;
                                case "Earrings":
                                    earrings = ProcessMenu(Utilities.CreateSequentialDictionary(JewelryInfo.Earrings), 14, 20, 3);
                                    break;
                                case "Chains":
                                    chains = ProcessMenu(Utilities.CreateSequentialDictionary(JewelryInfo.Chains), 14, 20, 3);
                                    break;
                                case "Anklets":
                                    anklets = ProcessMenu(Utilities.CreateSequentialDictionary(JewelryInfo.Anklets), 14, 20, 3);
                                    break;
                                case "Cufflinks":
                                    cufflinks = ProcessMenu(Utilities.CreateSequentialDictionary(JewelryInfo.Cufflinks), 14, 20, 3);
                                    break;
                            }
                            if (watches != null && earrings != null && chains != null && anklets != null && cufflinks != null) { jewelryRunning = false; }
                        }
                        
                        break;
                    case "Outfit Themes":
                        outfitThemes = ProcessMenu(Utilities.CreateSequentialDictionary(ClothingInfo.OutfitThemes), 14, 20, 3);
                        break;
                    case "OuterWear":
                        bool OuterWearRunning = true;
                        while (OuterWearRunning)
                        {
                            switch (ProcessMenu((ClothingInfo.OuterWearMenu), 14, 42, 1))
                            {
                                case "Outer Wear":
                                    outerwear = ProcessMenu((Utilities.CreateSequentialDictionary(ClothingInfo.OuterWear)), 14, 20, 3);
                                    break;
                                case "Outer Wear Type":
                                    outerweartype = ProcessMenu((Utilities.CreateSequentialDictionary(ClothingInfo.OuterWearType)), 14, 20, 3);
                                    break;
                            }
                            if (outerwear != null && outerweartype != null) { OuterWearRunning = false; }
                        }
                        break;
                    case "Hat":
                        hat = ProcessMenu(Utilities.CreateSequentialDictionary(ClothingInfo.OuterWear), 14, 20, 3);
                        break;
                    case "Next":
                        isRunning = false;
                        break;
                }
                mainMenu.SelectionMade = false;

            }

            if (key == ConsoleKey.Escape)
                isRunning = false;

        } while (isRunning);
    }

    public static void NewPlayer()
    {
        GetCharacterInfo();
        GetAppearance();
        GetClothing();
    }
    
    
}
