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
            Room outside = new Room("outside the main entrance of the university");
            Room cctparking = new Room("in the parking lot at CCT");
            Room boulevard = new Room("on the boulevard");
            Room universityParking = new Room("in the parking lot at University Hall");
            Room parkingDeck = new Room("in the parking deck");
            Room cct = new Room("in the CCT building");
            Room theGreen = new Room("in the green in from of Schuster Center");
            Room universityHall = new Room("in University Hall");
            Room schuster = new Room("in the Schuster Center");

            outside.SetExit("west", boulevard);

            boulevard.SetExit("east", outside);
            boulevard.SetExit("south", cctparking);
            boulevard.SetExit("west", theGreen);
            boulevard.SetExit("north", universityParking);

            cctparking.SetExit("west", cct);
            cctparking.SetExit("north", boulevard);

            cct.SetExit("east", cctparking);
            cct.SetExit("north", schuster);

            schuster.SetExit("south", cct);
            schuster.SetExit("north", universityHall);
            schuster.SetExit("east", theGreen);

            theGreen.SetExit("west", schuster);
            theGreen.SetExit("east", boulevard);

            universityHall.SetExit("south", schuster);
            universityHall.SetExit("east", universityParking);

            universityParking.SetExit("south", boulevard);
            universityParking.SetExit("west", universityHall);
            universityParking.SetExit("north", parkingDeck);

            parkingDeck.SetExit("south", universityParking);

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
