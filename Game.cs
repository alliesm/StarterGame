using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Game
    {
        Player player;
        Parser parser;
        bool playing;

        public Game()
        {
            playing = false;
            parser = new Parser(new CommandWords());
            player = new Player(CreateWorld());
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

        /**
     *  Main play routine.  Loops until end of play.
     */
        public void Play()
        {

            // Enter the main command loop.  Here we repeatedly read commands and
            // execute them until the game is over.

            bool finished = false;
            while (!finished)
            {
                Console.Write("\n>");
                Command command = parser.ParseCommand(Console.ReadLine());
                if (command == null)
                {
                    Console.WriteLine("I don't understand...");
                }
                else
                {
                    finished = command.Execute(player);
                }
            }
        }


        public void Start()
        {
            playing = true;
            player.OutputMessage(Welcome());
        }

        public void End()
        {
            playing = false;
            player.OutputMessage(Goodbye());
        }

        public string Welcome()
        {
            return "Welcome to the World of CSU!\n\n The World of CSU is a new, incredibly boring adventure game.\n\nType 'help' if you need help." + player.CurrentRoom.Description();
        }

        public string Goodbye()
        {
            return "\nThank you for playing, Goodbye. \n";
        }

    }
}
