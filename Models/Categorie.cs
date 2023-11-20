namespace Vicol_Lorena_Proiect.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<CategorieProdus>? CategorieProduse { get; set; }
    }
}
