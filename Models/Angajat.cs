using System.ComponentModel.DataAnnotations;

namespace Vicol_Lorena_Proiect.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        public string NumeAngajat { get; set; }

        [Display(Name = "NumarContact")]
        public string TelNo { get; set; }
        public string Adresa { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataAngajarii { get; set; }

        public ICollection<ListaAngajati>? ListeAngajati { get; set; }
    }
}
