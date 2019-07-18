using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Location : ILocation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Item ItemRequiredToEnter { get; set; }
        public Quest QuestAvailableHere { get; set; }
        public Monster MonsterLivingHere { get; set; }
        public ILocation LocationToNorth { get; set; }
        public ILocation LocationToEast { get; set; }
        public ILocation LocationToSouth { get; set; }
        public ILocation LocationToWest { get; set; }

        public Location(int id, string name, string description, Item itemRequiredToEnter = null, Quest questAvailableHere = null, Monster monsterLivesHere = null)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemRequiredToEnter = itemRequiredToEnter;
            QuestAvailableHere = questAvailableHere;
            MonsterLivingHere = monsterLivesHere;
        }
    }
}
