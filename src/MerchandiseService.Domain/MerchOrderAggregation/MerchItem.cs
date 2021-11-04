using MerchandiseService.Domain.SeedWork;

namespace MerchandiseService.Domain.MerchOrderAggregation
{
    public class Item:Enumeration
    {
        public static Item TShirt = new(1, nameof(TShirt));
        public static Item Sweatshirt = new(2, nameof(Sweatshirt));
        public static Item Notepad = new(3, nameof(Notepad));
        public static Item Bag = new(4, nameof(Bag));
        public static Item Pen = new(5, nameof(Pen));
        public static Item Socks = new(6, nameof(Socks));

        public Item(int id, string name) : base(id, name)
        {
        }
    }
}