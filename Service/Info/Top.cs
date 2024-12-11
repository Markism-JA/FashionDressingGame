namespace FashionDressingGame.Service.Info;

public struct Top
{
    public static Dictionary<int, string> TopMenu { get; } = new()
    {
        { 1, "Type" },
        { 2, "Material"},
        { 3, "Next"}
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
}