namespace Vicol_Lorena_Proiect.Models
{
    public class ProdusData
    {
        public IEnumerable<Produs> Produse { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieProdus> CategorieProduse { get; set; }
    }
}
