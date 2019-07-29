using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ArmorHelm : IItem
    {
        public int Defense { get; set; }
        public string ArmorType { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }

        public ArmorHelm(int id, string name, string namePlural, int defenseValue, string armorType)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            Defense = defenseValue;
            ArmorType = armorType;

        }

    }
}
