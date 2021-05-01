using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Door
    {
        private Room _roomA;
        private Room _roomB;
        private bool _closed;
        public bool IsClosed
        {
            get
            {
                return _closed;
            }
        }

        public bool IsOpen
        {
            get
            {
                return !_closed;
            }
        }

        public Door(Room roomA, Room roomB)
        {
            _roomA = roomA;
            _roomB = roomB;
            _closed = false;
        }



        public Room ConnectedRoom(Room from)
        {
            if (from == _roomA)
            {
                return _roomB;
            }
            else
            {
                return _roomA;
            }
        }

        public void close()
        {
            _closed = true;
        }

        public void open()
        {
            _closed = false;
        }

        public static Door CreateDoor(Room room1, Room room2, String label1, String label2)
        {
            //outside.SetExit("east", mainCorridor);
            //mainCorridor.SetExit("west", outside);

            Door door = new Door(room1, room2);
            room2.SetExit(label1, door);
            room1.SetExit(label2, door);
            return door;

        }
    }
}
