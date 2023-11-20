using Microsoft.AspNetCore.Mvc.RazorPages;
using Vicol_Lorena_Proiect.Data;
using Vicol_Lorena_Proiect.Migrations;

namespace Vicol_Lorena_Proiect.Models
{
    public class CategorieProdusePageModel: PageModel
    {
        public List<AssignedCategorieData> AssignedCategorieDataList;
        public void PopulateAssignedCategorieData(Vicol_Lorena_ProiectContext context,
        Produs produs)
        {
            var allCategorii = context.Categorie;
            var produsCategorii = new HashSet<int>(
            produs.CategorieProduse.Select(c => c.CategorieID));
            AssignedCategorieDataList = new List<AssignedCategorieData>();
            foreach (var cat in allCategorii)
            {
                AssignedCategorieDataList.Add(new AssignedCategorieData
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Assigned = produsCategorii.Contains(cat.ID)
                });
            }
        }
        public void UpdateCategorieProduse(Vicol_Lorena_ProiectContext context,
        string[] selectedCategorii, Produs produsToUpdate)
        {
            if (selectedCategorii == null)
            {
                produsToUpdate.CategorieProduse = new List<CategorieProdus>();
                return;
            }
            var selectedCategoriiHS = new HashSet<string>(selectedCategorii);
            var produsCategorii = new HashSet<int>
            (produsToUpdate.CategorieProduse.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriiHS.Contains(cat.ID.ToString()))
                {
                    if (!produsCategorii.Contains(cat.ID))
                    {
                        produsToUpdate.CategorieProduse.Add(
                        new CategorieProdus
                        {
                            ProdusID = produsToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (produsCategorii.Contains(cat.ID))
                    {
                        CategorieProdus courseToRemove
                        = produsToUpdate
                        .CategorieProduse
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
