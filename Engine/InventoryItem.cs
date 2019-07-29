
namespace Engine
{
    public class InventoryItem
    {
        public IItem ItemInfo { get; set; }
        public int Quantity { get; set; }

        public InventoryItem (IItem iteminfo, int quantity)
        {
            ItemInfo = iteminfo;
            Quantity = quantity;
        }
    }
}
