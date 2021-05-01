using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StarterGame
{
    public class Bag : IItem
    {
        private Dictionary<string, IItem> _container;

        public string Name { get; set; }

        private int _capacity;
        public int Capacity { get { return _capacity; } }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }
        private float _weight;
        public float Weight
        {
            get
            {
                float containedweight = 0;
                foreach (IItem item in _container.Values)
                {
                    containedweight += item.Weight;
                }
                return containedweight + _weight + (_decorator != null ? _decorator.Weight : 0);
            }
            set
            {
                _weight = value;
            }
        }
        private double _volume;
        public double Volume
        {
            get
            {
                return _volume + (_decorator != null ? _decorator.Volume : 0);
            }
            set
            {
                _volume = value;
            }
        }
        private string _description;
        public string Description
        {
            get
            {
                string itemList = "Items: ";
                foreach (IItem item in _container.Values)
                {
                    itemList += "\n " + item.Description;
                }
                return "\nName: " + Name + ", Weight: " + Weight + ", Volume: " + Volume + ", Capacity: " + Capacity + ", Buy Price: " + BuyPrice + ", Sell Price: " + SellPrice + ", " + _description + "\n" + itemList;
            }
        }

        private Dictionary<string, List<IItem>> _inventory;
        public Dictionary<string, List<IItem>> Inventory { get { return _inventory; } }

        //Designated constructor
        public Bag()
        {
            _container = new Dictionary<string, IItem>();
            Name = "bag";
            Weight = 0;
            Volume = 0;
            _description = "the inventory holds all the players items";
            _decorator = null;
            _capacity = 50;
            BuyPrice = 0;
            SellPrice = 0;
            _inventory = new Dictionary<string, List<IItem>>();
        }

        private IItem _decorator;
        public void AddDecorator(IItem decorator)
        {
            if (_decorator == null)
            {
                _decorator = decorator;
            }
            else
            {
                _decorator.AddDecorator(decorator);
            }
        }

        public bool IsContainer { get { return true; } }


        //Puts items in the Bag
        public void AddItem(IItem item)
        {
            List<IItem> check = null;
            Inventory.TryGetValue(item.Name, out check);
            if (check == null)
            {
                Inventory[item.Name] = new List<IItem>();
                Inventory[item.Name].Add(item);
            }
            else
            {
                Inventory[item.Name].Add(item);
            }
        }
        public IItem RemoveItem(string itemName)
        {
            IItem item = null;
            _container.Remove(itemName, out item);
            return item;
        }



        //Weight of items
        public float weightInBag()
        {
            float temp = 0;
            Dictionary<string, List<IItem>>.ValueCollection values = Inventory.Values;
            foreach (List<IItem> items in values)
            {
                foreach (IItem item in items)
                {
                    temp += item.Weight;
                }
            }
            return temp;
        }

        //Tells if there is room in the bag
        public bool spaceInBag(IItem item)
        {
            if (this.Weight + item.Weight > _capacity)
            {
                Console.WriteLine("You do not have enough room in your bag.");
                return false;
            }
            return true;
        }

        //Displays items in the bag
        public string displayItems()
        {
            string list = "";
            Dictionary<string, List<IItem>>.ValueCollection values = Inventory.Values;
            list += "\nWeight in Bag: " + weightInBag();
            foreach (List<IItem> item in values)
            {
                list += item.First().Name;
            }
            return list;
        }

        //Checks if certain item is in bag
        public bool itemInBag(string item)
        {
            List<IItem> check = null;
            Inventory.TryGetValue(item, out check);
            return check != null;
        }
    }
}
