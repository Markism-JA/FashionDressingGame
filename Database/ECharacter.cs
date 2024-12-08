using FashionDressingGame.Service;

namespace FashionDressingGame.Entity;

public class ECharacter
{
    public int Id { get; set; }
    public int? AppearanceID { get; set; }
    public virtual Appearance Appearance { get; set; }
    public int? ClothingID { get; set; }
    public virtual Clothing Clothing { get; set; }
    
    public virtual string Name { get; set; }
    public virtual string Gender { get; set; }
    public virtual string Height { get; set; }
    public virtual string Age { get; set; }
    public virtual int CharacterGrade { get; set; }
}