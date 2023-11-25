namespace AirlineApp.Manager.Implementation
{
    using AirlineApp.Model;

    using Manager.Interfaces;
    public class PassengerManager : IPassengerManager
    {
        public static List<Passenger> PassengerDb = new List<Passenger>();
        public Passenger Register(string firstName, string lastName, string phoneNumber, Gender gender, string address, string userEmail,string password)
        {
            var exists = Exists(userEmail);
            if(exists)
            {
                Console.WriteLine($"Contact with {userEmail} already exist");
                return null;
            }

            Profile profile = new Profile(ProfileManager.ProfileDb.Count+1,false,firstName,lastName,phoneNumber,gender,address,userEmail);
            ProfileManager.ProfileDb.Add(profile);
            
            User user = new User(UserManager.UserDb.Count+1,false,password,userEmail,"Customer");
            UserManager.UserDb.Add(user);


            Passenger passenger= new Passenger(PassengerDb.Count+1,false,userEmail,DateTime.Now);
            PassengerDb.Add(passenger);

            return passenger;
        }
        public bool Exists(string email)
        {
            return PassengerDb.Any(c => c.UserEmail == email);
        }

    }
}