using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class GoCommand : Command
    {

        public GoCommand() : base()
        {
            this.Name = "go";
        }

        override
        public bool Execute(Player player)
        {
            string rooms = "";
            if (QWords.Count == 0)
            {
                player.OutputMessage("\nGo Where?");
            }
            else
            {
                //this allows for an unlimited number of words
                while (QWords.Count > 0)
                {
                    rooms += QWords.Dequeue() + " ";
                }
                rooms = rooms.TrimEnd();
                player.WaltTo(rooms);
            }
            return false;
        }
    }
}
