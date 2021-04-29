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

        private IItem _item;

        public void Drop(IItem item)
        {
            _item = item;
        }

        public IItem Pickup(string itemName)
        {
            if (_item != null)
            {
                if (itemName.Equals(itemName))
                {
                    IItem tempItem = _item;
                    _item = null;
                    return tempItem;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
            
        }

        public Room() : this("No Tag")
        {

        }

        public Room(string tag)
        {
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

        public string GetItem()
        {
            return "Items: " + (_item == null ? "" : _item.Name);
        }

        public string Description()
        {
            return "You are " + this.Tag + ".\n *** " + this.GetExits() + "\n ^^^" + GetItem();
        }
    }
}
