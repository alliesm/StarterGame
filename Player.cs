using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StarterGame
{
    public class Player : LivingCreature
    {
        private Room _currentRoom = null;

        //private IItem _inventory = null;

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

        private int _money;
        public int Money { get { return _money; } set { _money = value; } }

        private int _currentHitPoints;
        public int CurrentHitPoints { get { return _currentHitPoints; } set { _currentHitPoints = value; } }

        private int _maximumHitPoints;
        public int MaximumHitPoints { get { return _maximumHitPoints; } set { _maximumHitPoints = value; } }

        public Player(Room room)
        {
            _currentRoom = room;
            _bag = null;
            _money = 10;
            //_inventory = new ItemContainer("inventory", 0f, 0, 50, 0, 0, "your inventory is where all of your held items is stored");
        }

        //displays a message to the player
        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
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

                    Notification notification = new Notification("FoundBag", this);
                    NotificationCenter.Instance.PostNotification(notification);
                    notification = new Notification("PlayerEnteredInfirmary", this);
                    NotificationCenter.Instance.PostNotification(notification);
                    this.OutputMessage("\n" + this._currentRoom.Description());
                }
                else
                {
                    OutputMessage("\nI need to find the key");
                }
            }
            else
            {
                this.OutputMessage("\nThere is no door to the " + direction);
            }
        }

        //opens a locked door
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

        //places item in backpack
        public void Give(IItem item)
        {
            Bag.AddItem(item);
            Bag.Weight = Bag.Weight + item.Weight;
        }
        //takes item from backpack
        public IItem Take(string itemName)
        {
            IItem item = Bag.RemoveItem(itemName);
            return item;
        }

        //displays current room description
        public void Explore()
        {
            this.OutputMessage("\n" + this._currentRoom.Description());
        }

              

        //takes item out of inventory
        /*public void Drop(string itemName)
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
        }*/

        //adds item to inventory
        public void PickUp(string itemName)
        {
            IItem item = CurrentRoom.Pickup(itemName);
            if (item != null)
            {
                //checks if the items weight is over the bag capacity
                if ((item.Weight + Bag.WeightInBag()) >= Bag.Capacity)
                {
                    OutputMessage("This is to heavy to pick up");
                    CurrentRoom.Drop(item);
                }
                else
                {
                    //checks if the item is too large to be picked up
                    if(item.Volume > Bag.VolumeCapacity)
                    {
                        OutputMessage("This item is to big to carry");
                        CurrentRoom.Drop(item);
                    }
                    else
                    {
                        Give(item);
                        OutputMessage("\n" + itemName + " has been picked up");
                    }
                }
            }
            else
            {
                CurrentRoom.Drop(item);
                OutputMessage("\nThe item named " + itemName + " is not in the room.");
            }
        }

        //inspects an item and displays its properties
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

        /*public void Inventory()
        {
            OutputMessage(_bag.Description);
        }*/

        //checks if the player has enough money to buy an item
        public bool EnoughMoney(float cost)
        {
            if(Money > cost)
            {
                OutputMessage("\nThis costs to much");
                return false;
            }
            return true;
        }

        //happens when a player buys an item
        public void BuyItem(int amount)
        {
            Money -= amount;
        }
        //happens when a player sells an item
        public void GetMoney(int amount)
        {
            Money += amount;
        }
    }
}
