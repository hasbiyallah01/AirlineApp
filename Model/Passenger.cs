namespace AirlineApp.Model
{
    public class Passenger:BaseEntity
    {
        public string UserEmail{get; set;}
        //public SeatClass SeatClass { get; set; } 
        //public decimal TicketPrice { get; set; } 
        public DateTime BookingDateTime { get; set; }
        //public bool IsCheckedIn { get; set; } 
 

        public Passenger(int id,bool IsDelete,string userEmail, DateTime bookingDateTime) : base(id,IsDelete)
        {
            UserEmail = userEmail;
            //SeatClass = seatClass;
            //TicketPrice = ticketPrice;
            BookingDateTime = bookingDateTime;
            //IsCheckedIn = isCheckedIn;
        }
    }
}