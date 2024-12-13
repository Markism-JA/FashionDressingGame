using FashionDressingGame.Database;

namespace FashionDressingGame.Service;

public class Jewelry : EJewelry, IGrade
{
    public Jewelry(string? watches, string? earrings, string? chains, string? anklets, string? cufflink)
    {
        Watches = watches;
        Earrings = earrings;
        Chains = chains;
        Anklets = anklets;
        Cufflinks = cufflink;
    }
    public int CalculateGrade()
    {
        Func<string, Dictionary<string, Grade>, int> getGradeValue = (key, gradeDictionary) =>
        {
            if (string.IsNullOrWhiteSpace(key)) return 0;  // Return 0 if the jewelry is null or empty
            return gradeDictionary.TryGetValue(key, out var grade)
                ? (int)grade
                : 0;  // Return 0 if the grade key is not found
        };

        int grade = getGradeValue(Watches, Info.Jewelry.Watches) +
                    getGradeValue(Earrings, Info.Jewelry.Earrings) +
                    getGradeValue(Chains, Info.Jewelry.Chains) +
                    getGradeValue(Anklets, Info.Jewelry.Anklets) +
                    getGradeValue(Cufflinks, Info.Jewelry.Cufflinks);

        return grade;
    }

}