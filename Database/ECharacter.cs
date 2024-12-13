namespace FashionDressingGame.Database;

public class ECharacter
{
    public int Id { get; set; }
    public int? AppearanceID { get; set; }
    public virtual EAppearance Appearance { get; set; }
    public int? ClothingID { get; set; }
    public virtual EClothing Clothing { get; set; }
    
    public virtual string Name { get; set; }
    public virtual string Gender { get; set; }
    public virtual string Height { get; set; }
    public virtual string Age { get; set; }
    public virtual int CharacterGrade { get; set; }
}