using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public interface IItem
    {
        string Name { get; set; }
        float Weight { get; }
        double Volume { get; }
        int BuyPrice { get; set; }
        int SellPrice { get; set; }
        string Description { get; }
        //HashSet<ItemType> ItemTypes { get; }
        void AddDecorator(IItem decorator);
        bool IsContainer { get; }
        void AddItem(IItem item);
        IItem RemoveItem(string itemName);
    }



    public class Item : IItem
    {
        public string Name { get; set; }
        private float _weight;
        public float Weight
        {
            get
            {
                return _weight + (_decorator != null ? _decorator.Weight : 0);
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
        private int _buyPrice;
        public int BuyPrice
        {
            get
            {
                return _buyPrice + (_decorator != null ? _decorator.BuyPrice : 0);
            }
            set
            {
                _buyPrice = value;
            }
        }
        private int _sellPrice;
        public int SellPrice
        {
            get
            {
                return _sellPrice + (_decorator != null ? _decorator.SellPrice : 0);
            }
            set
            {
                _sellPrice = value;
            }
        }
        private string _description;
        public string Description { get { return "Name: " + Name + ", Weight: " + Weight + ", Volume: " + Volume + ", Buy Price: " + BuyPrice + ", Sell Price: " + SellPrice + ", " + _description; } }

        private IItem _decorator;

        public bool IsContainer { get { return false; } }

        public Item() : this("nameless") { }

        public Item(string name) : this(name, 1.0f) { }

        public Item(string name, float weight) : this(name, weight, 2.0) { }

        public Item(string name, float weight, double volume) : this(name, weight, volume, 10) { }

        public Item(string name, float weight, double volume, int buyPrice) : this(name, weight, volume, buyPrice, 20) { }

        public Item(string name, float weight, double volume, int buyPrice, int sellPrice) : this(name, weight, volume, buyPrice, sellPrice, "") { }

        //Designated constructor
        public Item(String name, float weight, double volume, int buyPrice, int sellPrice, string description)
        {
            Name = name;
            Weight = weight;
            Volume = volume;
            _description = description;
            _decorator = null;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
        }

        //adds decorator to item (combines items)
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

        public void AddItem(IItem item)
        {

        }

        public IItem RemoveItem(string itemName)
        {
            return null;
        }
    }




    public class ItemContainer : IItem
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

        public ItemContainer() : this("container") { }

        public ItemContainer(string name) : this(name, 50f) { }

        public ItemContainer(string name, float weight) : this(name, weight, 45) { }

        public ItemContainer(string name, float weight, double volume) : this(name, weight, volume, 100) { }

        public ItemContainer(string name, float weight, double volume, int capacity) : this(name, weight, volume, capacity, 0) { }


        public ItemContainer(string name, float weight, double volume, int capacity, int buyPrice) : this(name, weight, volume, capacity, buyPrice, 0) { }


        public ItemContainer(string name, float weight, double volume, int capacity, int buyPrice, int sellPrice) : this(name, weight, volume, capacity, buyPrice, sellPrice, "") { }
        //Designated constructor
        public ItemContainer(string name, float weight, double volume, int capacity, int buyPrice, int sellPrice, string description)
        {
            _container = new Dictionary<string, IItem>();
            Name = name;
            Weight = weight;
            Volume = volume;
            _description = description;
            _decorator = null;
            _capacity = capacity;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
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

        //adds item to container
        public void AddItem(IItem item)
        {
            _container[item.Name] = item;
        }
        //removes item from container
        public IItem RemoveItem(string itemName)
        {
            IItem item = null;
            _container.Remove(itemName, out item);
            return item;
        }

    }
}
