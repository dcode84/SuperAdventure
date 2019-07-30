using Engine;
using System;
using System.Drawing;
using Extensions;
using SuperAdventure.Processes;

namespace SuperAdventure.Messages
{
    public class CombatMessager
    {
        private readonly SuperAdventure _superAdventure;

        public CombatMessager(SuperAdventure superAdventure)
        {
            _superAdventure = superAdventure;
        }

        public void DisplayVictoryText()
        {
            _superAdventure.rtbMessages.AppendText(Environment.NewLine);
            _superAdventure.rtbMessages.AppendText("You've defeated the " + _superAdventure._combatProcessor._currentMonster.Name + ".", true);
            _superAdventure.rtbMessages.AppendText("Gained: ", true);
            _superAdventure.rtbMessages.AppendText(_superAdventure._combatProcessor._currentMonster.RewardExperiencePoints + " experience", true);
            _superAdventure.rtbMessages.AppendText(_superAdventure._combatProcessor._currentMonster.RewardGold + " gold", true);
        }

        public void MonsterSpottedMessage(ILocation newLocation)
        {
            _superAdventure.rtbMessages.AppendText(Environment.NewLine);
            _superAdventure.rtbMessages.AppendText("You see a " + newLocation.MonsterLivingHere.Name, true);
        }

        public void LootMessage(InventoryItem inventoryItem)
        {
            if (inventoryItem.Quantity == 1)
            {
                _superAdventure.rtbMessages.AppendText("You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Item.Name, true);
            }
            else
            {
                _superAdventure.rtbMessages.AppendText("You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Item.NamePlural, true);
            }
        }

        public void DisplayDamageOnMonster(int damageToMonster)
        {
            if (damageToMonster <= 0)
            {
                _superAdventure.rtbMessages.AppendText(Environment.NewLine + "You have missed.", true);
            }
            else
            {
                string playerDPS = Environment.NewLine + "You've hit the "
                                                       + _superAdventure._combatProcessor._currentMonster.Name + " for " + damageToMonster.ToString() + " damage.";
                _superAdventure.rtbMessages.AppendText(playerDPS, Color.Blue, true);
            }
        }

        public void MonsterDPSToPlayerMessage(int damageToPlayer)
        {
            string mobDPS = String.Format("The {0} has hit you for {1} damage.",
                _superAdventure._combatProcessor._currentMonster.Name, damageToPlayer.ToString());

            if (damageToPlayer >= 1)
            {
                _superAdventure.rtbMessages.AppendText(mobDPS, Color.Red, true);
            }
            else
            {
                _superAdventure.rtbMessages.AppendText("The " + _superAdventure._combatProcessor._currentMonster.Name + " has missed.", true);
            }

            if (_superAdventure.player.CurrentHitPoints <= 0)
            {
                _superAdventure.rtbMessages.AppendText(Environment.NewLine + "You have died.", true);
            }
        }
    }
}
