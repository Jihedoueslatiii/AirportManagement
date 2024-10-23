using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        // Propriété PassportNumber comme clé primaire avec 7 caractères
        [Key]
        [StringLength(7, ErrorMessage = "Le numéro de passeport doit comporter exactement 7 caractères.")]
        public string PassportNumber { get; set; }

        // Propriété FullName
        public FullName Name { get; set; } = new FullName();

        // Propriété BirthDate affichée en tant que "Date of Birth"
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "La date de naissance doit être une date valide.")]
        public DateTime BirthDate { get; set; }

        // Validation de l'adresse e-mail
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide.")]
        public string EmailAddress { get; set; }

        // Validation du numéro de téléphone avec une longueur de 8 chiffres
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Le numéro de téléphone doit comporter exactement 8 chiffres.")]
        public string TelNumber { get; set; }

        // Propriété de navigation pour les vols (many-to-many)
        public ICollection<Flight> Flights { get; set; }

      


        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger called Jihed Oueslati");
        }
    }
}
