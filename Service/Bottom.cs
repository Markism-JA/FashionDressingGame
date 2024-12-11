using FashionDressingGame.Entity;
using FashionDressingGame.Service.Info;

namespace FashionDressingGame.Service;
public class Bottom : EBottom, IGrade
{
    private string type;
    private string material;

    public override string Material { get => material; set => material = value; }
    public override string Type { get => type; set => type = value; }

    public int CalculateGrade()
    {
        Func<string, Dictionary<string, Grade>, int> getGradeValue = (key, gradeDictionary) =>
        {
            return gradeDictionary.TryGetValue(key, out var grade)
                ? (int)grade
                : throw new KeyNotFoundException($"Grade key '{key}' not found in the dictionary.");
        };
        int grade = getGradeValue(type, Info.Bottom.BottomType) + getGradeValue(material, Info.Bottom.Materials);
        return grade;
    }

    public Bottom(string type, string material)
    {
        this.type = type;
        this.material = material;
    }
    
    
}