using FashionDressingGame.Service;

namespace FashionDressingGame.Entity
{
    public class EClothing
    {
        public int Id { get; set; }

        public int? TopId { get; set; }
        public virtual Top Top { get; set; }

        public int? BottomId { get; set; }
        public virtual Bottom Bottom { get; set; }

        public virtual string Shoe { get; set; }
        public virtual string Accessory { get; set; }
        public virtual string Gloves { get; set; }

        public int? JewelryId { get; set; }
        public virtual Jewelry Jewelry { get; set; }

        public virtual string OutfitTheme { get; set; }
        public virtual string FormalWear { get; set; }

        public int? OuterWearId { get; set; }
        public virtual OuterWear OuterWear { get; set; }

        public virtual string Hat { get; set; }
    }
}