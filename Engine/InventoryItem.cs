
namespace Engine
{
    public class InventoryItem
    {
        public Item ItemInfo { get; set; }
        public int Quantity { get; set; }

        public InventoryItem (Item iteminfo, int quantity)
        {
            ItemInfo = iteminfo;
            Quantity = quantity;
        }
    }
}
