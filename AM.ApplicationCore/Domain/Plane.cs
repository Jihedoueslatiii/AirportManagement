using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boing,
        Airbus
    }
    public class Plane
    {
        public int PlaneID { get; set; }

        // Capacity must be a positive integer
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be a positive integer.")]
        public int Capacity { get; set; }
        public DateTime ManifactureDate { get; set; }
        public PlaneType Planetype { get; set; }
        
        ICollection <Flight> flights { get; set; }

        public override string? ToString()
        {
            return "Capacity" +Capacity+ "PlaneType" +Planetype;
        }

        public Plane()
        {
        }

        public Plane(PlaneType planetype, int capacity, DateTime manifactureDate)
        {
           
            Planetype = planetype;
            Capacity = capacity;
            ManifactureDate = manifactureDate;
        }

        public Plane(int capacity, DateTime manifactureDate)
        {
            Capacity = capacity;
            ManifactureDate = manifactureDate;
        }
    }

}
