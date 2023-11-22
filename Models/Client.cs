using System.ComponentModel.DataAnnotations;

namespace Vicol_Lorena_Proiect.Models
{
    public class Client
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula!")]
        [StringLength(25, MinimumLength = 3)]
        //[Required]
        public string? Nume { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula!")]
        [StringLength(25, MinimumLength = 3)]
       // [Required]
        public string? Prenume { get; set; }

        public string? Adresa { get; set; }

        public string Email { get; set; }

        [RegularExpression(@"^\(?(0[0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-222-222'!")]
        public string? TelNo { get; set; }

        [Display(Name = "Nume Complet")]
        public string? FullName
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Comanda>? Comenzi { get; set; }
    }
}
