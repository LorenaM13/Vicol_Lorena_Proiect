using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vicol_Lorena_Proiect.Data;
using Vicol_Lorena_Proiect.Models;

namespace Vicol_Lorena_Proiect.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext _context;

        public IndexModel(Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get;set; } = default!;

        public ProdusData ProdusD { get; set; }
        public int ProdusID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID)
        {
            ProdusD = new ProdusData();

            ProdusD.Produse = await _context.Produs
            .Include(b => b.Echipa)
            .Include(b => b.CategorieProduse)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (id != null)
            {
                ProdusID = id.Value;
                Produs produs = ProdusD.Produse
                .Where(i => i.ID == id.Value).Single();
                ProdusD.Categorii = produs.CategorieProduse.Select(s => s.Categorie);
            }
        }
    }
}
