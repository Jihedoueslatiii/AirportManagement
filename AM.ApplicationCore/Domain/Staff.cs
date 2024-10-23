using System;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am a Staff Member");
        }

        public DateTime EmployementDate { get; set; }
        public string Function { get; set; }

        // La propriété Salary est considérée comme une valeur monétaire
        [DataType(DataType.Currency, ErrorMessage = "Le salaire doit être une valeur monétaire.")]
        public float Salary { get; set; }

        public override string? ToString()
        {
            return "Function: " + Function;
        }
    }
}
