namespace Vicol_Lorena_Proiect.Models
{
    public class ListaAngajati
    {
        public int ID { get; set; }
        public int EchipaID { get; set; }
        public Echipa Echipa { get; set; }
        public int AngajatID { get; set; }
        public Angajat Angajat { get; set; }
    }
}
