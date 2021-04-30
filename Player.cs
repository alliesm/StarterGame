using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Player
    {
        private Room _currentRoom = null;
        private Bag _bag;
        public Bag Bag { get { return _bag; } set { _bag = value; } }


        public Room CurrentRoom
        {
            get
            {
                return _currentRoom;
            }
            set
            {
                _currentRoom = value;
            }
        }

        public Player(Room room)
        {
            _currentRoom = room;            
        }

        public void WaltTo(string direction)
        {
            Room nextRoom = this._currentRoom.GetExit(direction);
            if (nextRoom != null)
            {
                this._currentRoom = nextRoom;
                this.OutputMessage("\n" + this._currentRoom.Description());
            }
            else
            {
                this.OutputMessage("\nThere is no door on " + direction);
            }
        }

        //puts items in inventory
        public void Give(IItem item)
        {
            _bag.AddItem(item);
        }

        //takes item out inventory
        public IItem Take(string itemName)
        {
            IItem item = _bag.RemoveItem(itemName);
            return item;
        }



        public void Drop(string itemName)
        {
            IItem item = Take(itemName);
            if (item != null)
            {
                CurrentRoom.Drop(item);
                OutputMessage(itemName + " has been dropped");
            }
            else
            {
                OutputMessage("\nThe item named " + itemName + " is not in your inventory.");
            }
        }

        public void PickUp(string itemName)
        {
            IItem item = CurrentRoom.Pickup(itemName);
            if (item != null)
            {
                //check for item weight
                if ((Bag.weightInContainer() + item.Weight) >= Bag.Capacity)
                {
                    OutputMessage("Your inventory is full");
                    CurrentRoom.Drop(item);
                }
                else
                {
                    Give(item);
                    OutputMessage(itemName + " has been picked up");
                }
            }
            else
            {
                OutputMessage("\nThe item named " + itemName + " is not in the room.");
            }
        }

        public void Inspect(string itemName)
        {
            IItem item = CurrentRoom.Pickup(itemName);
            if (item != null)
            {
                OutputMessage("Current item:  " + item.Description);
                CurrentRoom.Drop(item);
            }
            else
            {
                OutputMessage("The item '" + itemName + "' is not in the room.");
            }
        }

        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

}
