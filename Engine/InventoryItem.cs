
namespace Engine
{
    public class InventoryItem
    {
        public IItem Item { get; set; }
        public int Quantity { get; set; }

        public InventoryItem (IItem item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}
