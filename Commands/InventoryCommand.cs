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
            if (QWords.Count > 0)
            {
                player.OutputMessage("\nI cannot Inventory " + QWords);
            }
            else
            {
                player.Inventory();
            }
            return false;
        }
    }
}
