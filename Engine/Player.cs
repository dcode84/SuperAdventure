using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class Player : NotifyPropertyChanged, IPlayer
    {
        private const double growthModifier = 1.618;

        private int _gold;
        private int _level;
        private int _experiencePoints;
        private int _strength;
        private int _intelligence;
        private int _vitality;
        private int _defense;
        private int _currentHitPoints;
        private int _maximumHitPoints;
        private int _statPoints;

        #region Properties

        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }

        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged("Gold");
            }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged("ExperiencePoints");
            }
        }

        public int Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
                OnPropertyChanged("Strength");
            }
        }

        public int Intelligence
        {
            get { return _intelligence; }
            set
            {
                _intelligence = value;
                OnPropertyChanged("Intelligence");
            }
        }

        public int Vitality
        {
            get { return _vitality; }
            set
            {
                _vitality = value;
                OnPropertyChanged("Vitality");
            }
        }

        public int Defense
        {
            get { return _defense; }
            set
            {
                _defense = value;
                OnPropertyChanged("Defense");
            }
        }

        public int CurrentHitPoints
        {
            get { return _currentHitPoints; }
            set
            {
                _currentHitPoints = value;
                OnPropertyChanged("CurrentHitPoints");
            }
        }

        public int MaximumHitPoints
        {
            get { return _maximumHitPoints; }
            set
            {
                _maximumHitPoints = value;
                OnPropertyChanged("MaximumHitPoints");
            }
        }

        public int StatPoints
        {
            get { return _statPoints; }
            set
            {
                _statPoints = value;
                OnPropertyChanged("StatPoints");
            }
        }

        public int ComputeExperiencePoints
        {
            get { return (int)((Level * 50) * (Level * growthModifier)); }
        }
        public double ComputeDamageReduction
        {
            get { return (double)Defense / (Defense + 200); }
        }
        public ILocation CurrentLocation { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }

        #endregion

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
            Inventory.Add(new InventoryItem(World.ItemByDB(World.ITEM_ID_CHAIN_MAIL), 1));
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
