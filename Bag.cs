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
                return "Name: " + Name + ", Weight: " + Weight + ", Volume: " + Volume + ", Capacity: " + Capacity + ", " + _description + "\n" + itemList;
            }
        }

        public Bag() : this("bag") { }

        public Bag(string name) : this(name, 0f) { }

        public Bag(string name, float weight) : this(name, weight, 0) { }

        public Bag(string name, float weight, double volume) : this(name, weight, volume, 50) { }

        public Bag(string name, float weight, double volume, int capacity) : this(name, weight, volume, capacity, "your inventory") { }
        //Designated constructor
        public Bag(string name, float weight, double volume, int capacity, string description)
        {
            _container = new Dictionary<string, List<IItem>>();
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

        public float weightInContainer()
        {
            float temp = 0;
            Dictionary<string, List<IItem>>.ValueCollection values = _container.Values;
            foreach (List<IItem> items in _container.Values)
            {
                foreach (IItem item in items)
                {
                    temp += item.Weight;
                }
            }
            return temp;
        }

        public void AddItem(IItem item)
        {
            //_container[item.Name] = item;
            List<IItem> check = null;
            Container.TryGetValue(item.Name, out check);
            if (check == null)
            {
                Container[item.Name] = new List<IItem>();
                Container[item.Name].Add(item);
            }
        }
        public IItem RemoveItem(string itemName)
        {
            List<IItem> check = null;
            Container.TryGetValue(itemName, out check);
            if (check != null && check.Count != 0)
            {
                IItem temp = check.First();
                Container[itemName].Remove(temp);
                if (Container[itemName].Count == 0)
                {
                    Container.Remove(itemName);
                }
                return temp;
            }
            else
            {
                Console.WriteLine("This item isn't here");
                return null;
            }

        }

        public string Inventory()
        {
            //OutputMessage(_bag.Description);
            string list = "";
            Dictionary<string, List<IItem>>.ValueCollection values = Container.Values;
            list += "Inventory Weight: " + weightInContainer();
            foreach(IItem item in values)
            {
                list += item.Name;
            }
            return list;
        }
    }
}