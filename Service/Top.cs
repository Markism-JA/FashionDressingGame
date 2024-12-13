using FashionDressingGame.Database;

namespace FashionDressingGame.Service;

public class Top : ETop, IGrade
{
    public Top(string type, string material)
    {
        Type = type;
        Material = material;
    }

    public override string Type
    {
        get => base.Type;
        set
        {
            ValidateInput(value, nameof(Type));
            base.Type = value;
        }
    }

    public override string Material
    {
        get => base.Material;
        set
        {
            ValidateInput(value, nameof(Material));
            base.Material = value;
        }
    }

    public int CalculateGrade()
    {
        // A reusable lambda for fetching grade values safely
        Func<string?, Dictionary<string, Grade>, int> getGradeValue = (key, gradeDictionary) =>
        {
            if (string.IsNullOrWhiteSpace(key)) return 0; // Treat null or empty as 0.
            return gradeDictionary.TryGetValue(key, out var grade)
                ? (int)grade
                : throw new KeyNotFoundException($"Grade key '{key}' not found in the dictionary.");
        };

        // Calculate the grade based on type and material
        int grade = getGradeValue(Type, Info.Top.TopType) +
                    getGradeValue(Material, Info.Top.Materials);

        return grade;
    }

    private static void ValidateInput(string? input, string propertyName)
    {
        if (input == null) return;
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException($"{propertyName} cannot be empty or whitespace.");
        }
    }
}