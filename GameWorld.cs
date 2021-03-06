using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class GameWorld
    {
        static private GameWorld _instance;
        static public GameWorld Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameWorld();
                
                PopulateMonsters();
                PopulateQuests();
                
                return _instance;
            }
        }

        private Room _entrance;
        public Room Entrance
        {
            get
            {
                return _entrance;
            }
            private set { _entrance = value; }
        }

        private Room _teleport;
        public Room Teleport
        {
            get { return _teleport; }
            private set { _teleport = value; }
        }

        private Room _trap;
        public Room Trap
        {
            get { return _trap; }
            private set { _trap = value; }
        }

        private Room _mainCorridor;
        public Room MainCorridor
        {
            get { return _mainCorridor; }
            private set { _mainCorridor = value; }
        }

        private Room _exit;
        public Room Exit
        {
            get { return _exit; }
            private set { _exit = value; }
        }
        
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        

        public const int MONSTER_ID_Boss = 1;
        public const int MONSTER_ID_Troll = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;

        public const int QUEST_ID_CLEAR_GARDEN = 1;
        public const int QUEST_ID_CLEAR_armory = 2;

        private GameWorld()
        {
            _entrance = CreateWorld();

            //Notifications go here
            NotificationCenter.Instance.AddObserver("FoundKey", FoundKey);
            NotificationCenter.Instance.AddObserver("FoundBag", FoundBag);
            NotificationCenter.Instance.AddObserver("PlayerEnteredInfirmary", PlayerEnteredInfirmary);
            //NotificationCenter.Instance.AddObserver("PlayerWin", PlayerWin);
        }
        private static void PopulateMonsters()
        {
            Monster boss = new Monster(MONSTER_ID_Boss, "Boss", 20, 10, 10, 10);
            //boss.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAT_TAIL), 75, false));
            //boss.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PIECE_OF_FUR), 75, true));

            Monster troll = new Monster(MONSTER_ID_Troll, "Troll", 5, 20, 3, 3);
            //troll.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
            //troll.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKESKIN), 75, true));

            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "Giant spider", 10, 40, 6, 6);
            //giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_FANG), 75, true));
            //giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_SILK), 25, false));

            Monsters.Add(boss);
            Monsters.Add(troll);
            Monsters.Add(giantSpider);
        }
        private static void PopulateQuests()
        {
            Quest clearGarden =
                new Quest(
                    QUEST_ID_CLEAR_GARDEN,
                    "Clear the garden",
                    "Kill the Troll in the garden. You will receive 20 gold pieces.", 20);

            //clearGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_RAT_TAIL), 3));

            //clearGarden.RewardItem = ItemByID(ITEM_ID_HEALING_POTION);

            Quest clearArmory =
                new Quest(
                    QUEST_ID_CLEAR_armory,
                    "Clear the Armory",
                    "Kill the Giant spider in the armory. You will receive 20 gold pieces.", 20);

            //clearArmory.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 3));

            //clearArmory.RewardItem = ItemByID(ITEM_ID_ADVENTURER_PASS);

            Quests.Add(clearGarden);
            Quests.Add(clearArmory);
        }

        public Room CreateWorld()
        {
            Room outside = new Room("outside the main entrance of the dungeon");
            Room infirmary = new Room("the infirmary");
            Room mainCorridor = new Room("the main corridor");
            Room garrison = new Room("the garrison");
            Room armory = new Room("the armory");
            Room library = new Room("the library");
            Room tradingRoom = new Room("the blacksmith's forge");
            Room garden = new Room("the garden");
            Room finalRoom = new Room("the lair of ....");

            //outside.SetExit("east", mainCorridor);
            //mainCorridor.SetExit("west", outside);
            //Door door = new Door(mainCorridor, outside);
            //outside.SetExit("east", door);
            //mainCorridor.SetExit("west", door);
            Door door = Door.CreateDoor(outside, mainCorridor, "outside", "main corridor");


            //mainCorridor.SetExit("east", garden);
            //garden.SetExit("west", mainCorridor);
            door = Door.CreateDoor(mainCorridor, garden, "main corridor", "garden");

            //mainCorridor.SetExit("south", garrison);
            //garrison.SetExit("north", mainCorridor);
            door = Door.CreateDoor(mainCorridor, garrison, "main corridor", "garrison");

            //mainCorridor.SetExit("north", tradingRoom);
            //tradingRoom.SetExit("south", mainCorridor);
            door = Door.CreateDoor(mainCorridor, tradingRoom, "main corridor", "blacksmith forge");

            //garrison.SetExit("south", armory);
            //armory.SetExit("north", garrison);
            door = Door.CreateDoor(garrison, armory, "garrison", "armory");

            //garden.SetExit("south", infirmary);
            //infirmary.SetExit("north", garden);
            door = Door.CreateDoor(garden, infirmary, "garden", "infirmary");

            //garden.SetExit("north", library);
            //library.SetExit("south", garden);
            door = Door.CreateDoor(garden, library, "garden", "library");

            //garden.SetExit("east", finalRoom);
            //finalRoom.SetExit("west", garden);
            door = Door.CreateDoor(garden, finalRoom, "garden", "boss lair");
            door.close();

            //triggers notification
            Entrance = outside;
            MainCorridor = mainCorridor;
            Teleport = infirmary;
            Trap = armory;
            Exit = finalRoom;

            //Puts items in world
            IItem sword = new Item("sword", 5.3f, 3.2, 3, 5, "this is the hilt a broken knight's longsword");
            IItem decorator = new Item("blade", 9.7f, 4, 5, 10, "the blade to the broken sword");
            sword.AddDecorator(decorator);
            mainCorridor.Drop(sword);

            tradingRoom.AddNpc(new BlackSmith(tradingRoom));

            IItem flagpole = new Item("flag pole", 0f, 60, 0, 0, "a flag flying the banner of an unfamiliar group");
            mainCorridor.Drop(flagpole);

            //IItem axe = new Item("axe", 6.1f, 6, 20, 10, "an axe");
            //IItem shield = new Item("shield", 15.3f, 8, 15, 20, "a shield for blocking");
            //IItem wand = new Item("wand", 6.4f, 4, 50, 50, "a powerful mage's wand");

            //IItem itemContainer = new ItemContainer("lockbox", 4f, 6, 5, 2, 3, "holds the key to the boss door");
            IItem key = new Item("key", 0.01f, 0.01, 0, 0, "the key to the boss door");
            //itemContainer.AddItem(itemInContainer);
            armory.Drop(key);


            return outside;
        }

        //send player to the armory when they enter the infirmary
        public void PlayerEnteredInfirmary(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.CurrentRoom == Teleport)
            {
                player.CurrentRoom = Trap;
                Console.WriteLine("****");
                Console.WriteLine("You have been transported to the armory");
                Console.WriteLine("****");
            }
        }

        //posts a notification to tell the player that they can go to the final boss door
        public void FoundKey(Notification notification)
        {
            Player player = (Player)notification.Object;

            if (player.Bag.CheckForItem("key") == true)
            {
                Console.WriteLine("****");
                Console.WriteLine("\nYou found the key to the boss door. Make sure you're ready for this fight"
                    + ", then head to the boss lair and open the door");
                Console.WriteLine("****");
            }
        }

        //gives the player a bag when they enter the main corridor
        public void FoundBag(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.CurrentRoom == MainCorridor)
            {
                GivePlayerBag(player);
            }
        }
        public void GivePlayerBag(Player player)
        {
            if (player.Bag == null)
            {
                Console.WriteLine("\nYou found a bag, this will allow you to store items ");
                Console.WriteLine("***");
                player.Bag = new Bag();
                Console.WriteLine(player.Bag.Description);
            }
        }

        /*public void PlayerWin(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.CurrentRoom == Exit)
            {
                Console.WriteLine("****");
                Console.WriteLine("You enter the boss room and fight a grueling fight against the terror in the cave, and save the princess. You then leave the dungeon and collect your reward.");
                Console.WriteLine("****");                
            }
        }*/
    }
}
