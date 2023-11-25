using AirlineApp.Model;

namespace AirlineApp.Interfaces
{
    public interface IProfileManager
    {
        void GetAll();
        void GetProfile(string userEmail);

        void DeleteProfile(string email);

        void UpdateProfile(string phoneNumber, string FirstName, string LastName,string email);
    }
}