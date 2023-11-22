using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vicol_Lorena_Proiect.Models
{
    public class Produs
    {
        public int ID { get; set; }

        [Display(Name = "Denumire")]
        public string Nume { get; set; }
        public string Ingrediente { get; set; }
        public string Alergeni { get; set; }
        public string Cantitate { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        public int? EchipaID { get; set; }
        public Echipa? Echipa { get; set; }

        public ICollection<CategorieProdus>? CategorieProduse { get; set; }

        public Comanda? Comanda { get; set; }
    }
}
