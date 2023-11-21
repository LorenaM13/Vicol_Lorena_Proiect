namespace Vicol_Lorena_Proiect.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        public string NumeAngajat { get; set; }
        public ICollection<ListaAngajati>? ListeAngajati { get; set; }
    }
}
