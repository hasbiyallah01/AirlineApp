namespace AirlineApp.Model
{
    public class Profile:BaseEntity
    {
        public string FirstName{get; set;} 
        public string LastName{get; set;} 
        public string PhoneNumber{get; set;} 
        public Gender Gender{get; set;} 
        public string Address{get; set;} 
        public string UserEmail{get; set;}
        public  string ProfileDateTime{get; set; }
        public decimal WalletBalance{get; set; }
        public Profile(int id, bool isDelete,string firstName, string lastName, string phoneNumber, Gender gender, string address, string userEmail): base(id,isDelete) 
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Address = address;
            UserEmail = userEmail;
            WalletBalance = 0;
            ProfileDateTime = DateTime.Now.ToString("F");
        }
    }
}