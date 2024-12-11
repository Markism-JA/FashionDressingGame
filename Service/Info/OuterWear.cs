namespace FashionDressingGame.Service.Info;

public struct OuterWear
{
    public static Dictionary<int, string> OuterWearMenu { get; } = new()
    {
        { 1, "Outer Wear" },
        { 2, "Outer Wear Type"},
        { 3, "Next"},
    };
    
    public static Dictionary<string, Grade> OuterWearName { get; } = new()
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
        { "Double Breast Blazer", Grade.Common },
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