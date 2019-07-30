using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class HealingPotion : IHealingPotion, IItem
    {
        public int AmountToHeal { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }

        public HealingPotion(int id, string name, string namePlural, int amountToHeal)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            AmountToHeal = amountToHeal;
        }
    }
}
