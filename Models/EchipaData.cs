using Vicol_Lorena_Proiect.Migrations;

namespace Vicol_Lorena_Proiect.Models
{
    public class EchipaData
    {
        public IEnumerable<Echipa> Echipe { get; set; }
        public IEnumerable<Angajat> Angajati { get; set; }
        public IEnumerable<ListaAngajati> ListeAngajati { get; set; }
    }
}
