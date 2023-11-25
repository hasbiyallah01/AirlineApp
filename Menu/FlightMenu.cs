namespace AirlineApp.Menu
{
    using AirlineApp.Manager.Implementation;
    public class FlightMenu
    {
        FlightManager flightManager = new FlightManager();
        public void Flight()
        {
            while (true)
            {
                Console.WriteLine("1. Get Flight Details");
                Console.WriteLine("2. Get All Flights Details");
                Console.WriteLine("3. Delete Flight Details");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {

                    case "1":
                        GetFlightDetails();
                        break;

                    case "2":
                        flightManager.GetAllFlightsDetails();
                        break;

                    case "3":
                        DeleteFlightDetails();
                        break;

                    case "4":
                        GenMenu.MessageWithColor("Exiting ... Goodbye!",ConsoleColor.DarkGreen);
                        AdminMenu menu = new AdminMenu();
                        menu.Admin();   
                        break;

                    default:
                        GenMenu.MessageWithColor("Invalid choice. Please enter a valid option.",ConsoleColor.Red);
                        break;
                }

                Console.WriteLine();
                GenMenu.Clear();
            }
        }

        
        public void GetFlightDetails()
        {
            Console.Write("Enter user email: ");
            string getFlightEmail = Console.ReadLine()!;
            flightManager.GetFlightDetails(getFlightEmail);
        }

        public void DeleteFlightDetails()
        {
            Console.Write("Enter user email: ");
            string deleteFlightEmail = Console.ReadLine()!;
            flightManager.DeleteFlightDetails(deleteFlightEmail);
            GenMenu.MessageWithColor("Flight deleted successfully.",ConsoleColor.Green);
        }
    }
}