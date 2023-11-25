namespace AirlineApp.Model
{
    public abstract class BaseEntity
    {
        public int Id{get; set;}
        public bool IsDelete{get; set;}
        public BaseEntity(int id,bool isDelete)
        {
            Id = id;
            IsDelete = isDelete;
        }
    }
}