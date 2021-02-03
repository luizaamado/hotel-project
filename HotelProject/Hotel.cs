using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program5
{
    /// <summary>
    /// Class that manages reservations.
    /// </summary>
    public class Hotel
    {
        // Dictionary of reservations.
        private readonly IDictionary<string, Reservation> reservationDictionary = new Dictionary<string, Reservation>();

        // Dictionary of rooms.
        private readonly IDictionary<string, Room> roomDictionary = CreateRoomDictionary();

        /// <summary>
        /// Class empty constructor.
        /// </summary>
        public Hotel()
        {
        }

        /// <summary>
        /// Add reservations to the reservation list.
        /// </summary>
        public void AddReservation(Reservation reservation)
        {
            // 1 - Valid name.
            if (string.IsNullOrWhiteSpace(reservation.Name))
            {
                throw new ArgumentException("Can't be null, empty or white spaces.", nameof(reservation.Name));
            }
            // 2 - Valid e-mail.
            if (string.IsNullOrWhiteSpace(reservation.Email))
            {
                throw new ArgumentException("Can't be null, empty or white spaces.", nameof(reservation.Email));
            }
            if (Reservation.IsValidEmail(reservation.Email) == false)
            {
                throw new ArgumentException("Invalid e-mail address.");
            }
            // 3 - Valid if room exists and is available.
            if (this.RoomExists(reservation.Room) == false)
            {
                throw new ArgumentException("This room doesn't exist.");
            }
            if (this.IsAvailable(reservation.Room) == false)
            {
                throw new ArgumentException("This room is not available.");
            }
            // 4 - Check if reservation list is full. 
            else if (this.CheckFullCapacity() == true)
            {
                throw new ArgumentException("There are no rooms available.");
            }
            // 5 - Add reservation to the list. 
            else
            {
                this.reservationDictionary.Add(reservation.Room.ToString(), reservation);
            }
        }

        /// <summary>
        /// Returns the available rooms.
        /// </summary>
        public List<string> AvailableRooms()
        {
            List<string> availableRooms = new List<string>();
            foreach (var key in this.roomDictionary.Keys)
            {
                if (this.reservationDictionary.ContainsKey(key) == false)
                {
                    availableRooms.Add(key);
                }
            }
            return availableRooms;
        }

        /// <summary>
        /// Clears reservation list.
        /// </summary>
        public void CancelAllReservations()
        {
            // 1 - Check if exists at least one reservation.
            if (CheckEmptyCapacity() == true)
            {
                throw new InvalidOperationException("There are no reservations to cancel.");
            }
            this.reservationDictionary.Clear();
        }

        /// <summary>
        /// Removes reservation from the reservation list.
        /// </summary>
        public void CancelReservation(string room)
        {
            // 1 - Check if room exists.
            if (this.RoomExists(room) == false)
            {
                throw new ArgumentException("Room number doesn't exist.");
            }
            // 2 - If exists, tries to cancel.
            else if (this.reservationDictionary.Remove(room) == false)
            {
                // 3 - If it's not available, throw new exception.
                throw new ArgumentException("Room is already available.");
            }
        }

        /// <summary>
        /// Checks if hotel's capacity is full.
        /// </summary>
        /// <returns>Return true if capacity is full, otherwise false.</returns>
        public bool CheckFullCapacity()
        {
            if (this.reservationDictionary.Count == this.roomDictionary.Count)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if there are no reservations on the reservation list.
        /// </summary>
        /// <returns>True if there are no reservations, otherwise false.</returns>
        public bool CheckEmptyCapacity()
        {
            if (this.reservationDictionary.Count == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Dictionary of room numbers.
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, Room> CreateRoomDictionary()
        {
            return new Dictionary<string, Room>
            {
                { "101", new Room("101") },
                { "102", new Room("102") },
                { "103", new Room("103") },
                { "104", new Room("104") }
            };
        }

        /// <summary>
        /// Checks if the room is available.
        /// </summary>
        /// <returns>True if the room exists and is available, otherwise false.</returns>
        public bool IsAvailable(string room)
        {
            if (this.reservationDictionary.ContainsKey(room) == true)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns the reservations on the list.
        /// </summary>
        public IDictionary<string, Reservation> ReservationList()
        {
            return reservationDictionary;

        }

        /// <summary>
        /// Checks if the room exists.
        /// </summary>
        /// <returns>True if the room exists, otherwise false.</returns>
        public bool RoomExists(string room)
        {
            if (this.roomDictionary.ContainsKey(room))
            {
                return true;
            }
            return false;
        }
    }
}

