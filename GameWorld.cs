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
                return _instance;
            }
        }

        private Room _outside;
        public Room Entrance
        {
            get
            {
                return _outside;
            }
        }
        private Room MainCorridor;
        private Room bossFight;


        private List<Room> roomList;

        private GameWorld()
        {
            roomList = new List<Room>();
            _outside = CreateWorld();


            //Notifications go here
            NotificationCenter.Instance.AddObserver("Picked up key", foundKey);
            NotificationCenter.Instance.AddObserver("found bag", foundBag);
        }

        public Room CreateWorld()
        {
            Room outside = new Room("outside the main entrance of the dungeon");
            Room infirmary = new Room("in the infirmary");
            Room mainCorridor = new Room("in the main corridor");
            Room garrison = new Room("in the garrison");
            Room armory = new Room("in the armory");
            Room library = new Room("in the library");
            Room tradingRoom = new Room("in the blacksmith's forge");
            Room garden = new Room("in the garden");
            Room finalRoom = new Room("in the lair of ....");

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
            MainCorridor = mainCorridor;
            bossFight = finalRoom;


            //Puts items in world
            IItem sword = new Item("sword", 5.3f, 3.2, 2, 1, "this is the hilt a broken knight's longsword");
            IItem decorator = new Item("blade", 9.7f, 7, 3, 2, "the blade to the broken sword");
            sword.AddDecorator(decorator);
            mainCorridor.Drop(sword);



            IItem axe = new Item("axe", 6.1f, 6, 20, 10, "an axe");
            IItem shield = new Item("shield", 15.3f, 8, 15, 20, "a shield for blocking");
            IItem wand = new Item("wand", 6.4f, 4, 50, 50, "a powerful mage's wand");

            IItem itemContainer = new ItemContainer("lockbox", 4f, 6, 5, 2, 3, "holds the key to the boss door");
            IItem itemInContainer = new Item("key", 0.01f, 0.01, 0, 0, "the key to the boss door");
            itemContainer.AddItem(itemInContainer);
            armory.Drop(itemContainer);


            return outside;
        }


        //posts a notification to tell the player that they can go to the final boss door
        public void foundKey(Notification notification)
        {
            Player player = (Player)notification.Object;

            if(player.Bag.CheckForItem("key") == true)
            {
                Console.WriteLine("\nYou found the key to the boss door. Make sure you're ready for this fight"
                    + ", then head to the boss lair and open the door");
            }
        }

        //gives the player a bag when they enter the main corridor
        public void foundBag(Notification notification)
        {
            Player player = (Player)notification.Object;

            if (player.CurrentRoom == MainCorridor)
            {
                GiveBag(player);                
            }
        }
        public void GiveBag(Player player)
        {
            if(player.Bag == null)
            {
                Console.WriteLine("\nYou found a bag, this allows you to store items ");
                player.Bag = new Bag();
                Console.WriteLine(player.Bag.Description);
            }
        }
    }
}
