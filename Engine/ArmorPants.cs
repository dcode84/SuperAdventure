using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ArmorPants : Item
    {
        public int Defense { get; set; }
        public byte ArmorType { get; set; }

        public ArmorPants(int id, string name, string namePlural, int defenseValue, byte armorType) : base(id, name, namePlural)
        {
            Defense = defenseValue;
            ArmorType = armorType;
        }
    }
}
