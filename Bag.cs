using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StarterGame
{
    public class Bag : IItem
    {
        private Dictionary<string, List<IItem>> _container;
        public Dictionary<string, List<IItem>> Container { get { return _container; } }

        public string Name { get; set; }

        private int _capacity;
        public int Capacity { get { return _capacity; } }
        private int _volumeCapacity;
        public int VolumeCapacity { get { return _volumeCapacity; } }
                
        private int _buyPrice;
        public int BuyPrice { get { return _buyPrice; } set { _buyPrice = value; } }
        private int sellPrice;
        public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }

        //private HashSet<ItemType> itemTypes;
        //private ItemType[] types = { ItemType.KeyItem };
        //public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        //gets the weight of the bag

        //private float _weight;
        /*public float Weight
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
        }*/
        /*
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
        }*/

        private float _weight;
        public float Weight { get { return _weight; } set { _weight = value; } }

        public double _volume;
        public double Volume { get { return _volume; } set { _volume = value; } }

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

        //Designated constructor
        public Bag()
        {
            Name = "bag";
            _container = new Dictionary<string, List<IItem>>();
            _weight = 0;
            _volume = 0;
            _description = "the inventory holds all of the player's items";
            _decorator = null;
            _capacity = 50;
            _volumeCapacity = 10;
            BuyPrice = 0;
            SellPrice = 0;
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
            Container.TryGetValue(item.Name, out check);
            if (check == null)
            {
                Container[item.Name] = new List<IItem>();
                Container[item.Name].Add(item);
            }
            else
            {
                Container[item.Name].Add(item);
            }
        }

        /*
        public IItem RemoveItem(string itemName)
        {
            IItem item = null;
            _container.Remove(itemName, out item);
            return item;
        }*/

        public IItem RemoveItem(string item)
        {
            List<IItem> find = null;
            Container.TryGetValue(item, out find);
            if (find != null)
            {
                IItem temp = find.First();
                Container[item].Remove(temp);
                if (Container[item].Count == 0)
                {
                    Container.Remove(item);
                }
                return temp;
            }
            else
            {
                Console.WriteLine("You don't have this item in your bag");
                return null;
            }
        }



        //Weight of items
        public float WeightInBag()
        {
            float temp = 0;
            Dictionary<string, List<IItem>>.ValueCollection values = Container.Values;
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
        public bool SpaceInBag(IItem item)
        {
            if (this.Weight + item.Weight > _capacity)
            {
                Console.WriteLine("You do not have enough room in your bag.");
                return false;
            }
            return true;
        }

        //Displays items in the bag
        public string ShowInventory()
        {
            string list = "";
            Dictionary<string, List<IItem>>.ValueCollection values = Container.Values;
            list += "\nWeight in Bag: " + WeightInBag();
            foreach (List<IItem> item in values)
            {
                list += item.First().Name;
            }
            return list;
        }

        //Checks if certain item is in bag
        public bool CheckForItem(string item)
        {
            List<IItem> check = null;
            Container.TryGetValue(item, out check);
            return check != null;
        }
    }
}
