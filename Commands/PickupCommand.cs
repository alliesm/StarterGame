using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class PickupCommand : Command
    {
        public PickupCommand() : base()
        {
            this.Name = "pick up";
        }

        override
        public bool Execute(Player player)
        {
            string grabItem = "";
            if (QWords.Count == 0)
            {
                player.OutputMessage("\nWhat would you like to pick up?");
            }
            if(player.Bag == null)
            {
                player.OutputMessage("\nYou have nowhere to store this item.");
            }
            else
            {
                //this allows for an unlimited number of words
                while (QWords.Count > 0)
                {
                    grabItem += QWords.Dequeue() + " ";
                }
                grabItem = grabItem.TrimEnd();
                player.PickUp(grabItem);
            }
            return false;
        }
    }
}
