namespace AirlineApp.Interfaces
{
    using AirlineApp.Model;
    public interface IFlightManager
    {
        void SpecifyFlightDetails(string userEmail,string departureCity, string destinationCity,string destinationCountry);
        void GetAllFlightsDetails();
        void GetFlightDetails(string userEmail);
        void DeleteFlightDetails(string userEmail);
    }
}