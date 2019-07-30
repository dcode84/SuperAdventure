using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LootItem
    {
        public IItem Item { get; set; }
        public int DropPercentage { get; set; }
        public bool IsDefaultItem { get; set; }

        public LootItem(IItem item, int dropPercentage, bool isDefaultItem = false)
        {
            Item = item;
            DropPercentage = dropPercentage;
            IsDefaultItem = isDefaultItem;
        }
    }
}
