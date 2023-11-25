namespace AirlineApp.Menu
{
    using AirlineApp.Manager.Implementation;
    public class ScheduleMenu
    {
        ScheduleManager scheduleManager = new ScheduleManager();

        public void sheduleMenu()
        {

            while (true)
            {
                Console.WriteLine("===== Flight Schedule Management =====");
                Console.WriteLine("1. View All Schedules");
                Console.WriteLine("2. View Schedule Details");
                Console.WriteLine("3. Delete Schedule");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllSchedules();
                        break;
                    case "2":
                        ViewScheduleDetails();
                        break;
                    case "3":
                        DeleteSchedule();
                        break;
                    case "4":
                        GenMenu.MessageWithColor("Exiting ... Goodbye!",ConsoleColor.DarkGreen);
                        AdminMenu menu = new AdminMenu();
                        menu.Admin();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                Console.WriteLine();
                GenMenu.Clear();
            }
        }

        void ViewAllSchedules()
        {
            scheduleManager.GetAllSchedulesDetails();
        }

        void ViewScheduleDetails()
        {
            Console.Write("Enter user email: ");
            string userEmail = Console.ReadLine();

            scheduleManager.GetScheduleDetails(userEmail);
        }

        void DeleteSchedule()
        {
            Console.Write("Enter user email: ");
            string userEmail = Console.ReadLine();

            scheduleManager.DeleteScheduleDetails(userEmail);
            Console.WriteLine("Schedule deleted successfully!");
        }
    }

}
