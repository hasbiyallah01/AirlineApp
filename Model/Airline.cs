namespace AirlineApp.Model
{
    public class Airline : BaseEntity
    {
        public string Name { get;private set; } 
        public string IATA { get;private set; }
        public string Location { get;private set; } 
        public string ContactInfo { get;private set; }
        public int YearFounded { get; set; }
        public Airline(int id,bool isDelete,string name, string iATA, string location, string contactInfo,int yearfounded) : base(id,isDelete)
        {
            Name = name;
            IATA = iATA;
            Location = location;
            ContactInfo = contactInfo;
            YearFounded = yearfounded;
        }
    }
}