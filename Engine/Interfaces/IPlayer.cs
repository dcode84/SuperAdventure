using System.Collections.Generic;

namespace Engine
{
    public interface IPlayer : ILivingCreature
    {
        double ComputeDamageReduction { get; }
        int ComputeExperiencePoints { get; }
        new int CurrentHitPoints { get; set; }
        ILocation CurrentLocation { get; set; }
        int Defense { get; set; }
        int Gold { get; set; }
        new int Intelligence { get; set; }
        List<InventoryItem> Inventory { get; set; }
        int Level { get; set; }
        new int MaximumHitPoints { get; set; }
        List<PlayerQuest> Quests { get; set; }
        new int Strength { get; set; }
        new int Vitality { get; set; }
    }
}