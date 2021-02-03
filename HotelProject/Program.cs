using System;
using System.Collections.Generic;

namespace Program5
{
    class Program
    {
        public static readonly Hotel hotel = new Hotel();
        static void Main(string[] args)
        {
            string option;

            do
            {
                ReservationMenu();
                option = Console.ReadLine();

                switch (option)
                {
                    // Make a reservation.
                    case "1":
                        // Check if hotel's capacity is full.
                        if (hotel.CheckFullCapacity() == true)
                        {
                            Console.WriteLine("\nThere are no rooms available. You must cancel a reservation in order to make a new one.\n");
                            break;
                        }
                        // Register reservation.
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("\nRESERVATION\n");
                                Console.Write("Name: ");
                                string name = Console.ReadLine();
                                while (string.IsNullOrWhiteSpace(name) == true)
                                {
                                    Console.WriteLine("Error: Can't be null, empty or white spaces.");
                                    Console.Write("\nName: ");
                                    name = Console.ReadLine();
                                }

                                Console.Write("Email: ");
                                string email = Console.ReadLine();
                                while (string.IsNullOrWhiteSpace(email) == true)
                                {
                                    Console.WriteLine("Error: Can't be null, empty or white spaces.");
                                    Console.Write("\nEmail: ");
                                    email = Console.ReadLine();
                                }
                                while (Reservation.IsValidEmail(email) == false)
                                {
                                    Console.WriteLine("Error: E-mail not valid.");
                                    Console.Write("\nEmail: ");
                                    email = Console.ReadLine();
                                }

                                PrintAvailableRooms();
                                Console.Write("Room: ");
                                string room = Console.ReadLine();
                                while (string.IsNullOrWhiteSpace(room) == true)
                                {
                                    Console.WriteLine("Error: Can't be null, empty or white spaces.");
                                    Console.Write("\nRoom: ");
                                    room = Console.ReadLine();
                                }
                                while (hotel.RoomExists(room) == false)
                                {
                                    Console.WriteLine("Error: Room number doesn't exist.");
                                    Console.Write("\nRoom: ");
                                    room = Console.ReadLine();
                                }
                                while (hotel.IsAvailable(room) == false)
                                {
                                    Console.WriteLine("Error: Room is not available.");
                                    Console.Write("\nRoom: ");
                                    room = Console.ReadLine();
                                }
                                // Tries to add reservation to the reservation list.
                                hotel.AddReservation(new Reservation(name, email, room));
                                Console.WriteLine("Reservation successful!!!");
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine("\nError: " + e.Message);
                                continue;
                            }
                            catch (InvalidOperationException e)
                            {
                                Console.WriteLine("\nError: " + e.Message);
                            }
                            break;
                        }
                        Console.WriteLine();
                        break;

                    // Cancel a reservation.
                    case "2":
                        while (true)
                        {
                            Console.WriteLine("\nCANCEL RESERVATION");
                            // Checks if all rooms are available.
                            try
                            {
                                PrintReservations();
                                Console.Write("\nRoom number: ");
                                string roomNumber = Console.ReadLine();
                                hotel.CancelReservation(roomNumber);
                                Console.WriteLine("\nReservation canceled successfuly!!!");
                            }
                            catch (InvalidOperationException e)
                            {
                                Console.WriteLine("\nError: " + e.Message + "\n");
                                break;
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine("\nError: " + e.Message + "\n");
                                continue;
                            }
                            Console.WriteLine();
                            break;
                        }
                        break;

                    // Cancel all reservations.
                    case "3":
                        Console.WriteLine("\nCANCEL ALL RESERVATIONS\n");
                        Console.Write("Are you sure you want to cancel all reservations [Y/n]? ");
                        string answer = Console.ReadLine();

                        if (ValidYnAnswer(answer) == true)
                        {
                            try
                            {
                                hotel.CancelAllReservations();
                                Console.WriteLine("\nAll reservations were canceled successfuly\n");
                            }
                            catch (InvalidOperationException e)
                            {
                                Console.WriteLine("\nError: " + e.Message + "\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nError: Request not completed.\n");
                        }
                        break;

                    // Prints all reservations on the console.
                    case "4":
                        Console.WriteLine("\nRESERVATION LIST");
                        try
                        {
                            PrintReservations();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine("\nError: " + e.Message);
                        }
                        Console.WriteLine();
                        break;

                    // Exit program.
                    case "5":
                        Console.WriteLine("\nFinishing...");
                        break;

                    default:
                        Console.WriteLine("\nError: Option not valid.\n");
                        break;
                }
            }
            while (option != "5");
        }

        /// <summary>
        /// Prints available rooms on the console.
        /// </summary>
        private static void PrintAvailableRooms()
        {
            if (hotel.CheckFullCapacity() == true)
            {
                throw new InvalidOperationException("There are no rooms available.");
            }
            Console.WriteLine("Available rooms:");
            foreach (var availableRoom in hotel.AvailableRooms())
            {
                Console.WriteLine(availableRoom);
            }
        }

        /// <summary>
        /// Prints reservations on the console.
        /// </summary>
        private static void PrintReservations()
        {

            if (hotel.CheckEmptyCapacity() == true)
            {
                throw new InvalidOperationException("There are no reservations.");
            }
            else
            {
                foreach (KeyValuePair<string, Reservation> reservation in hotel.ReservationList())
                {
                    Console.WriteLine(reservation.Value);
                }
            }
        }

        /// <summary>
        /// Prints the program's menu.
        /// </summary>
        private static void ReservationMenu()
        {
            Console.WriteLine("*** RESERVATION MENU ***");
            Console.WriteLine();
            Console.WriteLine("1 - Make a reservation.");
            Console.WriteLine("2 - Cancel a reservation.");
            Console.WriteLine("3 - Cancel all reservations.");
            Console.WriteLine("4 - Show all reservations.");
            Console.WriteLine("5 - Exit.");
            Console.Write("Option: ");
        }

        /// <summary>
        /// Valids answer.
        /// </summary>
        /// <param name="answer"></param>
        /// <returns>True if answer is valid, otherwise false.</returns>
        private static bool ValidYnAnswer(string answer)
        {
            if (answer == "y" || answer == "Y" || answer == "")
            {
                return true;
            }
            else if (answer != "n")
            {
                return false;
            }
            return false;
        }
    }
}

