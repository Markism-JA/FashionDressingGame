using FashionDressingGame.Entity;

namespace FashionDressingGame.Service;

public class OuterWear : EOuterWear, IGrade
{
    private string outerWearType;
    private string outerWearName;

    public override string OuterWearName { get => OuterWearName; set => OuterWearName = value; }
    public override string OuterWearType { get => OuterWearType; set => OuterWearType = value; }

    public int CalculateGrade()
    {
        Func<string, Dictionary<string, Grade>, int> getGradeValue = (key, gradeDictionary) =>
        {
            return gradeDictionary.TryGetValue(key, out var grade)
                ? (int)grade
                : throw new KeyNotFoundException($"Grade key '{key}' not found in the dictionary.");
        };
        int grade = getGradeValue(outerWearType, Info.OuterWear.OuterWearType) +
                    getGradeValue(outerWearName, Info.OuterWear.OuterWearName);
        return grade;
    }

    public OuterWear( string outerWearName, string outerWearType)
    {
        this.outerWearType = outerWearType;
        this.outerWearName = outerWearName;
    }
}