using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        #region IDs
        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKE_SKIN = 5;
        public const int ITEM_ID_CLUB = 6;
        public const int ITEM_ID_HEALING_POTION = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_ADVANTURER_PASS = 10;
        public const int ITEM_ID_COTTON_SHIRT = 11;
        public const int ITEM_ID_COTTON_HELM = 12;
        public const int ITEM_ID_COTTON_PANTS = 13;
        public const int ITEM_ID_COTTON_GLOVES = 14;

        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;

        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
        public const int LOCATION_ID_FARM_HOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;
        #endregion

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Rusty Sword", "Rusty Swords", 0, 5));
            Items.Add(new Item(ITEM_ID_RAT_TAIL, "Rat Tail", "Rat Tails"));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, "Piece of fur", "Pieces of fur"));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Snake fang", "Snake fangs"));
            Items.Add(new Item(ITEM_ID_SNAKE_SKIN, "Snake skin", "Snake skins"));
            Items.Add(new Weapon(ITEM_ID_CLUB, "Club", "Clubs", 3, 10));
            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, "Healing Potion", "Healing Potions", 5));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, "Spider fang", "Spider fangs"));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, "Spider silk", "Spider silks"));
            Items.Add(new Item(ITEM_ID_ADVANTURER_PASS, "Adventurers pass", "Adventurers passes"));
            Items.Add(new ArmorHelm(ITEM_ID_COTTON_HELM, "Cotton Helm", "Cotton Helmets", 3, 1));
            Items.Add(new ArmorChest(ITEM_ID_COTTON_SHIRT, "Cotton Shirt", "Cotton Shirts", 10, 2));
            Items.Add(new ArmorPants(ITEM_ID_COTTON_PANTS, "Cotton Pants", "Cotton Pants", 7, 3));
            Items.Add(new ArmorGloves(ITEM_ID_COTTON_GLOVES, "Cotton Gloves", "Cotton Gloves", 5, 4));
        }

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(MONSTER_ID_RAT, "Rat", 5, 80, 10, 3, 3);
            rat.LootTable.Add(new LootItem(ItemByDB(ITEM_ID_RAT_TAIL), 75, false));
            rat.LootTable.Add(new LootItem(ItemByDB(ITEM_ID_PIECE_OF_FUR), 75, true));

            Monster snake = new Monster(MONSTER_ID_SNAKE, "Snake", 5, 3, 10, 3, 3);
            snake.LootTable.Add(new LootItem(ItemByDB(ITEM_ID_SNAKE_FANG), 75, false));
            snake.LootTable.Add(new LootItem(ItemByDB(ITEM_ID_SNAKE_SKIN), 75, true));

            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "Giant Spider", 20, 5, 40, 10, 10);
            giantSpider.LootTable.Add(new LootItem(ItemByDB(ITEM_ID_SPIDER_FANG), 75, false));
            giantSpider.LootTable.Add(new LootItem(ItemByDB(ITEM_ID_SPIDER_SILK), 25, true));

            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
        }

        private static void PopulateQuests()
        {
            Quest clearAlchemistGarden =
            new Quest(
                QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                "Clear the alchemist's garden",
                "Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive a healing potion and 10 gold.", 20, 10);

            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByDB(ITEM_ID_RAT_TAIL), 3));
            clearAlchemistGarden.RewardItem = ItemByDB(ITEM_ID_HEALING_POTION);

            Quest clearFarmersField =
            new Quest(
                QUEST_ID_CLEAR_FARMERS_FIELD,
                "Clear the farmer's garden",
                "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass and 20 gold.", 20, 20);

            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemByDB(ITEM_ID_SNAKE_FANG), 3));
            clearFarmersField.RewardItem = ItemByDB(ITEM_ID_ADVANTURER_PASS);

            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }

        private static void PopulateLocations()
        {
            Location home = new Location(LOCATION_ID_HOME, "Home", "This is your home");

            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town square", "You see a fountain");

            Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemists hut", "There are many strange plants on the shelves.");
            alchemistHut.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

            Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemists garden", "Many strange plants are growing here.");
            alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);

            Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard post", "This is the guards post.");

            Location farmersHouse = new Location(LOCATION_ID_FARM_HOUSE, "Farm house", "There's a few farmers here.");
            farmersHouse.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);

            Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmers field", "There grows this seasons food");
            farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);

            Location bridge = new Location(LOCATION_ID_BRIDGE, "The Bridge", "This bridge needs to be repaired in some way");

            Location spidersField = new Location(LOCATION_ID_SPIDER_FIELD, "Spiders field", "Do you really want to be here?");
            spidersField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);

            #region LOCATIONS
            home.LocationToNorth = townSquare;

            townSquare.LocationToEast = guardPost;
            townSquare.LocationToNorth = alchemistHut;
            townSquare.LocationToSouth = home;
            townSquare.LocationToWest = farmersHouse;

            guardPost.LocationToWest = townSquare;
            guardPost.LocationToEast = bridge;

            bridge.LocationToEast = spidersField;
            bridge.LocationToWest = guardPost;

            spidersField.LocationToWest = bridge;

            alchemistHut.LocationToSouth = townSquare;
            alchemistHut.LocationToNorth = alchemistsGarden;

            alchemistsGarden.LocationToSouth = alchemistHut;

            farmersHouse.LocationToWest = farmersField;
            farmersHouse.LocationToEast = townSquare;

            farmersField.LocationToEast = farmersHouse;


            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(bridge);
            Locations.Add(spidersField);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmersHouse);
            Locations.Add(farmersField);

            #endregion
        }

        public static Item ItemByDB(int id)
        {
            foreach(Item item in Items)
            {
                if (item.ID == id)
                    return item;
            }
            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach(Monster monster in Monsters)
            {
                if (monster.ID == id)
                    return monster;
            }
            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach(Quest quest in Quests)
            {
                if (quest.ID == id)
                    return quest;
            }
            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach(Location location in Locations)
            {
                if (location.ID == id)
                    return location;
            }
            return null;
        }
    }
}
