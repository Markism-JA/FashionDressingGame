using FashionDressingGame.Entity;
namespace FashionDressingGame.Service;

public class Character : ECharacter
{
    //Uncalculated
    private string name;
    private string gender;
    private string height;
    private string age;
    
    //Calculated
    private Appearance appearance;
    private Clothing clothing;

    public Character(string name, string gender, string height, string age)
    {
        Name = name;
        Gender = gender;
        Height = height;
        Age = age;
        
        if (clothing != null && appearance != null) CalculateGrade();
    }

    public override string Name
    {
        set
        {
            Func<string, bool> containsSpecialChars = input => input.IndexOfAny("!@#$%^&*()_+=[]{}|;:'\",.<>?/`~".ToCharArray()) >= 0;
            if (containsSpecialChars(value) || value.Length > 30)
            {
                throw new ArgumentException(containsSpecialChars(value) 
                    ? "Character name cannot contain special characters." 
                    : "Character's name must be less than 30 characters.");
            }
            name = value;
        }
        get => name;
    }
    public override string Gender { set => gender = value; get => gender; }
    public override string Height { set => height = value; get => height; }
    public override string Age { set => age = value; get => age; }
    public override Appearance Appearance { set => appearance = value; get => appearance; }
    public override Clothing Clothing { get => clothing; set => clothing = value; }

    public void CalculateGrade()
    {
        CharacterGrade = appearance.CalculateGrade() + clothing.CalculateGrade();
    }
}