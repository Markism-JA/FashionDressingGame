using FashionDressingGame.Entity;
using FashionDressingGame.Service.Info;

namespace FashionDressingGame.Service;

public class Jewelry : EJewelry, IGrade
{
    private string? watches;
    private string? earrings;
    private string? chains;
    private string? anklets;
    private string? cufflink;

    public override string? Watches { get => watches; set => watches = value; }
    public override string? Earrings { get => earrings; set => earrings = value; }
    public override string? Chains { get => chains; set => chains = value; }
    public override string? Anklets { get => anklets; set => anklets = value; }
    public override string? Cufflinks { get => cufflink; set => cufflink = value; }

    public Jewelry(string? watches, string? earrings, string? chains, string? anklets, string? cufflink)
    {
        this.watches = watches;
        this.earrings = earrings;
        this.chains = chains;
        this.anklets = anklets;
        this.cufflink = cufflink;
    }

    public int CalculateGrade()
    {
        Func<string, Dictionary<string, Grade>, int> getGradeValue = (key, gradeDictionary) =>
        {
            if (key == null) return 0;
            return gradeDictionary.TryGetValue(key, out var grade)
                ? (int)grade
                : throw new KeyNotFoundException($"Grade key '{key}' not found in the dictionary.");
        };
        int grade = getGradeValue(watches, JewelryInfo.Watches) +
                    getGradeValue(earrings, JewelryInfo.Earrings) +
                    getGradeValue(chains, JewelryInfo.Chains) +
                    getGradeValue(anklets, JewelryInfo.Anklets)+
                    getGradeValue(cufflink, JewelryInfo.Cufflinks);
        return grade;
    }
}