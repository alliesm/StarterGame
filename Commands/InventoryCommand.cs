using System;
namespace StarterGame
{
    public class InventoryCommand : Command
    {

        public InventoryCommand() : base()
        {
            this.Name = "inventory";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.OutputMessage("\nI cannot Inventory " + this.SecondWord);
            }
            else
            {
                player.Inventory();
            }
            return false;
        }
    }
}
