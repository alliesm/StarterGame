using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Room
    {
        private Dictionary<string, Room> exits;
        private string _tag;
        public string Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }

        private IItem _ground;

        public void Drop(IItem item)
        {
            _ground.AddItem(item);
        }

        public IItem Pickup(string itemName)
        {
            IItem item = _ground.RemoveItem(itemName);
            return item;
        }

        public Room() : this("No Tag")
        {

        }

        public Room(string tag)
        {
            _ground = new ItemContainer("ground", 0f, 0, 0, 0, 0, "items currently on the ground around you");
            exits = new Dictionary<string, Room>();
            this.Tag = tag;
        }

        public void SetExit(string exitName, Room room)
        {
            exits[exitName] = room;
        }

        public Room GetExit(string exitName)
        {
            Room room = null;
            exits.TryGetValue(exitName, out room);
            return room;
        }

        public string GetExits()
        {
            string exitNames = "Exits: ";
            Dictionary<string, Room>.KeyCollection keys = exits.Keys;
            foreach (string exitName in keys)
            {
                exitNames += " " + exitName;
            }

            return exitNames;
        }

        public string GetItems()
        {
            return _ground.Description;
        }

        public string Description()
        {
            return "You are " + this.Tag + ".\n *** " + this.GetExits() + "\n ^^^" + GetItems();
        }
    }
}
