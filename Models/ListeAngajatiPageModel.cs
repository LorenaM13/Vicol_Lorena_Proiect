using Microsoft.AspNetCore.Mvc.RazorPages;
using Vicol_Lorena_Proiect.Data;
using Vicol_Lorena_Proiect.Migrations;

namespace Vicol_Lorena_Proiect.Models
{
    public class ListeAngajatiPageModel : PageModel
    {
        public List<AssignedAngajatData> AssignedAngajatDataList;
        public void PopulateAssignedAngajatData(Vicol_Lorena_ProiectContext context,
        Echipa echipa)
        {
            var allAngajati = context.Angajat;
            var echipaAngajati = new HashSet<int>(
            echipa.ListeAngajati.Select(c => c.AngajatID));
            AssignedAngajatDataList = new List<AssignedAngajatData>();
            foreach (var cat in allAngajati)
            {
                AssignedAngajatDataList.Add(new AssignedAngajatData
                {
                    AngajatID = cat.ID,
                    Nume = cat.NumeAngajat,
                    Assigned = echipaAngajati.Contains(cat.ID)
                });
            }
        }
        public void UpdateListeAngajati(Vicol_Lorena_ProiectContext context,
        string[] selectedAngajati, Echipa echipaToUpdate)
        {
            if (selectedAngajati == null)
            {
                echipaToUpdate.ListeAngajati = new List<ListaAngajati>();
                return;
            }
            var selectedAngajatiHS = new HashSet<string>(selectedAngajati);
            var echipaAngajati = new HashSet<int>
            (echipaToUpdate.ListeAngajati.Select(c => c.Angajat.ID));
            foreach (var cat in context.Angajat)
            {
                if (selectedAngajatiHS.Contains(cat.ID.ToString()))
                {
                    if (!echipaAngajati.Contains(cat.ID))
                    {
                        echipaToUpdate.ListeAngajati.Add(
                        new ListaAngajati
                        {
                            EchipaID = echipaToUpdate.ID,
                            AngajatID = cat.ID
                        });
                    }
                }
                else
                {
                    if (echipaAngajati.Contains(cat.ID))
                    {
                        ListaAngajati courseToRemove
                        = echipaToUpdate
                        .ListeAngajati
                        .SingleOrDefault(i => i.AngajatID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
