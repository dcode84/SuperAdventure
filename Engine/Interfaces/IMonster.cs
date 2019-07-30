using System.Collections.Generic;

namespace Engine
{
    public interface IMonster : ILivingCreature
    {
        int ID { get; set; }
        List<LootItem> LootTable { get; set; }
        int MinimumDamage { get; set; }
        int MaximumDamage { get; set; }
        string Name { get; set; }
        int RewardExperiencePoints { get; set; }
        int RewardGold { get; set; }
        new int Strength { get; set; }
        new int Intelligence { get; set; }
        new int Vitality { get; set; }
    }
}