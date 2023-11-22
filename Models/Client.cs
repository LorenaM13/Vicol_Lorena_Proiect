using System.ComponentModel.DataAnnotations;

namespace Vicol_Lorena_Proiect.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Adresa { get; set; }
        public string Email { get; set; }
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
