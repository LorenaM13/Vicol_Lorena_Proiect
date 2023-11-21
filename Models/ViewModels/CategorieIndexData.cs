using Vicol_Lorena_Proiect.Models;

namespace Vicol_Lorena_Proiect.ViewModels
{
    public class CategorieIndexData
    {
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<Produs> Produse { get; set; }
        public IEnumerable<CategorieProdus> CategorieProduse { get; set; }
    }
}
