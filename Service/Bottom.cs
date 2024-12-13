using FashionDressingGame.Database;
namespace FashionDressingGame.Service;

public class Bottom : EBottom, IGrade
{
    public Bottom(string type, string material)
    {
        Type = type;
        Material = material;
    }

    public int CalculateGrade()
    {
        Func<string, Dictionary<string, Grade>, int> getGradeValue = (key, gradeDictionary) =>
        {
            return gradeDictionary.TryGetValue(key, out var grade)
                ? (int)grade
                : throw new KeyNotFoundException($"Grade key '{key}' not found in the dictionary.");
        };

        return getGradeValue(Type, Info.Bottom.BottomType) + 
               getGradeValue(Material, Info.Bottom.Materials);
    }

    public override string Type
    {
        get => base.Type;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Type cannot be null or empty.");
            base.Type = value;
        }
    }

    public override string Material
    {
        get => base.Material;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Material cannot be null or empty.");
            base.Material = value;
        }
    }
}