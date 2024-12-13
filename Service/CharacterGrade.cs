namespace FashionDressingGame.Service
{
    public enum CharacterGrade
    {
        NeedImprovement,
        CoolTrendsetter,
        StylishCelebrity,
        IconicSuperstar,
        FashionIdolLegend
    }

    public class FashionGrader
    {
        public static CharacterGrade CalculateGrade(int totalPoints)
        {
            if (totalPoints < 50)
                return CharacterGrade.NeedImprovement;
            else if (totalPoints <= 100)
                return CharacterGrade.CoolTrendsetter;
            else if (totalPoints <= 150)
                return CharacterGrade.StylishCelebrity;
            else if (totalPoints <= 200)
                return CharacterGrade.IconicSuperstar;
            else
                return CharacterGrade.FashionIdolLegend;
        }
    }
}
