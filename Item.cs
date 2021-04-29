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
        string Description { get; }
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
        private string _description;
        public string Description { get { return "Name: " + Name + ", Weight: " + Weight + ", Volume: " + Volume + " " + _description; } }

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
            _description = description;
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
        private float _weight;
        public float Weight
        {
            get
            {
                float containedweight = 0;
                foreach(IItem item in _container.Values)
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
                foreach(IItem item in _container.Values)
                {
                    itemList += "\n " + item.Description;
                }
                return "Name: " + Name + ", Weight: " + Weight + ", Volume: " + Volume + ", Capacity: " + Capacity + ", " + _description + "\n" + itemList;
            }
        }

        public ItemContainer() : this("container") { }

        public ItemContainer(string name) : this(name, 50f) { }

        public ItemContainer(string name, float weight) : this(name, weight, 45) { }

        public ItemContainer(string name, float weight, double volume) : this(name, weight, volume, 100) { }

        public ItemContainer(string name, float weight, double volume, int capacity) : this(name, weight, volume, capacity, "") { }
        //Designated constructor
        public ItemContainer(string name, float weight, double volume, int capacity, string description)
        {
            _container = new Dictionary<string, IItem>();
            Name = name;
            Weight = weight;
            Volume = volume;
            _description = description;
            _decorator = null;
            _capacity = capacity;
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

        //checks for space in container
        public bool SpaceInContainer(IItem item)
        {
            if (this.Weight + item.Weight > _capacity)
            {
                Console.WriteLine("There isn't enough space");
                return false;
            }
            return true;
        }

        public float weightInContainer()
        {
            float temp = 0;
            Dictionary<string, IItem>.ValueCollection items = _container.Values;
            foreach(IItem item in _container.Values)
            {
                foreach(IItem item1 in items)
                {
                    temp += item.Weight;
                }
            }
            return temp;
        }

        public void AddItem(IItem item)
        {
            _container[item.Name] = item;
        }
        public IItem RemoveItem(string itemName)
        {
            IItem item = null;
            _container.Remove(itemName, out item);
            return item;
        }
        
    }
}
