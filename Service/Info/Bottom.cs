namespace FashionDressingGame.Service.Info;

public struct Bottom
{
    public static Dictionary<int, string> BottomMenu { get; } = new()
    {
        { 1, "Type" },
        { 2, "Material"},
        { 3, "Next"}
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
        { "Paper bag Waist", Grade.Rare },
        { "Leather Pants", Grade.Epic },
        { "Joggers", Grade.Common },
        { "Sweat Shorts", Grade.Common }
    };
}