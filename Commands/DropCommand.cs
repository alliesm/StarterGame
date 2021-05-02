using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class DropCommand : Command
    {
        public DropCommand() : base()
        {
            this.Name = "drop";
        }

        override
        public bool Execute(Player player)
        {
            string dropItem = "";
            if (QWords.Count == 0)
            {
                player.OutputMessage("\nDrop What?");
            }
            else
            {
                //this allows for an unlimited number of words
                while (QWords.Count > 0)
                {
                    dropItem += QWords.Dequeue() + " ";
                }
                dropItem = dropItem.TrimEnd();
                player.Take(dropItem);
            }
            return false;
        }
    }
}
