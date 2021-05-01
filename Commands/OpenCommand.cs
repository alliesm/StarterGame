using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class OpenCommand : Command
    {
        public OpenCommand() : base()
        {
            this.Name = "open";
        }

        override
        public bool Execute(Player player)
        {
            string lockedDoor = "";
            if (QWords.Count == 0)
            {                
                player.OutputMessage("\nOpen What?");
            }
            else
            {
                while (QWords.Count > 0)
                {
                    lockedDoor += QWords.Dequeue() + " ";
                }
                lockedDoor = lockedDoor.TrimEnd();
                player.Open(lockedDoor);
            }
            return false;
        }
    }
}
