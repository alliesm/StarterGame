using System;
namespace StarterGame
{
    public class wand : IItem, IWeapon
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

        private int _minumumDamage;
        public int MinimumDamage { get { return _minumumDamage; } set { _minumumDamage = value; } }
        private int _maximummDamage;
        public int MaximumDamage { get { return _maximummDamage; } set { _maximummDamage = value; } }

        private string _description;
        public string Description { get { return "Name: " + Name + ", Weight: " + Weight + ", Volume: " + Volume + ", Buy Price: " + BuyPrice + ", Sell Price: " + SellPrice + ", " + _description; } }

        private IItem _decorator;

        public bool IsContainer { get { return false; } }

        public wand() : this("wand") { }

        public wand(string name) : this(name, 4.0f) { }

        public wand(string name, float weight) : this(name, weight, 3.0) { }

        public wand(string name, float weight, double volume) : this(name, weight, volume, 30) { }

        public wand(string name, float weight, double volume, int buyPrice) : this(name, weight, volume, buyPrice, 50) { }

        public wand(string name, float weight, double volume, int buyPrice, int sellPrice) : this(name, weight, volume, buyPrice, sellPrice, 30) { }

        public wand(string name, float weight, double volume, int buyPrice, int sellPrice, int minimumDamage) : this(name, weight, volume, buyPrice, sellPrice, minimumDamage, 50) { }

        public wand(string name, float weight, double volume, int buyPrice, int sellPrice, int minimumDamage, int maximumDamage) : this(name, weight, volume, buyPrice, sellPrice, minimumDamage, maximumDamage, "a mage's wand, a truly strong item") { }

        //Designated constructor
        public wand(String name, float weight, double volume, int buyPrice, int sellPrice, int minumumDamage, int maximumDamage, string description)
        {
            Name = name;
            Weight = weight;
            Volume = volume;
            _description = description;
            _decorator = null;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            MaximumDamage = maximumDamage;
            MinimumDamage = minumumDamage;
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
