namespace AirlineApp.Interfaces
{
    using AirlineApp.Model;
    public interface IBookingManager
    {
        public bool MakeBooking(int id, bool isDelete,string email,bool paymentStatus);
        public void GetAllBookings();
        public void GetBookingInfo(string email);
        public void DeleteBooking(string userEmail); 
    }
}