using System;
namespace StarterGame
{
    public class LeaveCommand : Command
    {
        public LeaveCommand()
        {
            this.Name = "leave";
        }

        override
        public bool Execute(Player player)
        {
            NotificationCenter.Instance.PostNotification(new Notification("ShowCommands", this));
            NotificationCenter.Instance.PostNotification(new Notification("LeaveSmith", this));
            player.OutputMessage("\n" + player.CurrentRoom.Description());
            return false;
        }
    }
}
