using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StarterGame
{
    public class ItemContainer : IItem
    {
        private Dictionary<string, IItem> _container;

        public string Name { get; set; }

        private float _capacity;
        public float Capacity { get { return _capacity; } set { _capacity = value; } }
        private int _buyPrice;
        public int BuyPrice { get { return _buyPrice; } set { _buyPrice = value; } }
        private int sellPrice;
        public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }
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
        public double Volume { get { return _volume; } set { _volume = value; } }

        private string _description;
        public string Description
        {
            get
            {
                string itemList = "\nItems: ";
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