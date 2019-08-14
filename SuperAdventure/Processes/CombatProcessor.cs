using Engine;
using Extensions;
using System.Collections.Generic;
using SuperAdventure.Messages;

namespace SuperAdventure.Processes
{
    public class CombatProcessor
    {
        private readonly SuperAdventure _superAdventure;
        public IMonster _currentMonster;
        public CombatMessager _combatMessager;

        public CombatProcessor(SuperAdventure superAdventure)
        {
            _superAdventure = superAdventure;
        }

        public void DamageOnMonster(IWeapon currentWeapon)
        {
            int damageToMonster = RandomNumberGenerator.NumberBetween(currentWeapon.MinimumDamage, currentWeapon.MaximumDamage);
            _currentMonster.CurrentHitPoints -= damageToMonster;
            _superAdventure._combatMessager.DisplayDamageOnMonster(damageToMonster);

            if (_currentMonster.CurrentHitPoints <= 0)
            {
                List<InventoryItem> lootedItems = new List<InventoryItem>();

                _superAdventure._combatMessager.DisplayVictoryText();
                SetExperiencePoints();
                SetGold();
                RollLoot(lootedItems);
                AddItemsToInventory(lootedItems);
            }
            else
            {
                MonsterDPS();
            }
        }

        public void MonsterDPS()
        {
            int damageToPlayer = RandomNumberGenerator.NumberBetween(_currentMonster.MinimumDamage, _currentMonster.MaximumDamage);
            _superAdventure.player.CurrentHitPoints -= damageToPlayer;

            _superAdventure._combatMessager.MonsterDPSToPlayerMessage(damageToPlayer);
        }

        public void PlayerDied()
        {
            _superAdventure.MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
        }

        private void AddItemsToInventory(List<InventoryItem> lootedItems)
        {
            foreach (InventoryItem inventoryItem in lootedItems)
            {
                _superAdventure.player.AddItemToInventory(inventoryItem.Item);
                _superAdventure._combatMessager.LootMessage(inventoryItem);
            }
        }

        public void MonsterCheck(ILocation newLocation)
        {
            if (newLocation.MonsterLivingHere != null)
            {
                _superAdventure._combatMessager.MonsterSpottedMessage(newLocation);

                // Make a new monster, using the values from the standard monster in the World.Monster list
                IMonster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                _currentMonster = new Monster(
                    standardMonster.ID, 
                    standardMonster.Name, 
                    standardMonster.Strength,
                    standardMonster.Intelligence,
                    standardMonster.Vitality,
                    standardMonster.MinimumDamage,
                    standardMonster.MaximumDamage,
                    standardMonster.RewardExperiencePoints, 
                    standardMonster.RewardGold, 
                    standardMonster.CurrentHitPoints, 
                    standardMonster.MaximumHitPoints
                );

                foreach (LootItem lootItem in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(lootItem);
                }

                _superAdventure.selectionLabel.Visible = true;
                _superAdventure.cboWeapons.Visible = true;
                _superAdventure.cboPotions.Visible = true;
                _superAdventure.btnUseWeapon.Visible = true;
                _superAdventure.btnUsePotion.Visible = true;
            }
            else
            {
                _currentMonster = null;
                _superAdventure.selectionLabel.Visible = false;
                _superAdventure.cboWeapons.Visible = false;
                _superAdventure.cboPotions.Visible = false;
                _superAdventure.btnUseWeapon.Visible = false;
                _superAdventure.btnUsePotion.Visible = false;
            }
        }

        public void SetExperiencePoints()
        {
            if (_currentMonster.RewardExperiencePoints > _superAdventure.player.ComputeExperiencePoints)
            {
                _currentMonster.RewardExperiencePoints = _superAdventure.player.ComputeExperiencePoints;
                _superAdventure.player.ExperiencePoints += _currentMonster.RewardExperiencePoints;
            }
            else
                _superAdventure.player.ExperiencePoints += _currentMonster.RewardExperiencePoints;
        }

        public void SetGold()
        {
            _superAdventure.player.Gold += _currentMonster.RewardGold;
        }

        public void RollLoot(List<InventoryItem> lootedItems)
        {
            foreach (LootItem lootItem in _currentMonster.LootTable)
            {
                if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                {
                    lootedItems.Add(new InventoryItem(lootItem.Item, 1));
                }
            }
        }

    }
}
