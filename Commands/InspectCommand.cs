using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class InspectCommand : Command
    {
        public InspectCommand() : base()
        {
            this.Name = "inspect";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.Inspect(this.SecondWord);
            }
            else
            {
                player.OutputMessage("\nInspect What?");
            }
            return false;
        }
    }
}
