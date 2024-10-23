using System;
using System.Collections.Generic;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

namespace AM.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the FlightService
            FlightService flightService = new FlightService
            {
                Flights = TestData.listFlights
            };

            // Test GetFlightDatesLINQ method
            var flightDatesToParisLINQ = flightService.GetFlightDatesLINQ("Paris");
            Console.WriteLine("Flight dates to Paris using LINQ:");
            foreach (var date in flightDatesToParisLINQ)
            {
                Console.WriteLine($"- {date}");
            }

            // Test ShowFlightDetails method
            Console.WriteLine("Flight details for Airbus:");
            flightService.ShowFlightDetails(TestData.Airbusplane);

            // Test ProgrammedFlightNumber method
            var numberOfFlights = flightService.ProgrammedFlightNumber(new DateTime(2022, 01, 01));
            Console.WriteLine($"Number of flights programmed from 2022-01-01 for a week: {numberOfFlights}");

            // Test DurationAverage method
            double averageDurationToParis = flightService.DurationAverage("Paris");
            Console.WriteLine($"Average duration of flights to Paris: {averageDurationToParis}");

            // Test OrderedDurationFlights method
            var orderedFlights = flightService.OrderedDurationFlights();
            Console.WriteLine("Flights ordered by duration (longest to shortest):");
            foreach (var flight in orderedFlights)
            {
                Console.WriteLine($"- Destination: {flight.Destination} | Duration: {flight.EstimatedDuration}");
            }

            // Test SeniorTravellers method
            var flightToCheck = TestData.flight1; // You can change this to any flight you want to check
            var seniorTravellers = flightService.SeniorTravellers(flightToCheck);
            Console.WriteLine("Senior travellers on flight:");
            foreach (var traveller in seniorTravellers)
            {
                Console.WriteLine($"- {traveller.Name.FirstName} {traveller.Name.LastName} | Birthdate: {traveller.BirthDate.ToShortDateString()}");
            }

            //// Test DestinationGroupedFlights method
            //Console.WriteLine("Grouped flights by destination:");
            //var groupedFlights = flightService.DestinationGroupedFlights();

            //foreach (var group in groupedFlights)
            //{
            //    Console.WriteLine($"Destination: {group.Key}");
            //    foreach (var flight in group)
            //    {
            //        Console.WriteLine($"  - Flight Date: {flight.FlightDate}");
            //    }
            //}
            foreach (var traveller in seniorTravellers)
            {
                Console.WriteLine($"- {traveller.Name.FirstName} {traveller.Name.LastName} | Birthdate: {traveller.BirthDate.ToShortDateString()}");
            }

        }
    }
}