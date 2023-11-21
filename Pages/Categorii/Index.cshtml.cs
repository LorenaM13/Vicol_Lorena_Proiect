using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vicol_Lorena_Proiect.Data;
using Vicol_Lorena_Proiect.Models;
using Vicol_Lorena_Proiect.ViewModels;

namespace Vicol_Lorena_Proiect.Pages.Categorii
{
    public class IndexModel : PageModel
    {
        private readonly Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext _context;

        public IndexModel(Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get;set; } = default!;

        public CategorieIndexData CategorieData { get; set; }
        public int CategorieID { get; set; }
        public int ProdusID { get; set; }
        public async Task OnGetAsync(int? id, int? produsID)
        {
            CategorieData = new CategorieIndexData();
            CategorieData.Categorii = await _context.Categorie
                .Include(i => i.CategorieProduse)
            .ThenInclude(i => i.Produs)
            .OrderBy(i => i.NumeCategorie)
            .ToListAsync();

            if (id != null)
            {
                CategorieID = id.Value;
                Categorie categorie = CategorieData.Categorii
                .Where(i => i.ID == id.Value).Single();
                CategorieData.CategorieProduse = categorie.CategorieProduse;

            }
        }
    }
}
