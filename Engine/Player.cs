using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : LivingCreature
    {
        public int Gold { get; set; }
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
        private const double growthModifier = 1.618;

        public int ExperiencePointsNeeded
        {
            get { return (int) ((Level * 50) * (Level * growthModifier)); }
        }

        public Location CurrentLocation { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }

        public Player (int gold, int level, int experiencePoints, int maximumHitPoints, int currentHitPoints) 
            : base(maximumHitPoints, currentHitPoints)
        {
            Gold = gold;
            Level = level;
            ExperiencePoints = experiencePoints;
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }

        public void LevelUp()
        {
            while (ExperiencePoints >= ExperiencePointsNeeded)
            {
                int extraEXP = ExperiencePoints - (int)ExperiencePointsNeeded;
                Level++;
                ExperiencePoints = extraEXP;
            }
        }
       
        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            // Check if there is a item required to enter and checks if the player has this item
            if (location.ItemRequiredToEnter == null)
            {
                return true;
            }          
            return Inventory.Exists(inventoryItem => inventoryItem.Details.ID == location.ItemRequiredToEnter.ID);
        }

        public bool HasThisQuest(Quest quest)
        {
            // Check if the player already has this quest
            return Quests.Exists(playerQuest => playerQuest.Details.ID == quest.ID);
        }

        public bool CompletedThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.IsCompleted;
                }
            }

            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            // See if the player has all the items needed to complete the quest here
            // Check each item in the player's inventory, to see if they have it, and enough of it
            // If we got there, then the player must have all the required items, and enough of them, to complete the quest.
            foreach (QuestCompletionItem questCompletionItem in quest.QuestCompletionItems)
            {
                if (!Inventory.Exists(inventoryItem => inventoryItem.Details.ID == questCompletionItem.Details.ID
                        && inventoryItem.Quantity >= questCompletionItem.Quantity)) 
                {
                    return false;
                }
            }
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            // Check the list of QuestCompletionItems and check if the items in the inventory match this list,
            // if not null, remove quest items from inventory
            foreach (QuestCompletionItem questCompletionItem in quest.QuestCompletionItems)
            {
                InventoryItem item = Inventory.SingleOrDefault(inventoryItem => inventoryItem.Details.ID == questCompletionItem.Details.ID);

                if (item != null)
                {
                    item.Quantity -= questCompletionItem.Quantity;
                }
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            // Check for the item to add, if its null, add 1 to quantity, otherwise increase it by 1
            InventoryItem item = Inventory.SingleOrDefault(inventoryItem => inventoryItem.Details.ID == itemToAdd.ID);

            if (item == null)
            {
                Inventory.Add(new InventoryItem(itemToAdd, 1));
            }
            else
            {
                item.Quantity++;
            }
        }

        public void RemoveHealingPotionFromInventory(Item potionToRemove)
        {
            // Check for a potion in the inventory and decrease its quantity by 1 
            InventoryItem item = Inventory.SingleOrDefault(inventoryItem => inventoryItem.Details.ID == potionToRemove.ID);
            if (item != null)
            {
                item.Quantity--;
            }
        }

        public void MarkQuestCompleted(Quest quest)
        {
            // Find the quest in the player's quest list, if not null, mark as completed
            PlayerQuest playerQuest = Quests.SingleOrDefault(playerQ => playerQ.Details.ID == quest.ID);
            if (playerQuest != null)
            {
                playerQuest.IsCompleted = true;
            }
        }
    }
}
