using System.Security.Policy;
using Vicol_Lorena_Proiect.Models;

namespace Vicol_Lorena_Proiect.ViewModels
{
    public class EchipaIndexData
    {
        public IEnumerable<Echipa> Echipe { get; set; }
        public IEnumerable<Produs> Produse { get; set; }
        public IEnumerable<ListaAngajati> ListeAngajati { get; set; }
    }
}
