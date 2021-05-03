using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class InventoryCommand : Command
    {
        public InventoryCommand()
        {
            this.Name = "view goods";
        }

        override
        public bool Execute(Player player)
        {
            NotificationCenter.Instance.PostNotification(new Notification("ViewGoods"));
            return false;
        }
    }
}
