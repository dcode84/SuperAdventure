using Engine;
using System;

namespace SuperAdventure.Messages
{
    public class QuestMessager
    {
        private readonly SuperAdventure _superAdventure;
        public QuestMessager(SuperAdventure superAdventure)
        {           
            _superAdventure = superAdventure;
        }

        public void ReceiveQuestMessage(ILocation location)
        {
            _superAdventure.rtbMessages.AppendText("You receive the " + location.QuestAvailableHere.Name + " quest");
            _superAdventure.rtbMessages.AppendText(Environment.NewLine);
            _superAdventure.rtbMessages.AppendText(location.QuestAvailableHere.Description);
            _superAdventure.rtbMessages.AppendText(Environment.NewLine);
            _superAdventure.ScrollToBottomOfMessages();
        }

        public void CompleteQuestMessage(ILocation location)
        {
            _superAdventure.rtbMessages.AppendText("You have completed the " + location.QuestAvailableHere.Name + " Quest.");
            _superAdventure.rtbMessages.AppendText(Environment.NewLine);
            _superAdventure.ScrollToBottomOfMessages();
        }

        public void CompleteQuest(ILocation location)
        {
            _superAdventure.player.MarkQuestCompleted(location.QuestAvailableHere);
            _superAdventure.player.RemoveQuestCompletionItems(location.QuestAvailableHere);
        }

        public void RewardQuestMessage(ILocation location)
        {
            _superAdventure.rtbMessages.AppendText("You receive: ");
            _superAdventure.rtbMessages.AppendText(Environment.NewLine);
            _superAdventure.rtbMessages.AppendText(location.QuestAvailableHere.RewardExperiencePoints.ToString() + " experience points");
            _superAdventure.rtbMessages.AppendText(Environment.NewLine);
            _superAdventure.rtbMessages.AppendText(location.QuestAvailableHere.RewardGold.ToString() + " gold");
            _superAdventure.rtbMessages.AppendText(Environment.NewLine);

            if (location.QuestAvailableHere.RewardItem != null)
            {
                _superAdventure.rtbMessages.AppendText("and a " + location.QuestAvailableHere.RewardItem.Name);
                _superAdventure.rtbMessages.AppendText(Environment.NewLine);
            }

            _superAdventure.ScrollToBottomOfMessages();
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
