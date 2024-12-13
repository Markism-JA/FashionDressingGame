namespace FashionDressingGame.Database
{
    public class EClothing
    {
        public int Id { get; set; }

        public int? TopId { get; set; }
        public virtual ETop Top { get; set; }

        public int? BottomId { get; set; }
        public virtual EBottom Bottom { get; set; }

        public virtual string Shoe { get; set; }
        public virtual string Accessory { get; set; }
        public virtual string Gloves { get; set; }

        public int? JewelryId { get; set; }
        public virtual EJewelry Jewelry { get; set; }

        public virtual string OutfitTheme { get; set; }
        public virtual string FormalWear { get; set; }

        public int? OuterWearId { get; set; }
        public virtual EOuterWear OuterWear { get; set; }

        public virtual string Hat { get; set; }
    }
}