using AirlineApp.Manager.Interfaces;
using AirlineApp.Model;
using System.Collections.Generic;
using ConsoleTables;
using Humanizer;
using AirlineApp.Interfaces;
namespace AirlineApp.Manager.Implementation
{
    public class ScheduleManager : FlightManager,IScheduleManager
    {
        public static List<FlightSchedule>ScheduleDb = new List<FlightSchedule>();
        private static int ScheduleCounter = 1;
        private static int engineCounter = 1;
        private int maxCapacity = 200;
        public void Schedule(int id, bool isDelete, string userEmail)
        {
            try
            {
                Flight flight = FlightDb.Find(c => c.UserEmail == userEmail)!;
                if(flight.UserEmail == userEmail)
                {
                    if (BookingDb.Count < maxCapacity)
                    {
                        FlightSchedule flightSchedule = new FlightSchedule(ScheduleDb.Count+1,false,userEmail,DateTime.Now.AddDays(2).ToString("F"),DateTime.Now.ToString("F"),GenerateEngineNumber(),GenerateScheduleNumber());
                        PrintSchedule(flightSchedule);
                    }
                    else
                    {
                        Console.WriteLine("Schedule at max capacity. Generating new Schedule and engine numbers.");
                        GenerateNewNumbers();
                        Schedule(id,isDelete,userEmail);
                    }
                }
            }
            catch
            {
                System.Console.WriteLine("You havent given the flight detail");
            }
        }


        public void GetAllSchedulesDetails()
        {
            if (ScheduleDb.Count == 0)
            {
                Console.WriteLine("There is no Schedule made yet");
            }
            System.Console.WriteLine("Schedule Details: ");
            var table = new ConsoleTable("Id","Email","FlightNumber","AircraftEngineNum","Scheduled DayAndTime","Schedule Booking DateAndTime");
            foreach (var schedule in ScheduleDb)
            {
                if(schedule.IsDelete == false)
                {
                    table.AddRow(schedule.Id,schedule.UserEmail,schedule.FlightNumber,schedule.AircraftEngineNum,schedule.ScheduleDay,schedule.ScheduleTime.Humanize());
                }
            }
            table.Write(Format.Alternative);
        }


        private FlightSchedule FindSchedule(string email)        {
            return ScheduleDb.Find(c => c.UserEmail == email);
        }
        private void PrintSchedule(FlightSchedule Schedule)
        {
            Console.WriteLine($"Id: {Schedule!.Id}\nEmail: {Schedule!.UserEmail}\nAircraft EngineNum: {Schedule.AircraftEngineNum}\nFlight Number: {Schedule.FlightNumber}\nScheduled DateAndTime: {Schedule.ScheduleDay}\nSchedule Booking DateAndTime: {Schedule.ScheduleTime}");
        }

        public void GetScheduleDetails(string userEmail)
        {
            var Schedule = FindSchedule(userEmail);
            if (Schedule != null && Schedule.IsDelete == false)
            {
                PrintSchedule(Schedule);
            }
            else
            {
                Console.WriteLine($"Contact with {userEmail} not found");
            }
        }

        public void DeleteScheduleDetails(string userEmail)
        {
            var Schedule = FindSchedule(userEmail);

            if (Schedule is null)
            {
                Console.WriteLine("Unable to delete Schedule as it does not exist!");
            }

            Schedule.IsDelete = true;
        }

        private void GenerateNewNumbers()
        {
            string ScheduleNumber = GenerateScheduleNumber();
            string AircraftEngineNum = GenerateEngineNumber();

            Console.WriteLine($"New Schedule Number: {ScheduleNumber}");
            Console.WriteLine($"New Engine Number: {AircraftEngineNum}");
        }


        private string GenerateScheduleNumber()
        {
            return $"{"HAS"}{ScheduleCounter++}";
        }

        private string GenerateEngineNumber()
        {
            return $"{"HAS"}-E{engineCounter++}";
        }

    }
}