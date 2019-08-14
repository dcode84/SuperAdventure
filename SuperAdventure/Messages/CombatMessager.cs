using Engine.Utilities;
using Engine;
using System;
using System.Drawing;
using Extensions;

namespace SuperAdventure.Messages
{
    public class CombatMessager : MessageUtilities
    {
        private readonly SuperAdventure _superAdventure;

        public CombatMessager(SuperAdventure superAdventure)
        {
            _superAdventure = superAdventure;
            OnMessageRaised += _superAdventure.DisplayMessage;
        }

        public void DisplayVictoryText()
        {
            RaiseInfo("You've defeated the " + _superAdventure._combatProcessor._currentMonster.Name + ".", true);
            RaiseMessage("Gained: ");
            RaiseMessage(_superAdventure._combatProcessor._currentMonster.RewardExperiencePoints + " experiene");
            RaiseMessage(_superAdventure._combatProcessor._currentMonster.RewardGold + " gold");
        }

        public void MonsterSpottedMessage(ILocation newLocation)
        {
            RaiseMessage("");
            RaiseInfo("You see a " + newLocation.MonsterLivingHere.Name, true);
        }

        public void LootMessage(InventoryItem inventoryItem)
        {
            if (inventoryItem.Quantity == 1)
            {
                RaiseMessage("You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Item.Name);
            }
            else
            {
                RaiseMessage("You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Item.NamePlural);
            }
        }

        public void DisplayDamageOnMonster(int damageToMonster)
        {
            if (damageToMonster <= 0)
            {
                RaiseInfo("You have missed.");
            }
            else
            {
                string playerDPS = "You've hit the "
                                 + _superAdventure._combatProcessor._currentMonster.Name 
                                 + " for " + damageToMonster.ToString() + " damage.";
                RaiseInfo(playerDPS);
            }
        }

        public void MonsterDPSToPlayerMessage(int damageToPlayer)
        {
            string mobDPS = String.Format("The {0} has hit you for {1} damage.",
                _superAdventure._combatProcessor._currentMonster.Name, damageToPlayer.ToString());

            if (damageToPlayer >= 1)
            {
                RaiseWarning(mobDPS, true);
            }
            else
            {
                RaiseWarning("The " + _superAdventure._combatProcessor._currentMonster.Name + " has missed.", true);
            }

            if (_superAdventure.player.CurrentHitPoints <= 0)
            {
                RaiseWarning(Environment.NewLine + "You have died.", true);
            }
        }
    }
}
