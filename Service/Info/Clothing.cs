namespace FashionDressingGame.Service.Info;

public struct Clothing
{
    public static Dictionary<int, string> ClothingMenu { get; } = new()
    {
        {1, "Top"},
        {2, "Bottom"},
        {3, "Shoe"},
        {4, "Accessory"},
        {5, "Gloves"},
        {6, "Jewelry"},
        {7, "Outfit Themes"},
        {8, "Outer Wear"},
        {9, "Hat"},
        {10, "Formal Wear"},
        {11, "Next"}
    };
    
    public static Dictionary<string, Grade> ShoeType = new()
    {
        // Epic (10 points)
        { "Stiletto Heels", Grade.Epic },
        { "Uggs", Grade.Epic },
        { "Snow Boots", Grade.Epic },

        // Rare (8 points)
        { "Hiking Boots", Grade.Rare },
        { "Chunky Heels", Grade.Rare },

        // Common (5 points)
        { "Sneakers", Grade.Common },
        { "Boots", Grade.Common },
        { "Flats", Grade.Common },
        { "Loafers", Grade.Common },
        { "Sandals", Grade.Common },
        { "Wedges", Grade.Common },
        { "Ballet Flats", Grade.Common },
        { "High-top Sneakers", Grade.Common },
        { "Ankle Boots", Grade.Common },
        { "Combat Boots", Grade.Common },
        { "Chelsea Boots", Grade.Common },
        { "Pumps", Grade.Common },
        { "Espadrilles", Grade.Common },
        { "Mules", Grade.Common },
        { "Oxfords", Grade.Common },
        { "Slip-ons", Grade.Common },
        { "Platform Shoes", Grade.Common },
        { "Running Shoes", Grade.Common },
        { "Dress Shoes", Grade.Common },
        { "Mary Janes", Grade.Common },
        { "Clogs", Grade.Common },
        { "Peep-toe Heels", Grade.Common },
        { "Boat Shoes", Grade.Common },
        { "Flip-flops", Grade.Common },
        { "Heels", Grade.Common }
    };

    public static Dictionary<string, Grade> Accessories = new()
    {
        // Epic (10 points)
        { "Umbrella", Grade.Epic },
        { "Pocket Watch", Grade.Epic },
        { "Brooch", Grade.Epic },

        // Rare (8 points)
        { "Bowtie", Grade.Rare },
        { "Sling Bag", Grade.Rare },
        { "Tote Bag", Grade.Rare },

        // Common (5 points)
        { "Scarf", Grade.Common },
        { "Belts", Grade.Common },
        { "Necklace", Grade.Common },
        { "Glasses", Grade.Common },
        { "Rings", Grade.Common },
        { "Bracelets", Grade.Common },
        { "Headbands", Grade.Common },
        { "Earmuffs", Grade.Common },
        { "Hair Clips", Grade.Common },
        { "Mittens", Grade.Common },
        { "Tie", Grade.Common },
        { "Key chain", Grade.Common },
        { "Handbag", Grade.Common },
        { "Backpack", Grade.Common },
        { "Purse", Grade.Common },
        { "Phone", Grade.Common },
        { "Earbuds", Grade.Common },
        { "Briefcase", Grade.Common },
        { "Hairclips", Grade.Common },
        { "Hairpin", Grade.Common },
        { "Socks", Grade.Common },
        { "Scrunchies", Grade.Common },
        { "Stockings", Grade.Common },
        { "Floaters", Grade.Common }
    };

    public static Dictionary<string, Grade> Hats = new()
    {
        // Epic (10 points)
        { "Fedora", Grade.Epic },
        { "Turban", Grade.Epic },
        { "Balaclava", Grade.Epic },

        // Rare (8 points)
        { "Beanie", Grade.Rare },
        { "Bucket", Grade.Rare },
        { "Beret", Grade.Rare },

        // Common (5 points)
        { "Durag", Grade.Common },
        { "Bandana", Grade.Common },
        { "Beach", Grade.Common },
        { "Streets", Grade.Common },
        { "Ghutra", Grade.Common },
        { "Paperboy", Grade.Common },
        { "Safari", Grade.Common },
        { "Fancy", Grade.Common },
        { "Sailor", Grade.Common }
    };

    public static Dictionary<string, Grade> Gloves = new()
    {
        // Epic (10 points)
        { "Punk", Grade.Epic },
        { "Cut-out", Grade.Epic },

        // Rare (8 points)
        { "Winter", Grade.Rare },
        { "Leather", Grade.Rare },

        // Common (5 points)
        { "Crochet", Grade.Common }
    };

    public static Dictionary<string, Grade> OutfitThemes = new()
    {
        // Epic (10 points)
        { "Fantasy", Grade.Epic },
        { "Cyberpunk", Grade.Epic },
        { "Steampunk", Grade.Epic },

        // Rare (8 points)
        { "Preppy", Grade.Rare },
        { "Streetwear", Grade.Rare },
        { "Tropical", Grade.Rare },

        // Common (5 points)
        { "Casual", Grade.Common },
        { "Gothic", Grade.Common },
        { "Formal", Grade.Common },
        { "Bohemian", Grade.Common },
        { "Retro", Grade.Common },
        { "Sporty", Grade.Common },
        { "Chic", Grade.Common },
        { "Punk", Grade.Common },
        { "Vintage", Grade.Common },
        { "Business", Grade.Common },
        { "Classic", Grade.Common },
        { "Elegant", Grade.Common },
        { "Hipster", Grade.Common },
        { "Artsy", Grade.Common },
        { "Urban", Grade.Common },
        { "Rockstar", Grade.Common },
        { "Military", Grade.Common },
        { "Fairy Tale", Grade.Common },
        { "Minimalist", Grade.Common },
        { "Maximalist", Grade.Common },
        { "Renaissance", Grade.Common },
        { "Ski Wear", Grade.Common },
        { "Festival", Grade.Common },
        { "Glam", Grade.Common }
    };

    public static Dictionary<string, Grade> FormalWear = new()
    {
        // Epic (10 points)
        { "Black Tie", Grade.Epic },
        { "Evening Gown", Grade.Epic },

        // Rare (8 points)
        { "Tuxedo", Grade.Rare },
        { "Semi-formal", Grade.Rare },

        // Common (5 points)
        { "Wedding", Grade.Common },
        { "Cocktail", Grade.Common },
        { "Business", Grade.Common },
        { "Casual", Grade.Common },
        { "Smart Casual", Grade.Common }
    };

}