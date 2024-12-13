namespace FashionDressingGame.Database;

public class EJewelry
{
    public int Id { get; set; }
    public virtual string? Watches { get; set; }
    public virtual string? Earrings { get; set; }
    public virtual string? Chains { get; set; }
    public virtual string? Anklets { get; set; }
    public virtual string? Cufflinks { get; set; }
    
}