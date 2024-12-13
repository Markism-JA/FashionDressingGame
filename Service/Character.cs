using FashionDressingGame.Database;
namespace FashionDressingGame.Service;

public class Character : ECharacter
{
    private Appearance appearance;
    private Clothing clothing;

    public Character(string name, string gender, string height, string age, Appearance appearance, Clothing clothing)
    {
        Name = name;
        Gender = gender;
        Height = height;
        Age = age;
        this.appearance = appearance;
        this.clothing = clothing;
        Appearance = appearance;
        Clothing = clothing;
        if (clothing != null && appearance != null) CalculateGrade();
        else throw new NullReferenceException("Clothing and Appearance are null");
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
            base.Name = value;
        }
        get => base.Name;
    }

    public override string Gender
    {
        get => base.Gender;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new NullReferenceException("Gender cannot be null or empty.");
            base.Gender = value;
        }
    }

    public override string Height
    {
        get => base.Height;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new NullReferenceException("Height cannot be null or empty.");
            base.Height = value;
        }
    }

    public override string Age
    {
        get => base.Age;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new NullReferenceException("Age cannot be null or empty.");
            base.Age = value;
        }
    }
    public override EAppearance Appearance
    { 
        get => appearance;
        set
        {
            if (value == null)
                throw new ArgumentException("Appearance cannot be null.");
            base.Appearance = value;
        }  
    }

    public override EClothing Clothing
    {
        get => base.Clothing;
        set
        {
            if (value == null)
                throw new ArgumentException("Clothing cannot be null.");
            base.Clothing = value;
        }
    }
    public void CalculateGrade()
    {
        CharacterGrade = appearance.CalculateGrade() + clothing.CalculateGrade();
    }
}