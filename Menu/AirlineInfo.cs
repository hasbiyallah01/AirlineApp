namespace AirlineApp.Menu
{
    using AirlineApp.Model;   
    public class AirlineInfo
    {
        public void GetAirlineInfo()
        {
            Airline airline = new Airline(1, false, "Hasbiy Airline", "HAS","Gbonagun Odoeran,Obantoko,Abeokuta", "08105269544",2023);
            GenMenu.MessageWithColor("Airline Information:",ConsoleColor.DarkGreen);
            GenMenu.MessageWithColor($"Name: {airline.Name}",ConsoleColor.DarkGreen);
            GenMenu.MessageWithColor($"IATA: {airline.IATA}",ConsoleColor.DarkGreen);
            GenMenu.MessageWithColor($"Location: {airline.Location}",ConsoleColor.DarkGreen);
            GenMenu.MessageWithColor($"Contact Info: {airline.ContactInfo}",ConsoleColor.DarkGreen);
            GenMenu.MessageWithColor($"Year Founded: {airline.YearFounded}",ConsoleColor.DarkGreen);
        }
    }
}