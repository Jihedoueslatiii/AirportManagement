using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightID { get; set; }

        public string Destination { get; set; }

        public string Departure { get; set; }

        public DateTime FlightDate { get; set; }

        public DateTime EffectiveArrival { get; set; }

        public int EstimatedDuration { get; set; }

        // Foreign key to Plane
        [ForeignKey("Plane")]
        public int PlaneId { get; set; }

        // Navigation property
        public Plane Plane { get; set; }

        public ICollection<Passenger> Passengers { get; set; }

        public override string? ToString()
        {
            return "Destination: " + Destination;
        }
    }
}
