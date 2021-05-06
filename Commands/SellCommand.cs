using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class SellCommand : Command
    {
        public SellCommand()
        {
            this.Name = "sell";
        }

        override
        public bool Execute(Player player)
        {
            string itemName = "";
            //this allows for an unlimited number of words
            while (QWords.Count > 0)
            {
                itemName += QWords.Dequeue() + " ";
            }
            itemName = itemName.TrimEnd();

            if(player.Bag.CheckForItem(itemName) == false)
            {
                player.OutputMessage("\nYou don't have this item");
            }
            else if(itemName == "bag")
            {
                player.OutputMessage("\nYou shouldn't sell your bag");
            }
            else
            {
                if(player.Bag.CheckForItem(itemName) == true)
                {
                    IItem item = player.Take(itemName);
                    player.GetMoney(item.SellPrice);
                    player.OutputMessage("\nYou recieved " + item.SellPrice + " money");
                }
            }
            return false;
        }
}
}
