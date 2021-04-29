using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class PickupCommand : Command
    {
        public PickupCommand() : base()
        {
            this.Name = "pickup";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.PickUp(this.SecondWord);
            }
            else
            {
                player.OutputMessage("\nPickup What?");
            }
            return false;
        }
    }
}
