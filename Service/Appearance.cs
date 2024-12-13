using FashionDressingGame.Database;

namespace FashionDressingGame.Service;

public class Appearance : EAppearance, IGrade
{
    public Appearance(
        string skintone, 
        string eyecolor, 
        string haircolor, 
        string hairstyle, 
        string faceshape,
        bool freckles = false, 
        bool dimples = false, 
        bool acne = false)
    {
        SkinTone = skintone;
        EyeColor = eyecolor;
        HairColor = haircolor;
        HairStyle = hairstyle;
        FaceShape = faceshape;
        Freckles = freckles;
        Dimples = dimples;
        Acne = acne;
    }

    public int CalculateGrade()
    {
        Func<string, Dictionary<string, Grade>, int> getGradeValue = (key, gradeDictionary) =>
        {
            return gradeDictionary.TryGetValue(key, out var grade)
                ? (int)grade
                : throw new KeyNotFoundException($"Grade key '{key}' not found in the dictionary.");
        };

        return getGradeValue(SkinTone, Info.Appearance.SkinTone) +
               getGradeValue(EyeColor, Info.Appearance.EyeColor) +
               getGradeValue(HairColor, Info.Appearance.HairColor) +
               getGradeValue(HairStyle, Info.Appearance.HairStyles) +
               getGradeValue(FaceShape, Info.Appearance.FaceShape);
    }

    public override string SkinTone
    {
        get => base.SkinTone;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Skin tone cannot be null or empty.");
            base.SkinTone = value;
        }
    }

    public override string EyeColor
    {
        get => base.EyeColor;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Eye color cannot be null or empty.");
            base.EyeColor = value;
        }
    }

    public override string HairColor
    {
        get => base.HairColor;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Hair color cannot be null or empty.");
            base.HairColor = value;
        }
    }

    public override string HairStyle
    {
        get => base.HairStyle;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Hair style cannot be null or empty.");
            base.HairStyle = value;
        }
    }

    public override string FaceShape
    {
        get => base.FaceShape;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Face shape cannot be null or empty.");
            base.FaceShape = value;
        }
    }
}
