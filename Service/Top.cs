using FashionDressingGame.Entity;
using FashionDressingGame.Service.Info;

namespace FashionDressingGame;

public class Top : ETop, IGrade
{
    private string type;
    private string material;

    public override string Type { get => type; set => type = value; }
    public override string Material { get => material; set => material = value; }

    public int CalculateGrade()
    {
        Func<string, Dictionary<string, Grade>, int> getGradeValue = (key, gradeDictionary) =>
        {
            return gradeDictionary.TryGetValue(key, out var grade)
                ? (int)grade
                : throw new KeyNotFoundException($"Grade key '{key}' not found in the dictionary.");
        };
        int grade = getGradeValue(type, ClothingInfo.TopType) + 
                    getGradeValue(material, ClothingInfo.Materials);
        return grade;
    }

    public Top(string type, string material)
    {
        this.type = type;
        this.material = material;
    }
}