namespace AirlineApp.Manager.Implementation
{
    using ConsoleTables;
    using Humanizer;
    using System.Collections.Generic;
    using AirlineApp.Interfaces;
    using AirlineApp.Model;
    public class ProfileManager : IProfileManager
    {
        public static List<Profile> ProfileDb = new List<Profile>();
        public void GetAll()
        {

            if (ProfileDb.Count == 0)
            {
                Console.WriteLine("There is no profile added yet.");
            }
            System.Console.WriteLine("Profile Details: ");
            var table = new ConsoleTable("Id", "FirstName", "LastName", "Phone Number", "Email", "Gender", "Date Created");
            foreach (Profile profile in ProfileDb)
            {
                {
                    table.AddRow(profile.Id, profile.FirstName, profile.LastName, profile.PhoneNumber, profile.UserEmail, profile.Gender.Humanize(), profile.ProfileDateTime);
                }
            }
            table.Write(Format.Alternative);
        }

        public void GetProfile(string userEmail)
        {
            var profile = FindProfile(userEmail);
            if (profile != null && profile.IsDelete == false)
            {
                PrintProfile(profile);
            }
            Console.WriteLine($"Contact with {userEmail} not found");
        }

        public void UpdateProfile(string phoneNumber, string FirstName, string LastName, string email)
        {
            var profile = FindProfile(phoneNumber);

            if (profile is null)
            {
                Console.WriteLine("Profile does not exist!");
                return;
            }

            profile.FirstName = FirstName;
            profile.LastName = LastName;
            profile.UserEmail = email;
            Console.WriteLine("Profile updated successfully.");
        }

        public void DeleteProfile(string email)
        {
            var profile = FindProfile(email);

            if (profile is null)
            {
                Console.WriteLine("Unable to delete contact as it does not exist!");
                return;
            }
            profile.IsDelete = true;
        }

        public Profile FindProfile(string email)
        {
            return ProfileDb.Find(c => c.UserEmail == email);
        }

        private void PrintProfile(Profile profile)
        {
            Console.WriteLine($"Name: {profile!.FirstName}{profile!.LastName}\nPhone Number: {profile!.PhoneNumber}\nEmail: {profile!.UserEmail}");
        }
    }
}