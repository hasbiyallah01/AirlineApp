namespace AirlineApp.Model
{
    public class Booking : BaseEntity
    {
        public string Email{get; set; }
        public decimal TicketPrice { get; set; }
        public bool PaymentStatus {get; set; }
        public  string BookingDateTime{get; set; }
    

        public Booking(int id, bool isDelete,string email,bool paymentStatus,string bookingDateTime) : base(id, isDelete)
        {
            Email = email;
            TicketPrice = 30000;
            PaymentStatus = paymentStatus;
            BookingDateTime = bookingDateTime;
        }

    }
}