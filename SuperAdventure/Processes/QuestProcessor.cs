using Engine;

namespace SuperAdventure.Processes
{
    public class QuestProcessor
    {
        private readonly SuperAdventure _superAdventure;

        public QuestProcessor(SuperAdventure superAdventure)
        {
            _superAdventure = superAdventure;
        }

        public void CompleteQuest(ILocation location)
        {
            _superAdventure.player.MarkQuestCompleted(location.QuestAvailableHere);
            _superAdventure.player.RemoveQuestCompletionItems(location.QuestAvailableHere);
        }

        public void RewardQuest(ILocation location)
        {
            _superAdventure.player.ExperiencePoints += location.QuestAvailableHere.RewardExperiencePoints;
            _superAdventure.player.Gold += location.QuestAvailableHere.RewardGold;

            if (location.QuestAvailableHere.RewardItem != null)
            {
                _superAdventure.player.AddItemToInventory(location.QuestAvailableHere.RewardItem);
            }
        }

        public void ReceiveQuest(ILocation location)
        {
            _superAdventure.player.Quests.Add(new PlayerQuest(location.QuestAvailableHere));
        }

        public void AlreadyReveicedQuestMessage()
        {
            _superAdventure.rtbMessages.AppendText("Already received Quest and completed it.");
            _superAdventure.ScrollToBottomOfMessages();
        }
    }
}
