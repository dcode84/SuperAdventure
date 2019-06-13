using Engine;
using System;

namespace SuperAdventure.Processes
{
    public class QuestProcessor
    {
        SuperAdventure _superAdventure;

        public QuestProcessor(SuperAdventure superAdventure)
        {           
            _superAdventure = superAdventure;
        }

        public void ReceiveQuestMessage(Location location)
        {
            _superAdventure.rtbMessages.AppendText("You receive the " + location.QuestAvailableHere.Name + " quest");
            _superAdventure.rtbMessages.AppendText(Environment.NewLine);
            _superAdventure.rtbMessages.AppendText(location.QuestAvailableHere.Description);
            _superAdventure.rtbMessages.AppendText(Environment.NewLine);
            _superAdventure.ScrollToBottomOfMessages();
        }

        public void CompleteQuestMessage(Location location)
        {
            _superAdventure.rtbMessages.AppendText("You have completed the " + location.QuestAvailableHere.Name + " Quest.");
            _superAdventure.rtbMessages.AppendText(Environment.NewLine);
            CompleteQuest(location);
            _superAdventure.ScrollToBottomOfMessages();
        }

        public void CompleteQuest(Location location)
        {
            _superAdventure.player.MarkQuestCompleted(location.QuestAvailableHere);
            _superAdventure.player.RemoveQuestCompletionItems(location.QuestAvailableHere);
        }

        public void RewardQuestMessage(Location location)
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

        public void RewardQuest(Location location)
        {
            _superAdventure.player.ExperiencePoints += location.QuestAvailableHere.RewardExperiencePoints;
            _superAdventure.player.Gold += location.QuestAvailableHere.RewardGold;

            if (location.QuestAvailableHere.RewardItem != null)
            {
                _superAdventure.player.AddItemToInventory(location.QuestAvailableHere.RewardItem);
            }
        }

        public void ReceiveQuest(Location location)
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
