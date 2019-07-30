using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class QuestCompletionItem : IQuestCompletionItem
    {
        public IItem Item { get; set; }
        public int Quantity { get; set; }

        public QuestCompletionItem(IItem iteminfo, int quantity)
        {
            Item = iteminfo;
            Quantity = quantity;
        }
    }
}
