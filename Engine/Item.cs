using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Item
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String NamePlural { get; set; }

        public Item(int id, String name, String namePlural)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
        }
    }
}
