using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class CloseBagCommand : Command
    {
        public CloseBagCommand()
        {
            this.Name = "close bag";
        }

        override
        public bool Execute(Player player)
        {
            NotificationCenter.Instance.PostNotification(new Notification("ShowCommands"));
            player.OutputMessage("\n" + player.CurrentRoom.Description());
            return false;
        }
    }
}
