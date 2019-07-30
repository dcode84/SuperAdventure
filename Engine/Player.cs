using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : IPlayer
    {
        public int Gold { get; set; }
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }

        private const double growthModifier = 1.618;
        public int ComputeExperiencePoints
        {
            get { return (int)((Level * 50) * (Level * growthModifier)); }
        }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Vitality { get; set; }
        public int Defense { get; set; }
        public double ComputeDamageReduction
        {
            get { return (double)Defense / (Defense + 200); }
        }
        public int StatPoints { get; set; }
        public ILocation CurrentLocation { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }
        public int CurrentHitPoints { get; set; }
        public int MaximumHitPoints { get; set; }

        public Player(int gold, int level, int experiencePoints, int strength, int intelligence, int vitality, int defense, int maximumHitPoints, int currentHitPoints)
        {
            Gold = gold;
            Level = level;
            ExperiencePoints = experiencePoints;
            Strength = strength;
            Intelligence = intelligence;
            Vitality = vitality;
            Defense = defense;
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
            CurrentHitPoints = currentHitPoints;
            MaximumHitPoints = maximumHitPoints;
            Inventory.Add(new InventoryItem(World.ItemByDB(World.ITEM_ID_RUSTY_SWORD), 1));
            Inventory.Add(new InventoryItem(World.ItemByDB(World.ITEM_ID_COTTON_HELM), 1));
            Inventory.Add(new InventoryItem(World.ItemByDB(World.ITEM_ID_COTTON_SHIRT), 1));
            Inventory.Add(new InventoryItem(World.ItemByDB(World.ITEM_ID_COTTON_PANTS), 1));
            Inventory.Add(new InventoryItem(World.ItemByDB(World.ITEM_ID_COTTON_GLOVES), 1));
        }

        public void LevelUp()
        {
            while (ExperiencePoints >= ComputeExperiencePoints)
            {
                int extraEXP = ExperiencePoints - ComputeExperiencePoints;
                Level++;
                StatPoints++;
                MaximumHitPoints = MaximumHitPoints + 1;
                ExperiencePoints = extraEXP;
            }
        }

        // Check if there is a item required to enter and checks if the player has this item
        public bool HasRequiredItemToEnterLocation(ILocation location)
        {
            if (location.ItemRequiredToEnter == null)
                return true;

            return Inventory.Exists(inventoryItem => inventoryItem.Item.ID == location.ItemRequiredToEnter.ID);
        }

        // Check if the player already has this quest
        public bool HasThisQuest(IQuest quest)
        {
            return Quests.Exists(playerQuest => playerQuest.Quest.ID == quest.ID);
        }

        public bool CompletedThisQuest(IQuest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Quest.ID == quest.ID)
                    return playerQuest.IsCompleted;
            }
            return false;
        }

        // See if the player has all the items needed to complete the quest here
        // Check each item in the player's inventory, to see if they have it, and enough of it
        // If we got there, then the player must have all the required items, and enough of them, to complete the quest.
        public bool HasAllQuestCompletionItems(IQuest quest)
        {
            foreach (IQuestCompletionItem questCompletionItem in quest.QuestCompletionItems)
            {
                if (!Inventory.Exists(inventoryItem => inventoryItem.Item.ID == questCompletionItem.Item.ID
                                      && inventoryItem.Quantity >= questCompletionItem.Quantity))
                {
                    return false;
                }
            }
            return true;
        }

        // Check the list of QuestCompletionItems and check if the items in the inventory match this list,
        // if not null, remove quest items from inventory
        public void RemoveQuestCompletionItems(IQuest quest)
        {
            foreach (IQuestCompletionItem questCompletionItem in quest.QuestCompletionItems)
            {
                InventoryItem item = Inventory.SingleOrDefault(inventoryItem => inventoryItem.Item.ID == questCompletionItem.Item.ID);

                if (item != null)
                    item.Quantity -= questCompletionItem.Quantity;
            }
        }

        // Check for the item to add, if its null, add 1 to quantity, otherwise increase it by 1
        public void AddItemToInventory(IItem itemToAdd)
        {
            InventoryItem item = Inventory.SingleOrDefault(inventoryItem => inventoryItem.Item.ID == itemToAdd.ID);

            if (item == null)
                Inventory.Add(new InventoryItem(itemToAdd, 1));
            else
                item.Quantity++;
        }

        // Check for a potion in the inventory and decrease its quantity by 1 
        public void RemoveHealingPotionFromInventory(IItem potionToRemove)
        {
            InventoryItem item = Inventory.SingleOrDefault(inventoryItem => inventoryItem.Item.ID == potionToRemove.ID);

            if (item != null)
                item.Quantity--;
        }

        // Find the quest in the player's quest list, if not null, mark as completed
        public void MarkQuestCompleted(IQuest quest)
        {
            PlayerQuest playerQuest = Quests.SingleOrDefault(playerQ => playerQ.Quest.ID == quest.ID);

            if (playerQuest != null)
                playerQuest.IsCompleted = true;
        }
    }
}
