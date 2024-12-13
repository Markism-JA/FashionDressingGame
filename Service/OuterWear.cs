using FashionDressingGame.Database;

namespace FashionDressingGame.Service;

public class OuterWear : EOuterWear, IGrade
{
    public int CalculateGrade()
    {
        Func<string, Dictionary<string, Grade>, int> getGradeValue = (key, gradeDictionary) =>
        {
            return gradeDictionary.TryGetValue(key, out var grade)
                ? (int)grade
                : throw new KeyNotFoundException($"Grade key '{key}' not found in the dictionary.");
        };
        int grade = getGradeValue(OuterWearType, Info.OuterWear.OuterWearType) +
                    getGradeValue(OuterWearName, Info.OuterWear.OuterWearName);
        return grade;
    }

    public OuterWear( string outerWearName, string outerWearType)
    {
        OuterWearType = outerWearType;
        OuterWearName = outerWearName;
    }

    public override string OuterWearName
    {
        get => base.OuterWearName;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new NullReferenceException("OuterWearName cannot be null or empty.");
            base.OuterWearName = value;
        }
    }

    public override string OuterWearType
    {
        get => base.OuterWearType;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new NullReferenceException("OuterWearType cannot be null or empty.");
            base.OuterWearType = value;
        }
    }
}