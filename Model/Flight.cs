namespace AirlineApp.Model
{
    public class Flight:BaseEntity
    {    
        public string UserEmail{get; set;}  
        public string DepartureCity { get; set; } 
        public string DestinationCity { get; set; } 
        public  string DepartureTime { get; set; }
        // public List<Passenger> Passengers { get; set; }
        public string DestinationCountry { get; set; }
        public int SeatNumber{get; set;}
        public Flight(int id, bool IsDelete,string userEmail,int seatNumber, string departureCity, string destinationCity,string destinationCountry) : base(id,IsDelete)
        {
            UserEmail = userEmail;
            SeatNumber = seatNumber;
            DepartureCity = departureCity;
            DestinationCity = destinationCity;
            DepartureTime = DateTime.Now.ToString("F");
            DestinationCountry = destinationCountry;
        }

    }
}