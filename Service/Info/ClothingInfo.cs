namespace FashionDressingGame.Service.Info;

public struct ClothingInfo
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
        {8, "OuterWear"},
        {9, "Hat"},
        {10, "Next"}
    };

    public static Dictionary<int, string> TopMenu { get; } = new()
    {
        { 1, "Type" },
        { 2, "Material"},
    };

    public static Dictionary<int, string> OuterWearMenu { get; } = new()
    {
        { 1, "Outer Wear" },
        { 2, "Outer Wear Type"},
    };
    public static Dictionary<string, Grade> TopType { get; } = new()
    {
        { "T-shirt", Grade.Common },
        { "Blouse", Grade.Common },
        { "Hoodie", Grade.Common },
        { "Jacket", Grade.Common },
        { "Sweater", Grade.Common },
        { "Tank Top", Grade.Common },
        { "Cropped Top", Grade.Common },
        { "Button-down Shirt", Grade.Common },
        { "Polo Shirt", Grade.Common },
        { "Cardigan", Grade.Common },
        { "Bodysuit", Grade.Rare },
        { "Crop Hoodie", Grade.Common },
        { "Plaid Shirt", Grade.Common },
        { "Denim Jacket", Grade.Common },
        { "Puffer Jacket", Grade.Rare },
        { "V-neck Shirt", Grade.Common },
        { "Turtle Neck", Grade.Rare },
        { "Crop Sweater", Grade.Common },
        { "Flannel Shirt", Grade.Common },
        { "Peacoat", Grade.Rare },
        { "Zip-up Jacket", Grade.Common },
        { "Vest", Grade.Common },
        { "Kimono", Grade.Rare },
        { "Graphic Tee", Grade.Common },
        { "Sport Jacket", Grade.Rare },
        { "Blazer", Grade.Epic },
        { "Tunic", Grade.Rare },
        { "Bandeau Top", Grade.Rare },
        { "Sheer Top", Grade.Rare },
        { "Wrap Top", Grade.Rare }
    };

    public static Dictionary<string, Grade> Materials { get; } = new()
    {
        { "Silk", Grade.Epic },
        { "Cashmere", Grade.Epic },
        { "Leather", Grade.Epic },
        { "Brocade", Grade.Epic },
        { "Taffeta", Grade.Epic },
        { "Velvet", Grade.Rare },
        { "Linen", Grade.Rare },
        { "Georgette", Grade.Rare },
        { "Hemp Fabric", Grade.Rare },
        { "Bamboo Fabric", Grade.Rare },
        { "Pima Cotton", Grade.Rare },
        { "Suede", Grade.Rare },
        { "Cotton", Grade.Rare },
        { "Denim", Grade.Common },
        { "Wool", Grade.Common },
        { "Satin", Grade.Common },
        { "Jersey", Grade.Common },
        { "Fleece", Grade.Common },
        { "Corduroy", Grade.Common },
        { "Canvas", Grade.Common },
        { "Polyester", Grade.Common },
        { "Rayon", Grade.Common },
        { "Nylon", Grade.Common },
        { "Spandex", Grade.Common },
        { "Acrylic", Grade.Common },
        { "Vegan Leather", Grade.Common },
        { "Knit", Grade.Common },
        { "Tweed", Grade.Common },
        { "Chiffon", Grade.Common },
        { "Tulle", Grade.Common }
    };

    public static Dictionary<string, Grade> BottomType { get; } = new()
    {
        { "Jeans", Grade.Common },
        { "Skirt", Grade.Common },
        { "Shorts", Grade.Common },
        { "Trousers", Grade.Common },
        { "Leggings", Grade.Common },
        { "Capris", Grade.Common },
        { "Cargo Pants", Grade.Common },
        { "Chinos", Grade.Common },
        { "Sweatpants", Grade.Common },
        { "Bell-bottoms", Grade.Rare },
        { "Palazzo Pants", Grade.Rare },
        { "Track Pants", Grade.Common },
        { "Flared Pants", Grade.Rare },
        { "Cargo Shorts", Grade.Common },
        { "Denim Skirt", Grade.Common },
        { "Mini Skirt", Grade.Common },
        { "Maxi Skirt", Grade.Common },
        { "Midi Skirt", Grade.Common },
        { "A-Line Skirt", Grade.Common },
        { "Pencil Skirt", Grade.Rare },
        { "Bermuda Shorts", Grade.Common },
        { "Culottes", Grade.Rare },
        { "Wide-leg Pants", Grade.Rare },
        { "Jumpsuit", Grade.Rare },
        { "Overalls", Grade.Rare },
        { "Skort", Grade.Common },
        { "Paper bag Waist Pants", Grade.Rare },
        { "Leather Pants", Grade.Epic },
        { "Joggers", Grade.Common },
        { "Sweat Shorts", Grade.Common }
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

    public static Dictionary<string, Grade> OuterWear { get; } = new()
    {
        { "Coat", Grade.Epic },
        { "Cardigan", Grade.Epic },
        { "Vest", Grade.Epic },
        { "Blazer", Grade.Epic },
        { "Jacket", Grade.Epic },
        { "Bomber Jacket", Grade.Epic },
        { "Trench Coat", Grade.Epic },
        { "Parka", Grade.Epic },
        { "Raincoat", Grade.Epic },
        { "Windbreaker", Grade.Epic },
        { "Peacoat", Grade.Epic },
        { "Blouson", Grade.Epic },
        { "Faux Fur Coat", Grade.Epic },
        { "Cropped Jacket", Grade.Epic },
        { "Poncho", Grade.Epic },
        { "Cape", Grade.Epic },
        { "Overcoat", Grade.Epic },
        { "Duster Coat", Grade.Epic },

        // Rare (8 points)
        { "Denim Jacket", Grade.Rare },
        { "Hooded Jacket", Grade.Rare },
        { "Puffer Jacket", Grade.Rare },
        { "Chore Coat", Grade.Rare },
        { "Double-breasted Coat", Grade.Rare },

        // Common (5 points)
        { "Kimono", Grade.Common },
        { "Utility Jacket", Grade.Common },
        { "Fleece Jacket", Grade.Common },
        { "Sherpa Coat", Grade.Common },
        { "Double-breasted Blazer", Grade.Common },
        { "Mac Coat", Grade.Common },
        { "Tailored Jacket", Grade.Common }
    };

    public static Dictionary<string, Grade> OuterWearType = new()
    {
        // Epic (10 points)
        { "Pea Coat", Grade.Epic },
        { "Motorcycle Jacket", Grade.Epic },
        { "Vest", Grade.Epic },
        { "Trench Coat", Grade.Epic },
        { "Topcoat", Grade.Epic },

        // Rare (8 points)
        { "Duffel", Grade.Rare },
        { "Swing Coat", Grade.Rare },

        // Common (5 points)
        { "Blazer", Grade.Common },
        { "Denim", Grade.Common },
        { "Cardigan", Grade.Common }
    };
}