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
            Room tradingRoom = new Room("in the blacksmithing area");
            Room garden = new Room("in the garden");
            Room finalRoom = new Room("in the lair of ....");

            outside.SetExit("east", mainCorridor);

            mainCorridor.SetExit("east", garden);
            mainCorridor.SetExit("south", garrison);
            mainCorridor.SetExit("west", outside);
            mainCorridor.SetExit("north", tradingRoom);

            tradingRoom.SetExit("south", mainCorridor);

            garrison.SetExit("south", armory);
            garrison.SetExit("north", mainCorridor);

            garden.SetExit("south", infirmary);
            garden.SetExit("north", library);
            garden.SetExit("west", mainCorridor);
            garden.SetExit("east", finalRoom);

            library.SetExit("south", garden);
            
            infirmary.SetExit("north", garden);
            
            finalRoom.SetExit("west", garden);

            //Puts items in world
            IItem sword = new Item("sword", 5.3f, 6.4, "this is a broken knight's longsword sword");
            IItem decorator = new Item("blade", 9.7f, 8.6, "the blade to the broken sword");
            sword.AddDecorator(decorator);
            mainCorridor.Drop(sword);

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
