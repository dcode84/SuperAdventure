using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : IWeapon, IItem
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }

        public Weapon(int id, string name, string namePlural, int minimumDamage, int maximumDamage)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }
    }
}
