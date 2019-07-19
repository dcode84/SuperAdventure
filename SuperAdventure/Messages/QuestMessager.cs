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
            _superAdventure.rtbMessages.AppendText("You have completed the " + location.QuestAvailableHere.Name + " quest.");
            _superAdventure.rtbMessages.AppendText(Environment.NewLine);
            _superAdventure.ScrollToBottomOfMessages();
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
    }
}
