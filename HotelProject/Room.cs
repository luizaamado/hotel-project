using System;
using System.Collections.Generic;
using System.Text;

namespace Program5
{
    /// <summary>
    /// Represents a hotel room.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="roomNumber"></param>
        public Room(string roomNumber)
        {
            RoomNumber = roomNumber;
        }

        /// <summary>
        /// Room number.
        /// </summary>
        public string RoomNumber { get; }

        /// <summary>
        /// Prints the object on the console.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.RoomNumber;
        }
    }
}
