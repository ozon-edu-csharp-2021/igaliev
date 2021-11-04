using System.Collections.Generic;
using MerchandiseService.Domain.SeedWork;

namespace MerchandiseService.Domain.MerchOrderAggregation
{
    public class MerchKit:Enumeration
    {
        public bool IsNeedSize;

        public List<Item> Items;

        public static MerchKit WelcomePack = new MerchKit(1, nameof(WelcomePack), new List<Item>
        {
            Item.Pen,
            Item.Notepad
        }, false);

        public static MerchKit StarterPack = new MerchKit(2, nameof(StarterPack), new List<Item>
        {
            Item.Pen,
            Item.TShirt,
            Item.Notepad,
            
        }, true);

        public static MerchKit ConferenceListenerPack = new MerchKit(3, nameof(ConferenceListenerPack),
            new List<Item>
            {
                Item.Pen,
                Item.TShirt,
                Item.Notepad,
            }, true);

        public static MerchKit ConferenceSpeakerPack = new MerchKit(4, nameof(ConferenceSpeakerPack),
            new List<Item>
            {
                Item.Pen,
                Item.TShirt,
                Item.Notepad,
                Item.Sweatshirt
            }, true);

        public static MerchKit VeteranPack = new MerchKit(50, nameof(VeteranPack), new List<Item>
        {
            Item.Pen,
            Item.Notepad,
            Item.Socks,
            Item.Sweatshirt,
            Item.TShirt,
            Item.Bag
        }, true);

        public MerchKit(int id, string name, List<Item> merchItems, bool isNeedSize) : base(id, name)
        {
            IsNeedSize = isNeedSize;
            Items = merchItems;
        }
    }
}