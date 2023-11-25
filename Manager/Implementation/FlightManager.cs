namespace AirlineApp.Manager.Implementation
{
    using System.Collections.Generic;
    using ConsoleTables;
    using Humanizer;
    using AirlineApp.Interfaces;
    using AirlineApp.Model;

    public class FlightManager : BookingManager,IFlightManager
    {

        public static List<Flight>FlightDb = new List<Flight>();
        public void DeleteFlightDetails(string userEmail)
        {
            var flight = FindFlight(userEmail);

            if (flight is null)
            {
                Console.WriteLine("Unable to delete flight as it does not exist!");
            }

            flight.IsDelete = true;
        }

        public void GetAllFlightsDetails()
        {
            if (FlightDb.Count == 0)
            {
                Console.WriteLine("There is no flight made yet");
            }
            System.Console.WriteLine("flight Details: ");
            var table = new ConsoleTable("Id","Email","SeatNumber","FlightNumber","DepartureCity","DestinationCity","DestinationCountry","AircraftEngineNum","Flight Reg Time");
            foreach (Flight flight in FlightDb)
            {
                if(flight.IsDelete == false)
                {
                    table.AddRow(flight.Id,flight.UserEmail,flight.SeatNumber,flight.DepartureCity,flight.DestinationCity,flight.DestinationCountry.Humanize(), flight.DepartureTime);
                }
            }
            table.Write(Format.Alternative);
        }

        public void GetFlightDetails(string userEmail)
        {
            var flight = FindFlight(userEmail);
            if (flight != null && flight.IsDelete == false)
            {
                Printflight(flight);
            }
            else
            {
                Console.WriteLine($"Contact with {userEmail} not found");
            }
        }

        public void SpecifyFlightDetails(string userEmail, string departureCity, string destinationCity, string destinationCountry)
        {
            try{
                Flight flight = new Flight(FlightDb.Count+1,false,userEmail,FlightDb.Count+1,departureCity,destinationCity,destinationCountry);
                Booking booking = BookingDb.Find(c => c.Email == userEmail)!;
                if(booking.PaymentStatus == true)
                {
                    if(booking.Email == userEmail)
                    {
                        FlightDb.Add(flight);
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong credentials ");
                    }
                    Printflight(flight);
                }
            }
            catch{
                System.Console.WriteLine("Kindly make your payment");
            }
        }

        private Flight FindFlight(string email)
        {
            return FlightDb.Find(c => c.UserEmail == email);
        }
        private void Printflight(Flight flight)
        {
            Console.WriteLine($"Id: {flight!.Id}\nEmail: {flight!.UserEmail}\nSeat Number: {flight.SeatNumber}\nDepature City: {flight.DepartureCity}\nDestination City: {flight.DestinationCity}\nDestination Country: {flight.DestinationCountry}\nFlight RegTime: {flight.DepartureTime}");
        }
    
    }
}