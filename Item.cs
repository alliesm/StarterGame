using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public interface IItem
    {
        string Name { get; set; }
        float Weight { get; set; }
        double Volume { get; set; }
        string Description { get; set; }
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
        public string Description { get; set; }

        private IItem _decorator;

        public bool IsContainer { get { return false; } }

        public Item() : this("nameless") { }

        public Item(string name) : this(name, 1.0f) { }

        public Item(string name, float weight) : this(name, weight, 2.0) { }

        public Item(string name, float weight, double volume) : this(name, weight, volume, "") { }
        //Designated constructor
        public Item(String name, float weight, double volume, string description)
        {
            Name = name;
            Weight = weight;
            Volume = volume;
            Description = "Name: " + Name + ", Weight: " + Weight + ", Volume: " + Volume + " " + description;
            _decorator = null;
        }

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
            Description = "Name: " + Name + ", Weight: " + Weight + ", Volume: " + Volume;
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
        public string Description { get; set; }

        public ItemContainer() : this("container") { }

        public ItemContainer(string name) : this(name, 50f) { }

        public ItemContainer(string name, float weight) : this(name, weight, 45) { }

        public ItemContainer(string name, float weight, double volume) : this(name, weight, volume, "") { }
        //Designated constructor
        public ItemContainer(String name, float weight, double volume, string description)
        {
            Name = name;
            Weight = weight;
            Volume = volume;
            Description = "Name: " + Name + ", Weight: " + Weight + ", Volume: " + Volume + " " + description;
            _decorator = null;
            _container = new Dictionary<string, IItem>();
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
            Description = "Name: " + Name + ", Weight: " + Weight + ", Volume: " + Volume;
        }

        public bool IsContainer { get { return true; } }

        public void AddItem(IItem item)
        {
            _container[item.Name] = item;
        }
        public IItem RemoveItem(string itemName)
        {
            return null;
        }
        
    }
}
