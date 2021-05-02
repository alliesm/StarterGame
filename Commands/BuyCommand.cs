using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class BuyCommand : Command
    {
        public BuyCommand()
        {
            this.Name = "buy";
        }

        override
        public bool Execute(Player player)
        {
            if (QWords.Count > 0)
            {
                string itemName = "";
                //this allows for an unlimited number of words
                while (QWords.Count > 0)
                {
                    itemName += QWords.Dequeue() + " ";
                }
                itemName = itemName.TrimEnd();
            }

            /*if(character != null)
            {
                IItem item = null;
                character.Inventory.TryGetValue(itemName, out item);
                if(item != null)
                {
                    if(player.Bag.SpaceInBag(item) && player.EnoughMoney(item.BuyPrice))
                    {
                        player.BuyItem(item.BuyPrice);
                        player.Bag.AddItem(item);
                    }
                }
            }
            else
            {
                player.OutputMessage("\nWhat would you like to buy?");
            }*/
            return false;
        }
    }
}
