using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StarterGame
{
    public class Player : ILivingCreature
    {
        private Room _currentRoom = null;
        private IItem _inventory = null;
        
        
        

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
        private Bag _bag;
        public Bag Bag { get { return _bag; } set { _bag = value; } }

        private int gold;
        public int Gold { get { return gold; } set { gold = value; } }

        private int _currentHitPoints;
        public int CurrentHitPoints { get { return _currentHitPoints; } set { _currentHitPoints = value; } }

        private int _maximumHitPoints;
        public int MaximumHitPoints { get { return _maximumHitPoints; } set { _maximumHitPoints = value; } }

        public Player(Room room)
        {
            _currentRoom = room;
            _inventory = new ItemContainer("inventory", 0f, 0, 50, 0, 0, "your inventory is where all of your held items is stored");
            
        }

        

        //Allows the player to move into another room
        public void WaltTo(string direction)
        {
            Door door = this.CurrentRoom.GetExit(direction);
            
            if (door != null)
            {
                if (door.IsOpen)
                {
                    Room nextRoom = door.ConnectedRoom(CurrentRoom);
                    this._currentRoom = nextRoom;
                    this.OutputMessage("\n" + this._currentRoom.Description());
                }
                else
                {
                    OutputMessage("\nThe " + direction + " is locked");
                }
            }
            else
            {
                this.OutputMessage("\nThere is no door to the " + direction);
            }
        }

        public void Open(string direction)
        {
            Door door = this.CurrentRoom.GetExit(direction);

            if (door != null)
            {
                if (door.IsOpen)
                {
                    OutputMessage("\nThe " + direction + " is already opened");
                }
                else
                {
                    door.open();
                    OutputMessage("\nThe door " + direction + " is now opened");
                }
            }
            else
            {
                this.OutputMessage("\nThere is no door to the " + direction);
            }

        }

        public void Give(IItem item)
        {
            _inventory.AddItem(item);
        }

        public void Explore()
        {
            this.OutputMessage("\n" + this._currentRoom.Description());
        }

        
        public IItem Take(string itemName)
        {
            IItem item = _inventory.RemoveItem(itemName);
            return item;
        }

        //takes item out of inventory
        public void Drop(string itemName)
        {
            IItem item = Take(itemName);
            if (item != null)
            {
                CurrentRoom.Drop(item);
                OutputMessage("\n" + itemName + " has been dropped");
            }
            else
            {
                OutputMessage("\nThe item named " + itemName + " is not in your inventory.");
            }
        }

        //adds item to inventory
        public void PickUp(string itemName)
        {
            IItem item = CurrentRoom.Pickup(itemName);
            if (item != null)
            {
                /*if ((item.Weight + Bag.weightInContainer()) >= Bag.Capacity)
                {
                    OutputMessage("Your inventory is full");
                    CurrentRoom.Drop(item);
                }
                else
                {*/
                    Give(item);
                    OutputMessage("\n" + itemName + " has been picked up");
                //}
            }
            else
            {
                OutputMessage("\nThe item named " + itemName + " is not in the room.");
            }
        }

        /*public float weightInInventory()
        {
            float temp = 0;
            Dictionary<string, IItem>.ValueCollection values = _inventory;
            foreach (List<IItem> items in values)
            {
                foreach (IItem item in items)
                {
                    temp += item.Weight;
                }
            }
            return temp;
        }*/

        public void Inspect(string itemName)
        {
            IItem item = CurrentRoom.Pickup(itemName);
            if (item != null)
            {
                OutputMessage("\nCurrent item:  " + item.Description);
                CurrentRoom.Drop(item);
            }
            else
            {
                OutputMessage("\nThe item '" + itemName + "' is not in the room.");
            }
        }


        public void Inventory()
        {
            OutputMessage(_inventory.Description);
        }

        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
