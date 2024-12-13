namespace FashionDressingGame.Database;

public class EAppearance
{
    public int Id { get; set; }

    public virtual string SkinTone { get; set; } 
    public virtual string EyeColor { get; set; } 
    public virtual string HairStyle { get; set; }
    public virtual string HairColor { get; set; }
    public virtual string FaceShape { get; set; }
    public virtual bool Freckles { get; set; }   
    public virtual bool Dimples { get; set; }    
    public virtual bool Acne { get; set; }       
}