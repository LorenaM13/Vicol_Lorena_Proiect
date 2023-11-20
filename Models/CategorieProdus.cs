namespace Vicol_Lorena_Proiect.Models
{
    public class CategorieProdus
    {
        public int ID { get; set; }
        public int ProdusID { get; set; }
        public Produs Produs { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
