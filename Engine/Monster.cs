using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster : IMonster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        public List<LootItem> LootTable { get; set; }
        public int CurrentHitPoints { get; set; }
        public int MaximumHitPoints { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Vitality { get; set; }

        public Monster(int id, string name, int strength, int intelligence, int vitality, int minimumDamage, int maximumDamage, int rewardExperiencePoints, int rewardGold, int maximumHitPoints, int currentHitPoints)
        {
            ID = id;
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Vitality = vitality;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            CurrentHitPoints = currentHitPoints;
            MaximumHitPoints = maximumHitPoints;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;

            LootTable = new List<LootItem>();
        }
    }
}
