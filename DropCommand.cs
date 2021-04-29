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
            if (this.HasSecondWord())
            {
                player.Drop(this.SecondWord);
            }
            else
            {
                player.OutputMessage("\nDrop What?");
            }
            return false;
        }
    }
}
