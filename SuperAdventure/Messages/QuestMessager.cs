using Engine;
using Engine.Utilities;
using System;

namespace SuperAdventure.Messages
{
    public class QuestMessager : MessageUtilities
    {
        private readonly SuperAdventure _superAdventure;
        public QuestMessager(SuperAdventure superAdventure)
        {           
            _superAdventure = superAdventure;
            OnMessageRaised += _superAdventure.DisplayMessage;
        }

        public void ReceiveQuestMessage(ILocation location)
        {
            RaiseInfo("");
            RaiseInfo("You receive the " + location.QuestAvailableHere.Name + " quest");
            RaiseInfo(location.QuestAvailableHere.Description, true);
        }

        public void CompleteQuestMessage(ILocation location)
        {
            RaiseInfo("You have completed the " + location.QuestAvailableHere.Name + " quest.");
        }

        public void RewardQuestMessage(ILocation location)
        {
            RaiseMessage("You receive: ");
            RaiseMessage(location.QuestAvailableHere.RewardExperiencePoints.ToString() + " experience points");
            RaiseMessage(location.QuestAvailableHere.RewardGold.ToString() + " gold");

            if (location.QuestAvailableHere.RewardItem != null)
            {
                RaiseMessage("and a " + location.QuestAvailableHere.RewardItem.Name);
            }

            RaiseMessage("");
        }
    }
}
