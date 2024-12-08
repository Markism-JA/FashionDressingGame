namespace FashionDressingGame.Entity;

public class EOuterWear
{
    public int Id { get; set; } // Primary Key

    public virtual string OuterWearType { get; set; }
    public virtual string OuterWearName { get; set; }
}