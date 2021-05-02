using System;
namespace StarterGame
{
    public class BagCommand : Command
    {

        public BagCommand() : base()
        {
            this.Name = "bag";
        }

        override
        public bool Execute(Player player)
        {
            if (player.Bag != null)
            {
                NotificationCenter.Instance.PostNotification(new Notification("ShowBagCommands", this));
                player.OutputMessage("\nMoney: " + player.Money);
                player.OutputMessage(player.Bag.ShowInventory() +
                    "\nType 'close bag' to close your bag");
            }
            else
            {
                player.OutputMessage("You don't have a bag yet");
            }
            return false;
        }
    }
}
