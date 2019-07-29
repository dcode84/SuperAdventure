using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class QuestCompletionItem
    {
        public IItem ItemInfo { get; set; }
        public int Quantity { get; set; }

        public QuestCompletionItem (IItem iteminfo, int quantity)
        {
            ItemInfo = iteminfo;
            Quantity = quantity;
        }
    }
}
