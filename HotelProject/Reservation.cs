using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Program5
{
    /// <summary>
    /// Class that defines the reservation informations such as name and e-mail of the guest and the room rented.
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Property name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Property email.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Property room.
        /// </summary>
        public string Room { get; }

        /// <summary>
        /// Class constructor. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="room"></param>
        public Reservation(string name, string email, string room)
        {
            //if (string.IsNullOrWhiteSpace(name))
            //{
            //    throw new ArgumentException("Can't be null, empty or white spaces.", nameof(name));
            //}
            //if (string.IsNullOrWhiteSpace(email))
            //{
            //    throw new ArgumentException("Can't be null, empty or white spaces.", nameof(email));
            //}
            //if (IsValidEmail(email) == false)
            //{
            //    throw new ArgumentException("Invalid e-mail address.", nameof(email));
            //}
            this.Name = name;
            this.Email = email;
            this.Room = room;
        }

        /// <summary>
        /// Checks null or white spaces.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Throw new ArgumentException if there is null or white spaces, otherwise false.</returns>
        public static bool CheckNameOrEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Can't be null, empty or white spaces.", nameof(value));
            }
            return false;
        }

        /// <summary>
        /// Valids e-mail address.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>True if e-mail is valid, otherwise false.</returns>
        public static bool IsValidEmail(string email)
        {
            bool validEmail = false;
            int indexAt = email.IndexOf('@');
            // Ensures the index of the at symbol is not 0.
            if (indexAt > 0)
            {
                int indexDot = email.IndexOf('.', indexAt);
                // Ensures there are at least 1 character between the at and the dot symbol.
                if (indexDot - 1 > indexAt)
                {
                    // Esnsures the dot symbol is not the last character.
                    if (indexDot + 1 < email.Length)
                    {
                        //Ensures the character that comes right after the dot symbol is not a dot.
                        string indexDot2 = email.Substring(indexDot + 1, 1);
                        if (indexDot2 != ".")
                        {
                            validEmail = true;
                        }
                    }
                }
            }
            return validEmail;
        }


        /// <summary>
        /// Prints the object on the console.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Room " + this.Room + ": " + this.Name + ", "
                + this.Email;
        }
    }
}
