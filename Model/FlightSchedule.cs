namespace AirlineApp.Model
{
    public class FlightSchedule:BaseEntity
    {
        public string UserEmail{get; set;}
        public string ScheduleDay { get; set; } 
        public string ScheduleTime { get; set; } 
        public string AircraftEngineNum { get; set; }
        public string FlightNumber { get; set; } 

        public FlightSchedule(int id,bool isDelete,string userEmail, string scheduleDay, string scheduleTime,string aircraftEngineNum,string flightNumber) :base(id,isDelete)
        {
            UserEmail = userEmail;
            ScheduleDay = scheduleDay;
            ScheduleTime = scheduleTime;
            AircraftEngineNum = aircraftEngineNum;
            FlightNumber = flightNumber;
        }    
    }
}