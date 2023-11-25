namespace AirlineApp.Menu
{
    using AirlineApp.Manager.Implementation;
    using AirlineApp.Model;
    public class GenMenu
    {
        AirlineInfo airlineInfo = new AirlineInfo();
        UserManager userManager = new UserManager();
        PassengerManager passengerManager = new PassengerManager();

        public void Gen()
        {
            while (true)
            {
                MessageWithColor("1. To signup \n2. To Login \n3. Get Airline Information\n4. Exit",ConsoleColor.Yellow);

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                       signUp();
                        break;
                    case "2":
                        Login();
                        break;
                    case "3":
                        airlineInfo.GetAirlineInfo();
                        break;

                    case "4":
                        MessageWithColor("Exiting the program. Goodbye!",ConsoleColor.DarkGreen);
                        Environment.Exit(0);
                        break;
                    default:
                        MessageWithColor("Invalid choice. Please enter a valid option.",ConsoleColor.Red);
                        break;
                }
                Console.WriteLine();
                Clear();
            }
        }

        public void Login()
        {
            Console.Write("Enter email: ");
            string email = Console.ReadLine()!;

            if (IsValidGmail(email))
            {
                Console.Write("Enter password: ");
                string password = Console.ReadLine()!;

                if (userManager.Login(email, password))
                {
                    if (email == "mojjy@gmail.com" && password == "tutu")
                    {
                        AdminMenu adminMenu = new AdminMenu();
                        adminMenu.Admin();
                    }
                    else
                    {
                        User user = UserManager.UserDb.Find(u => u.Email == email);

                        if (user != null)
                        {
                            
                            CuMenu cuMenu = new CuMenu();
                            cuMenu.User();
                        }
                        else
                        {
                            MessageWithColor("An unexpected error occurred. Please try again.",ConsoleColor.Red);
                        }
                    }
                }
                else
                {
                    MessageWithColor("Incorrect email or password. Please try again.",ConsoleColor.Red);
                }
            }
            else
            {
                MessageWithColor("Invalid gmail format",ConsoleColor.Red);
            }
        }



        public void signUp()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine()!;
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine()!;
            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine()!;
            var genderTypeInt = Utility.SelectEnum("Select Gender type:\n1 Male\n2 Female: ", 1, 2);
            var GenderType = (Gender)genderTypeInt;
            Console.Write("Enter address: ");
            string address = Console.ReadLine()!;
            Console.Write("Enter email: ");
            string userEmail = Console.ReadLine()!;
            Console.Write("Enter password: ");
            string password = Console.ReadLine()!;
            if(IsValidGmail(userEmail) == true)
            {
                var newPassenger = passengerManager.Register(firstName, lastName, phoneNumber, GenderType, address, userEmail,password);

                if (newPassenger != null)
                {
                    Console.WriteLine($"Passenger registered successfully with ID: {newPassenger.Id}");
                }
            }
            else
            {
                MessageWithColor("Invalid Gmail",ConsoleColor.Red);
            }
        }

        public static void Clear()
        {
            System.Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void MessageWithColor(string Message, ConsoleColor hue)
        {
            Console.ForegroundColor = hue;
            Console.WriteLine(Message);
            Console.ResetColor();
        }

        private bool IsValidGmail(string email)
        {
            return email.Contains("@gmail.com");
        }

    }
}