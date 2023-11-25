namespace AirlineApp.Manager.Interfaces
{
    using AirlineApp.Model;
    public interface IUserManager
    {
        bool Login(string email, string password);
        User Get(string email);
        void GetAll();
    }
}