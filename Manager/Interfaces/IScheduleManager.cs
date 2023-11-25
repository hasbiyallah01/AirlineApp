namespace AirlineApp.Manager.Interfaces
{
    public interface IScheduleManager
    {
        void Schedule(int id,bool isDelete,string userEmail);
    }
}