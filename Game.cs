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
            player = new Player(GameWorld.Instance.Entrance);
            player.CurrentHitPoints = 10;
            player.MaximumHitPoints = 10;
            player.Gold = 20;
            
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
            return "Welcome to the World of Monstrosity!\n\n The World of Monstrosity is a new, incredibly boring adventure game.\n\nType 'help' if you need help." + player.CurrentRoom.Description();
        }

        public string Goodbye()
        {
            return "\nThank you for playing, Goodbye. \n";
        }

    }
}
