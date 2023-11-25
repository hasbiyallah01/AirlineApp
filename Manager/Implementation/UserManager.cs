namespace AirlineApp.Manager.Implementation
{
    using System.Collections.Generic;
    using AirlineApp.Model;
    using ConsoleTables;
    using Humanizer;
    using Manager.Interfaces;
    public class UserManager : PassengerManager,IUserManager
    {
        public static List<User> UserDb = new List<User>();
        public User Get(string email)
        {
            var user = FindUser(email);
            if(user.IsDelete == false && user != null )
            {
                System.Console.WriteLine($"Customer with ID:{user.Id}\tEmail:{user.Email}\tPassword:{user.Password}");
            }
            else{
                Console.WriteLine($"Customer with {email} not found");
            }
            return null;
        }

        public void GetAll()
        {
            if (UserDb.Count == 0)
            {
                Console.WriteLine("There is no passenger added yet.");
            }
            System.Console.WriteLine("passenger Details: ");
            var table = new ConsoleTable("Id", "Email", "Password", "Role");
            foreach (User passenger in UserDb)
            {
                if(passenger.IsDelete == false)
                {
                    table.AddRow(passenger.Id, passenger.Email,passenger.Password, passenger.Role.Humanize());
                }
            }
            table.Write(Format.Alternative);
        }

        public bool Login(string email, string password)
        {
           
           if (email == "mojjy@gmail.com" && password == "tutu")
            {
                System.Console.WriteLine("Welcome back superadmin.");
                return true;
            }

            User user = UserManager.UserDb.Find(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                if (user.Role == "Admin")
                {
                    System.Console.WriteLine("Welcome back admin.");
                    return true;
                }
                else
                {
                    System.Console.WriteLine("Welcome back customer.");
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public  User FindUser(string email)
        {
            return UserDb.Find(c => c.Email == email)!;
        }

        public bool RegisterSuperAdmin()
        {
            string superAdminEmail = "mojjy@gmail.com";
            string superAdminPassword = "tutu";
            
            if (UserManager.UserDb.Any(user => user.Email == superAdminEmail))
            {
                System.Console.WriteLine("Email already exists.");
                return false;
            }

            User superAdmin = new User(UserManager.UserDb.Count + 1, false, superAdminPassword, superAdminEmail, "Admin");
            UserManager.UserDb.Add(superAdmin);
            return true;
        }

        public string Role(string email, string password)
        {
            if (email == "mojjy@gmail.com" && password == "tutu")
            {
                return "Admin"; 
            }
            else
            {
                return "Customer";
            }
        }
    }
}
