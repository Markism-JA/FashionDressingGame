namespace FashionDressingGame.Database;

public class EBottom
{
    public int Id { get; set; } // Primary Key

    public virtual string Type { get; set; }
    public virtual string Material { get; set; }
}