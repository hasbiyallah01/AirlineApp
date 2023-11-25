using AirlineApp.Model;

namespace AirlineApp.Manager.Interfaces
{
    public interface IPassengerManager
    {
        Passenger Register(string firstName, string lastName, string phoneNumber, Gender gender, string address, string userEmail,string password);
    }
}