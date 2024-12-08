namespace FashionDressingGame.Service.Info;

public struct JewelryInfo
{

    public static Dictionary<int, string> JewelryMenu = new()
    {
        {1, "Watches"},
        {2, "Earrings"},
        {3, "Chains"},
        {4, "Anklets"},
        {5, "Cufflinks"},
        
    };
    public static Dictionary<string, Grade> Watches { get; } = new()
    {
        { "Luxury Watch", Grade.Epic },
        { "Smart Watch", Grade.Rare },
        { "Dress Watch", Grade.Rare },
        { "Fashion Watch", Grade.Common },
        { "Digital", Grade.Common }
    };

    public static Dictionary<string, Grade> Earrings { get; } = new()
    {
        { "Hoop", Grade.Common },
        { "Chandelier", Grade.Rare },
        { "Stud", Grade.Common },
        { "Ear Climbers", Grade.Rare },
        { "Huggies", Grade.Common }
    };

    public static Dictionary<string, Grade> Chains { get; } = new()
    {
        { "Chains", Grade.Common },
        { "Herringbone", Grade.Rare },
        { "Cable", Grade.Common },
        { "Rope", Grade.Common },
        { "Curb", Grade.Common },
        { "Pendant", Grade.Rare }
    };

    public static Dictionary<string, Grade> Anklets { get; } = new()
    {
        { "Beaded Anklet", Grade.Common },
        { "Pearl Anklet", Grade.Rare },
        { "Chain Link Anklet", Grade.Common },
        { "Layered", Grade.Rare },
        { "Payal Anklet", Grade.Rare }
    };

    public static Dictionary<string, Grade> Cufflinks { get; } = new()
    {
        { "Cufflinks", Grade.Common },
        { "Chain Link Cufflinks", Grade.Rare },
        { "Bullet back Cufflinks", Grade.Rare },
        { "Locking Cufflinks", Grade.Rare },
        { "Stud Cufflinks", Grade.Common },
        { "Fabric", Grade.Common }
    };
}