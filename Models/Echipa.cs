namespace Vicol_Lorena_Proiect.Models
{
    public class Echipa
    {
        public int ID { get; set; }
        public string EchipaNume { get; set; }
        public ICollection<Produs>? Produse { get; set; }
    }
}
