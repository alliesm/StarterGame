using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class BlackSmith : ILivingCreature
    {
        public int CurrentHitPoints { get; set; }
        public int MaximumHitPoints { get; set; }

        private string _name = "blacksmith";
        public string Name { get { return _name; } }

        private string _description = "a smithy you can trade with";
        public string Description { get { return _description; } }

        private Dictionary<string, IItem> _inventory;
        public Dictionary<string, IItem> Inventory { get { return _inventory; } set { _inventory = value; } }

        private static IItem[] TraderGoods = { new Sword(), new axe(), new wand(), new shield() };

        private Room _blackSmithRoom;
        public Room BlackSmithRoom { get { return _blackSmithRoom; } }

        public BlackSmith(Room room)
        {
            _blackSmithRoom = room;
            _inventory = new Dictionary<string, IItem>();
            foreach (IItem item in TraderGoods) { _inventory[item.Name] = item; }

            NotificationCenter.Instance.AddObserver("Talk_blacksmith", Talk_blacksmith);
            NotificationCenter.Instance.AddObserver("LeaveSmith", LeaveSmith);
            NotificationCenter.Instance.AddObserver("ViewGoods", ViewGoods);
            NotificationCenter.Instance.AddObserver("BuyMessage", BuyMessage);
        }

        private void Talk_blacksmith(Notification notification)
        {
            Player player = (Player)notification.Object;
            NotificationCenter.Instance.PostNotification(new Notification("PushSmithCommands", this));
            player.OutputMessage("\nCurrent Player Money: " + player.Money);
            Console.WriteLine("\nWould you like to: \nBuy Items \nView Goods \nor \nSell Items?");
        }

        public void LeaveSmith(Notification notification)
        {
            Console.WriteLine("\nI hope you come back.\n");
        }

        public void ViewGoods(Notification notification)
        {
            string itemDisplay = "";
            Dictionary<string, IItem>.ValueCollection values = Inventory.Values;
            foreach (IItem item in values)
            {
                itemDisplay += item.Name + ": " + item.BuyPrice + " | " + item.SellPrice + "\n";
            }
            Console.WriteLine("\nItem Name: Buy Value | Sell Value");
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine(itemDisplay);
        }

        public IItem itemFromInventory(string name)
        {
            IItem item = null;
            Inventory.TryGetValue(name, out item);
            return item;
        }

        public void BuyMessage(Notification notification)
        {
            Console.WriteLine("\nThanks for buyin'");
        }
    }
}
