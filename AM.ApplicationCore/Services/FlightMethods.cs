using System;
using System.Collections.Generic;
using System.Linq;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services
{
    public class FlightService
    {
        // Assume Flights is a property of type List<Flight>
        public List<Flight> Flights { get; set; }

        // Method 6: GetFlightDates using For Loop
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();

            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                {
                    flightDates.Add(Flights[i].FlightDate);
                }
            }

            return flightDates;
        }

        // Method 7: GetFlightDates using foreach Loop
        public List<DateTime> GetFlightDatesUsingForeach(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();

            foreach (var flight in Flights)
            {
                if (flight.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                {
                    flightDates.Add(flight.FlightDate);
                }
            }

            return flightDates;
        }

        // Method 8: GetFlights
        public void GetFlights(string filterType, string filterValue)
        {
            List<Flight> filteredFlights = new List<Flight>();

            switch (filterType.ToLower())
            {
                case "destination":
                    filteredFlights = Flights.Where(f => f.Destination.Equals(filterValue, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                case "flightdate":
                    if (DateTime.TryParse(filterValue, out DateTime flightDate))
                    {
                        filteredFlights = Flights.Where(f => f.FlightDate.Date == flightDate.Date).ToList();
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format.");
                        return;
                    }
                    break;
                case "estimatedduration":
                    if (int.TryParse(filterValue, out int duration))
                    {
                        filteredFlights = Flights.Where(f => f.EstimatedDuration == duration).ToList();
                    }
                    else
                    {
                        Console.WriteLine("Invalid duration format.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid filter type.");
                    return;
            }

            // Display filtered flights
            if (filteredFlights.Count > 0)
            {
                Console.WriteLine($"Flights filtered by {filterType}: {filterValue}");
                foreach (var flight in filteredFlights)
                {
                    Console.WriteLine($"- {flight.FlightDate} | Destination: {flight.Destination} | Estimated Duration: {flight.EstimatedDuration}");
                }
            }
            else
            {
                Console.WriteLine("No flights found with the given criteria.");
            }
        }
        public List<DateTime> GetFlightDatesLINQ(string destination)
        {
            var flightDates = Flights
                .Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                .Select(f => f.FlightDate)
                .ToList();

            return flightDates;
        }

        // Method 10: ShowFlightDetails
        public void ShowFlightDetails(Plane plane)
        {
            var flightDetails = Flights
                .Where(f => f.Plane.Equals(plane))
                .Select(f => new { f.FlightDate, f.Destination });

            foreach (var detail in flightDetails)
            {
                Console.WriteLine($"Date: {detail.FlightDate}, Destination: {detail.Destination}");
            }
        }

        // Method 11: ProgrammedFlightNumber
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            return Flights.Count(f => f.FlightDate.Date >= startDate.Date && f.FlightDate.Date < startDate.AddDays(7).Date);
        }

        // Method 12: DurationAverage
        public double DurationAverage(string destination)
        {
            var averageDuration = Flights
                .Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                .Average(f => f.EstimatedDuration);

            return averageDuration;
        }

        // Method 13: OrderedDurationFlights
        public List<Flight> OrderedDurationFlights()
        {
            return Flights
                .OrderByDescending(f => f.EstimatedDuration)
                .ToList();
        }

        // Method 14: SeniorTravellers
        public List<Traveller> SeniorTravellers(Flight flight)
        {
            return flight.Passengers
                .OfType<Traveller>()
                .OrderByDescending(t => t.BirthDate)
                .Take(3)
                .ToList();
        }

        // Method 15: DestinationGroupedFlights
        public void DestinationGroupedFlights()
        {
            var groupedFlights = Flights
                .GroupBy(f => f.Destination)
                .Select(g => new
                {
                    Destination = g.Key,
                    Flights = g.Select(f => f.FlightDate)
                });

            foreach (var group in groupedFlights)
            {
                Console.WriteLine($"Destination: {group.Destination}");
                foreach (var flightDate in group.Flights)
                {
                    Console.WriteLine($"Départ : {flightDate:dd/MM/yyyy HH:mm:ss}");
                }
            }
        }
        }
}
