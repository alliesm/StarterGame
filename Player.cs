using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Player
    {
        private Room _currentRoom = null;
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

        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

}
