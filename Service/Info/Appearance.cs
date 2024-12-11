namespace FashionDressingGame.Service.Info;

public struct Appearance
{
    public static Dictionary<int, string> AppearanceMenu = new()
    {
        {1, "Skin Tone"},
        {2, "Eye Color"},
        {3, "Hair Style"},
        {4, "Hair Color"},
        {5, "Face Shape"},
        {6, "Optional"},
        {7, "Next"}
    };

    public static Dictionary<int, string> OptionalMenu = new()
    {
        {1, "Freckles"},
        {2, "Dimples"},
        {3, "Acne"},
    };
    public static Dictionary<string, Grade> SkinTone = new()
    {
        { "Porcelain", Grade.Common },
        { "Fair", Grade.Common },
        { "Light Beige", Grade.Common },
        { "Medium Beige", Grade.Common },
        { "Olive", Grade.Common },
        { "Tan", Grade.Common },
        { "Caramel", Grade.Common },
        { "Café au Lait", Grade.Common },
        { "Chestnut", Grade.Common },
        { "Ebony", Grade.Common }
    };

    public static Dictionary<string, Grade> EyeColor { get; } = new()
    {
        // Epic (10 points)
        { "Amber Violet", Grade.Epic },
        { "Turquoise", Grade.Epic },

        // Rare (8 points)
        { "Blue", Grade.Rare },
        { "Light Blue", Grade.Rare },
        { "Olive Green", Grade.Rare },
        { "Golden Brown", Grade.Rare },

        // Common (5 points)
        { "Green", Grade.Common },
        { "Hazel", Grade.Common },
        { "Silver", Grade.Common },
        { "Black", Grade.Common }
    };

    public static Dictionary<string, Grade> HairStyles { get; } = new()
    {
        // Epic (10 points)
        { "Braided Crown", Grade.Epic },
        { "Afro", Grade.Epic },
        { "Mohawk", Grade.Epic },

        // Rare (8 points)
        { "Dreadlocks", Grade.Rare },
        { "Pixie Cut", Grade.Rare },
        { "Bald", Grade.Rare },

        // Common (5 points)
        { "Straight", Grade.Common },
        { "Wavy", Grade.Common },
        { "Curly", Grade.Common },
        { "Coily", Grade.Common },
        { "Kinky", Grade.Common },
        { "Loose Waves", Grade.Common },
        { "Beach Waves", Grade.Common },
        { "Sleek Straight", Grade.Common },
        { "Voluminous", Grade.Common },
        { "Buzz Cut", Grade.Common },
        { "Pigtails", Grade.Common },
        { "Spiky", Grade.Common },
        { "Bob Cut", Grade.Common },
        { "Long Hair", Grade.Common },
        { "Medium Length", Grade.Common },
        { "Braided", Grade.Common },
        { "Wolf Cut", Grade.Common },
        { "Messy Bun", Grade.Common },
        { "Ponytail", Grade.Common },
        { "Curtain Bangs", Grade.Common },
        { "Caesar Cut", Grade.Common },
        { "Slick Back", Grade.Common },
        { "Mullet", Grade.Common },
        { "Undercut", Grade.Common }
    };

    public static Dictionary<string, Grade> HairColor { get; } = new()
    {
        // Epic (10 points)
        { "Pink", Grade.Epic },
        { "Blue", Grade.Epic },
        { "Purple", Grade.Epic },
        { "Green", Grade.Epic },

        // Rare (8 points)
        { "Platinum Blonde", Grade.Rare },
        { "Caramel", Grade.Rare },
        { "Honey Blonde", Grade.Rare },

        // Common (5 points)
        { "Brown", Grade.Common },
        { "Black", Grade.Common },
        { "Blonde", Grade.Common },
        { "Red", Grade.Common },
        { "Auburn", Grade.Common },
        { "Chestnut", Grade.Common },
        { "Silver", Grade.Common },
        { "Gray", Grade.Common }
    };

    public static Dictionary<string, Grade> FaceShape { get; } = new()
    {
        { "Diamond", Grade.Epic },
        { "Inverted Triangle", Grade.Epic },
        { "Triangular", Grade.Rare },
        { "Pear-Shaped", Grade.Rare },
        { "Round", Grade.Common },
        { "Oval", Grade.Common },
        { "Heart-shaped", Grade.Common },
        { "Square", Grade.Common },
        { "Rectangular", Grade.Common },
        { "Oblong", Grade.Common }
    };
}