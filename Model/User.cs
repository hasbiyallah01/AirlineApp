namespace AirlineApp.Model
{
    public class User : BaseEntity
    {
        public string Password{get; set;}
        public string Email{get; set;}
        public string Role{get; set;}
        public User(int id,bool isDelete,string password,string email,string role):base(id,isDelete)
        {
            Email = email;
            Password = password;
            Role = role;
        }
    }
}