namespace FashionDressingGame.Service.Info;

public struct CharacterInfo
{
    public static Dictionary<int, string> CharacterMenu { get; } = new()
    {
        {1, "Gender"},
        {2, "Height"},
        {3, "Age"},
        {4, "Next"}
    };
    
    public static Dictionary<int, string> Gender { get; } = new()
    {
        { 1, "Male" },
        { 2, "Female" }
    };

    public static Dictionary<int, string> Height { get; } = new()
    {
        { 1, "Short" },
        { 2, "Average" },
        { 3, "Tall" },
        { 4, "VeryTall" },
        { 5, "Giant" }
    };

    public static Dictionary<int, string> Age { get; } = new()
    {
        { 1, "Child" },
        { 2, "Teen" },
        { 3, "Young Adult" },
        { 4, "Adult" },
        { 5, "Senior" }
    };
}