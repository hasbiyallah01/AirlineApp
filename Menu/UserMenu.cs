namespace AirlineApp.Menu
{
    using AirlineApp.Manager.Implementation;
    public class UserMenu
    {
        UserManager userManager = new UserManager();
        public void User()
        {
            while (true)
            {
                GenMenu.MessageWithColor("1. Get User Information\n2. Display All Users\n3. Exit",ConsoleColor.Blue);
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                   case "1":
                        getUserInfo();
                        break;

                    case "2":
                        getAll();
                        break;

                    case "3":
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


        public void getUserInfo()
        {
            Console.Write("Enter email: ");
            string getUserEmail = Console.ReadLine()!;
            var getUser = userManager.Get(getUserEmail);
            if (getUser != null)
            {
                Console.WriteLine($"User Found: {getUser.Id} - {getUser.Email}");
            }
            else
            {
                System.Console.WriteLine("Email doesnt exist");
            }
        }

        public void getAll()
        {
            userManager.GetAll();
        }
    }
}