using System.ComponentModel.DataAnnotations;

namespace Vicol_Lorena_Proiect.Models
{
    public class Angajat
    {
        public int ID { get; set; }

        public string? NumeAngajat { get; set; }

        /* public string? Prenume { get; set; }

 /*
         [Display(Name = "Nume Complet")]
         public string? NumeAngajat
         {
             get
             {
                 return Nume + " " + Prenume;
             }
         }*/

        [Display(Name = "NumarContact")]
        [RegularExpression(@"^\(?(0[0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-222-222'!")]
        public string TelNo { get; set; }
        public string Adresa { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataAngajarii { get; set; }

        public ICollection<ListaAngajati>? ListeAngajati { get; set; }
    }
}
