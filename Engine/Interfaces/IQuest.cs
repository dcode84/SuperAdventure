using System.Collections.Generic;

namespace Engine
{
    public interface IQuest
    {
        string Description { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        int RewardExperiencePoints { get; set; }
        int RewardGold { get; set; }
        IItem RewardItem { get; set; }
        List<IQuestCompletionItem> QuestCompletionItems { get; set; }
    }
}