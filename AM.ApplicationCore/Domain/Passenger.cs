using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {

        public DateTime BirthDate { get; set; }
        // public int PassportNumber { get; set; }
        public int PassengerID { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelNumber { get; set; }

        ICollection<Flight> Flights { get; set; }


        public override string? ToString()
        {
            return"FirstName"+FirstName;
        }

Plane plane1 = new Plane(PlaneType.Airbus,150,DateTime.Now);

        public bool CheckProfile(string firstName, string lastName)
        {
            return this.FirstName == firstName && this.LastName == lastName;
        }

        public bool CheckProfile(string firstName, string lastName, string email)
        {
            return this.FirstName == firstName && this.LastName == lastName && this.EmailAddress == email;
        }

        public bool CheckProfile1(string firstName, string lastName, string email)
        {
            if (email == null)
            {
                return this.FirstName == firstName && this.LastName == lastName;
            }
            else
            {
                return this.FirstName == firstName && this.LastName == lastName && this.EmailAddress == email;
            }
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger called Jihed Oueslati");
        }




    }
}
