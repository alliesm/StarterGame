using System;
namespace StarterGame
{
    public class axe : IItem, IWeapon
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

        public axe() : this("axe") { }

        public axe(string name) : this(name, 8.0f) { }

        public axe(string name, float weight) : this(name, weight, 9.0) { }

        public axe(string name, float weight, double volume) : this(name, weight, volume, 15) { }

        public axe(string name, float weight, double volume, int buyPrice) : this(name, weight, volume, buyPrice, 30) { }

        public axe(string name, float weight, double volume, int buyPrice, int sellPrice) : this(name, weight, volume, buyPrice, sellPrice, 15) { }

        public axe(string name, float weight, double volume, int buyPrice, int sellPrice, int minimumDamage) : this(name, weight, volume, buyPrice, sellPrice, minimumDamage, 30) { }

        public axe(string name, float weight, double volume, int buyPrice, int sellPrice, int minimumDamage, int maximumDamage) : this(name, weight, volume, buyPrice, sellPrice, minimumDamage, maximumDamage, "a strong axe") { }

        //Designated constructor
        public axe(String name, float weight, double volume, int buyPrice, int sellPrice, int minumumDamage, int maximumDamage, string description)
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
