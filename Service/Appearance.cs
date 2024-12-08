using FashionDressingGame.Entity;
using FashionDressingGame.Service.Info;

namespace FashionDressingGame.Service;

public class Appearance : EAppearance, IGrade
{
    private string skintone;
    private string eyecolor;
    private string haircolor;
    private string hairstyle;
    private string faceshape;
    private bool freckles;
    private bool dimples;
    private bool acne;
    
    public int CalculateGrade()
    {
        Func<string, Dictionary<string, Grade>, int> getGradeValue = (key, gradeDictionary) =>
        {
            return gradeDictionary.TryGetValue(key, out var grade)
                ? (int)grade
                : throw new KeyNotFoundException($"Grade key '{key}' not found in the dictionary.");
        };
        int grade = getGradeValue(skintone, AppearanceInfo.SkinTone) +
                 getGradeValue(eyecolor, AppearanceInfo.EyeColor) +
                 getGradeValue(haircolor, AppearanceInfo.HairColor) +
                 getGradeValue(hairstyle, AppearanceInfo.HairColor) +
                 getGradeValue(faceshape, AppearanceInfo.FaceShape);
        
        return grade;
    }

    public Appearance(string skintone, string eyecolor, string haircolor, string hairstyle, string faceshape)
    {
        SkinTone = skintone;
        EyeColor = eyecolor;
        HairColor = haircolor;
        HairStyle = hairstyle;
        FaceShape = faceshape;
    }

    public override string SkinTone { get => skintone; set => skintone = value; }
    public override string EyeColor { get => eyecolor; set => eyecolor = value; }
    public override string HairColor { get => haircolor; set => haircolor = value; }
    public override string HairStyle { get => hairstyle; set => hairstyle = value; }
    public override string FaceShape { get => faceshape; set => faceshape = value; }
    public override bool Freckles { get => freckles; set => freckles = value; }
    public override bool Dimples { get => dimples; set => dimples = value; }
    public override bool Acne { get => acne; set => acne = value; }
}
