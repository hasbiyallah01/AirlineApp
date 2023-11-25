namespace AirlineApp.Menu
{
    using AirlineApp.Manager.Implementation;
    public class ProfileMenu
    {
        ProfileManager profileManager = new ProfileManager();
        public void Profile()
        {

            while (true)
            {
                GenMenu.MessageWithColor("1. Display All Profiles\n2. Get Profile Information\n3. Update Profile\n4. Delete Profile\n5. Exit",ConsoleColor.Blue);
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        profileManager.GetAll();
                        break;

                    case "2":
                        getUserInfo();
                        break;

                    case "3":
                        Update();
                        break;

                    case "4":
                        Delete();
                        break;

                    case "5":
                        GenMenu.MessageWithColor("Existing ... Goodbye!",ConsoleColor.DarkGreen);
                        AdminMenu menu = new AdminMenu();
                        menu.Admin();
                        break;

                    default:
                        GenMenu.MessageWithColor("Invalid choice. Please enter a valid option.",ConsoleColor.Red);
                        Profile();
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
            profileManager.GetProfile(getUserEmail);
        }

        public void getAll()
        {
            profileManager.GetAll();
        }

        public void Update()
        {
            Console.Write("Enter email: ");
            string updateEmail = Console.ReadLine()!;
            Console.Write("Enter new first name: ");
            string newFirstName = Console.ReadLine()!;
            Console.Write("Enter new last name: ");
            string newLastName = Console.ReadLine()!;
            Console.Write("Enter new email: ");
            string newEmail = Console.ReadLine()!;
            Console.Write("Enter new phone number: ");
            string newPhoneNumber = Console.ReadLine()!;
            profileManager.UpdateProfile(newPhoneNumber, newFirstName, newLastName, newEmail);
        }

        public void Delete()
        {
            Console.Write("Enter email: ");
            string deleteEmail = Console.ReadLine()!;
            profileManager.DeleteProfile(deleteEmail);
            GenMenu.MessageWithColor("Profile deleted successfully.",ConsoleColor.Green);
        }
    }
}