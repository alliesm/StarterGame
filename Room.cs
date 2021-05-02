using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Room
    {
        private Dictionary<string, Door> exits;
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
            _ground = new ItemContainer("floor loot", 0f, 0, 0, 0, 0, "items currently on the ground around you");
            exits = new Dictionary<string, Door>();
            this.Tag = tag;
        }

        public void SetExit(string exitName, Door door)
        {
            exits[exitName] = door;
        }

        public Door GetExit(string exitName)
        {
            Door door = null;
            exits.TryGetValue(exitName, out door);
            return door;
        }

        public string GetExits()
        {
            string exitNames = "Exits: ";
            Dictionary<string, Door>.KeyCollection keys = exits.Keys;
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
            return "\nYou entered " + this.Tag + ".\n*** " + this.GetExits() + "\n^^^" + GetItems();
        }
    }
}
