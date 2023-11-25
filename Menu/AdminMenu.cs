namespace AirlineApp.Menu
{
    public class AdminMenu
    {   
            BookingMenu bookingMenu = new BookingMenu();
            FlightMenu flightMenu = new FlightMenu();
            ProfileMenu profileMenu = new ProfileMenu();
            UserMenu userMenu = new UserMenu();
            ScheduleMenu ScheduleMenu = new ScheduleMenu();
        public void Admin()
        {
            GenMenu.MessageWithColor("1. Manage User\n2. Manage Profiles\n3. Manage Bookings\n4. Manage Flights\n5. Manage Schedule\n6. Exit",ConsoleColor.Yellow);
            Console.Write("Enter your choice: ");
            string choice1 = Console.ReadLine()!;
            switch (choice1)
            {
                case "1":
                    userMenu.User();
                    break;
                case "2":
                    profileMenu.Profile();
                    break;

                case "3":
                    bookingMenu.Booking();
                    break;

                case "4":
                    flightMenu.Flight();
                    break;
                
                case "5":
                    ScheduleMenu.sheduleMenu();
                    break;
                case "6":
                    GenMenu genMenu = new GenMenu();
                    genMenu.Gen();
                    break;

                default:
                    GenMenu.MessageWithColor("Invalid Input",ConsoleColor.Red);
                    break;
            }
            Console.WriteLine();
            GenMenu.Clear();
            Admin();
        }
    }
}