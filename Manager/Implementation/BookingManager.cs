namespace AirlineApp.Manager.Implementation
{
    using System.Collections.Generic;

    using AirlineApp.Interfaces;
    using AirlineApp.Model;
    using ConsoleTables;
    using Humanizer;
    public class BookingManager : ProfileManager,IBookingManager
    {
        public static List<Booking> BookingDb = new List<Booking>();
        public void DeleteBooking(string userEmail)
        {
            var booking = FindBooking(userEmail);

            if (booking is null)
            {
                Console.WriteLine("Unable to delete booking as it does not exist!");
                return;
            }

            booking.IsDelete = true;
        }

        public void GetAllBookings()
        {
            if (BookingDb.Count == 0)
            {
                Console.WriteLine("There is no booking made yet");
            }
            System.Console.WriteLine("Profile Details: ");
            var table = new ConsoleTable("Id", "PaymentStatus","TicketPrice","Email","Date Created");
            foreach (Booking profile in BookingDb)
            {
                if(profile.IsDelete == false)
                {
                    table.AddRow(profile.Id, profile.PaymentStatus,profile.TicketPrice,profile.Email.Humanize(), profile.BookingDateTime);
                }
            }
            table.Write(Format.Alternative);
        }

        public void GetBookingInfo(string email)
        {
            var booking = FindBooking(email);
            if(booking.IsDelete == false && booking != null)
            {
                PrintBooking(booking);
            }
            Console.WriteLine($"Contact with {email} not found");
        }

        public bool MakeBooking(int id, bool isDelete,string email,bool paymentStatus)
        {
            Booking booking = new Booking(BookingDb.Count+1,false,email,true,DateTime.Now.ToString("F"));
            Profile profile = ProfileDb.Find(c => c.UserEmail == email)!;
            if(profile.UserEmail == email)
            {
                if(profile.WalletBalance >= booking.TicketPrice)
                {
                    profile.WalletBalance -= booking.TicketPrice;
                    BookingDb.Add(booking);
                    PrintBooking(booking);
                    System.Console.WriteLine($"Your Wallet Balance is : {profile.WalletBalance}");
                    return true;
                }
                Console.WriteLine("Not enough balance for booking.");
                System.Console.WriteLine("Enter the amount you want to add to your to your account");
                decimal topup = decimal.Parse(Console.ReadLine()!);
                TopUpWallet(email,topup);
                MakeBooking(id,isDelete,email,paymentStatus);
                return true;
            }
            else
            {
                System.Console.WriteLine("Wrong credentials ");
                return false;
            }
        }
        private  Booking FindBooking(string email)
        {
            return BookingDb.Find(c => c.Email == email);
        }
        private bool TopUpWallet(string email, decimal amount)
        {
            Profile profile = ProfileDb.Find(c => c.UserEmail == email)!;

            if (profile != null && amount >= 30000)
            {
                profile.WalletBalance += amount;
                return true;
            }
            System.Console.WriteLine("Your profile does not exist or you have entered an Invalid amount Please enter a valid decimal value.");
            return false;
        }

        private void PrintBooking(Booking booking)
        {
            Console.WriteLine($"Id: {booking!.Id}\nEmail: {booking!.Email}\nPaymentStatus: {booking.PaymentStatus}\nBookingPrice: {booking.TicketPrice}");
        }

    }
}