using FashionDressingGame.Entity;
using FashionDressingGame.Service.Info;

namespace FashionDressingGame.Service;

public class Clothing : EClothing, IGrade
{
    private Top top;
    private Bottom bottom;
    private string shoe;
    private string accessory;
    private string gloves;
    private Jewelry jewelry;
    private string outfitTheme;
    private string formalWear;
    private OuterWear outerWear;
    private string hat;

    public override Top Top { get => top; set => top = value; }
    public override Bottom Bottom { get => bottom; set => bottom = value; }
    public override string Shoe { get => shoe; set => shoe = value; }
    public override string Accessory { get => accessory; set => accessory = value; }
    public override string Gloves { get => gloves; set => gloves = value; }
    public override Jewelry Jewelry { get => jewelry; set => jewelry = value; }
    public override string OutfitTheme { get => outfitTheme; set => outfitTheme = value; }
    public override string FormalWear { get => formalWear; set => formalWear = value; }
    public override OuterWear OuterWear { get => outerWear; set => outerWear = value; }
    public override string Hat { get => hat; set => hat = value; }


    public int CalculateGrade()
    {
        Func<string, Dictionary<string, Grade>, int> getGradeValue = (key, gradeDictionary) =>
        {
            return gradeDictionary.TryGetValue(key, out var grade)
                ? (int)grade
                : throw new KeyNotFoundException($"Grade key '{key}' not found in the dictionary.");
        };
        int grade = getGradeValue(shoe, Info.Clothing.ShoeType) +
                    getGradeValue(accessory, Info.Clothing.Accessories) +
                    getGradeValue(gloves, Info.Clothing.Gloves) +
                    getGradeValue(outfitTheme, Info.Clothing.OutfitThemes) +
                    getGradeValue(formalWear, Info.Clothing.FormalWear) +
                    getGradeValue(hat, Info.Clothing.Hats);
        grade += top.CalculateGrade() + bottom.CalculateGrade() + jewelry.CalculateGrade() + outerWear.CalculateGrade();
        return grade;
    }

    public Clothing(Top top, Bottom bottom, string shoe, string accessory, string gloves, Jewelry jewelry, string outfitTheme, string formalWear, OuterWear outerWear, string hat)
    {
        this.top = top;
        this.bottom = bottom;
        this.shoe = shoe;
        this.accessory = accessory;
        this.gloves = gloves;
        this.jewelry = jewelry;
        this.outfitTheme = outfitTheme;
        this.formalWear = formalWear;
        this.outerWear = outerWear;
        this.hat = hat;
    }
}