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
        void addDecorator(IItem decorator);
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

        public void addDecorator(IItem decorator)
        {
            if (_decorator == null)
            {
                _decorator = decorator;
            }
            else
            {
                _decorator.addDecorator(decorator);
            }
            Description = "Name: " + Name + ", Weight: " + Weight + ", Volume: " + Volume;
        }
    }
}
