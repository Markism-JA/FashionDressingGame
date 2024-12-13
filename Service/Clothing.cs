using FashionDressingGame.Database;

namespace FashionDressingGame.Service;

public class Clothing : EClothing, IGrade
{
    private Top _top;
    private OuterWear _outerWear;
    private Bottom _bottom;
    private Jewelry _jewelry;


    public int CalculateGrade()
    {
        Func<string, Dictionary<string, Grade>, int> getGradeValue = (key, gradeDictionary) =>
        {
            return gradeDictionary.TryGetValue(key, out var grade)
                ? (int)grade
                : throw new KeyNotFoundException($"Grade key '{key}' not found in the dictionary.");
        };
        int grade = getGradeValue(Shoe, Info.Clothing.ShoeType) +
                    getGradeValue(Accessory, Info.Clothing.Accessories) +
                    getGradeValue(Gloves, Info.Clothing.Gloves) +
                    getGradeValue(OutfitTheme, Info.Clothing.OutfitThemes) +
                    getGradeValue(FormalWear, Info.Clothing.FormalWear) +
                    getGradeValue(Hat, Info.Clothing.Hats);
        grade += _top.CalculateGrade() + _bottom.CalculateGrade() + _jewelry.CalculateGrade() + _outerWear.CalculateGrade();
        return grade;
    }

    public Clothing(Top top, Bottom bottom, string shoe, string accessory, string gloves, Jewelry jewelry, string outfitTheme, string formalWear, OuterWear outerWear, string hat)
    {
        _top = top;
        _bottom = bottom;
        _outerWear = outerWear;
        _jewelry = jewelry;
        Shoe = shoe;
        Accessory= accessory;
        Gloves = gloves;
        OutfitTheme = outfitTheme;
        FormalWear = formalWear;
        OuterWear = outerWear;
        Hat = hat;

        Top = _top;
        Bottom = _bottom;
        OuterWear = _outerWear;
        Jewelry = _jewelry;

    }
    
    public override string Shoe
    {
        get => base.Shoe;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new NullReferenceException("Shoe cannot be null or empty.");
            base.Shoe = value;
        }
    }

    public override string Accessory
    {
        get => base.Accessory;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new NullReferenceException("Accessory cannot be null or empty.");
            base.Accessory = value;
        }
    }

    public override string Gloves
    {
        get => base.Gloves;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new NullReferenceException("Gloves cannot be null or empty.");
            base.Gloves = value;
        }
    }

    public override string OutfitTheme
    {
        get => base.OutfitTheme;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new NullReferenceException("Outfit theme cannot be null or empty.");
            base.OutfitTheme = value;
        }
    }

    public override string FormalWear
    {
        get => base.FormalWear;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new NullReferenceException("Formal wear cannot be null or empty.");
            base.FormalWear = value;
        }
    }

    public override string Hat
    {
        get => base.Hat;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new NullReferenceException("Hat cannot be null or empty.");
            base.Hat = value;
        }
    }
}