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
}
