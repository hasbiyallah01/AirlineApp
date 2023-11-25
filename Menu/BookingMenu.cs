namespace AirlineApp.Menu
{
    using AirlineApp.Manager.Implementation;
    public class BookingMenu
    {
        BookingManager bookingManager = new BookingManager();
        public void Booking()
        {

            while (true)
            {
                GenMenu.MessageWithColor("1. Get Booking Information\n2. View All Bookings\n3. Delete Booking\n4. Exit",ConsoleColor.Blue);

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        GetBooking();
                        break;

                    case "2":
                        bookingManager.GetAllBookings();
                        break;

                    case "3":
                        Delete();
                        break;

                    case "4":
                        GenMenu.MessageWithColor("Exiting ...!",ConsoleColor.DarkGreen);
                        AdminMenu menu = new AdminMenu();
                        menu.Admin();
                        break;

                    default:
                        GenMenu.MessageWithColor("Invalid choice",ConsoleColor.Red);
                        break;
                }

                Console.WriteLine();
                GenMenu.Clear();
            }
        }

        public void GetBooking()
        {
            Console.Write("Enter user email: ");
            string getBookingEmail = Console.ReadLine()!;
            bookingManager.GetBookingInfo(getBookingEmail);
        }

        public void Delete()
        {
            Console.Write("Enter user email: ");
            string deleteBookingEmail = Console.ReadLine()!;
            bookingManager.DeleteBooking(deleteBookingEmail);
            GenMenu.MessageWithColor("Booking deleted successfully.",ConsoleColor.Green);
        }
    }
}