namespace AirlineApp.Menu
{
    using AirlineApp.Manager.Implementation;
    public class CuMenu
    {
        BookingManager bookingManager = new BookingManager();
        FlightManager flightManager = new FlightManager();
        ScheduleManager scheduleManager = new ScheduleManager();
        public void User()
        {
            while (true)
            {
                Console.WriteLine("1. Make Booking \n2. Specify Flight Details\n3. Schedule a Flight\n4. To Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        MakeBooking();
                        break;

                    case "2":
                        CreateFlightDetails();
                        break;
                    case "3":
                        ScheduleFlight();
                    break;
                    case "4":
                        GenMenu.MessageWithColor("Exiting ... Wishing to see you net time!",ConsoleColor.DarkGreen);
                        GenMenu menu = new GenMenu();
                        menu.Gen();
                        break;
                    
                    default:
                        GenMenu.MessageWithColor("Invalid choice. ",ConsoleColor.Red);
                        break;
                }
                Console.WriteLine();
                GenMenu.Clear();
            }
        }

        public void CreateFlightDetails()
        {
            Console.Write("Enter user email: ");
            string userEmail = Console.ReadLine()!;
            Console.Write("Enter departure city: ");
            string departureCity = Console.ReadLine()!;
            Console.Write("Enter destination city: ");
            string destinationCity = Console.ReadLine()!;
            Console.Write("Enter destination country: ");
            string destinationCountry = Console.ReadLine()!;

            flightManager.SpecifyFlightDetails(userEmail, departureCity, destinationCity, destinationCountry);
        }

        public void MakeBooking()
        {
            Console.Write("Enter user email: ");
            string userEmail = Console.ReadLine()!;
            bool paymentStatus = false;
            bookingManager.MakeBooking(BookingManager.BookingDb.Count + 1, false, userEmail, paymentStatus);
        }

        void ScheduleFlight()
        {
            Console.Write("Enter user email: ");
            string userEmail = Console.ReadLine();
            scheduleManager.Schedule(1, false, userEmail);
            
            Console.WriteLine("Flight scheduled successfully!");
        }
    }
}