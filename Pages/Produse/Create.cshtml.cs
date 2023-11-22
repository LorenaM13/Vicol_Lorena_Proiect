using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vicol_Lorena_Proiect.Data;
using Vicol_Lorena_Proiect.Models;

namespace Vicol_Lorena_Proiect.Pages.Produse
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : CategorieProdusePageModel
    {
        private readonly Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext _context;

        public CreateModel(Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["EchipaID"] = new SelectList(_context.Set<Echipa>(), "ID", "EchipaNume");

            var produs = new Produs();
            produs.CategorieProduse = new List<CategorieProdus>();
            PopulateAssignedCategorieData(_context, produs);

            return Page();
        }

        [BindProperty]
        public Produs Produs { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync(string[] selectedCategorii)
        {
            var newProdus = new Produs();
            if (selectedCategorii != null)
            {
                newProdus.CategorieProduse = new List<CategorieProdus>();
                foreach (var cat in selectedCategorii)
                {
                    var catToAdd = new CategorieProdus
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newProdus.CategorieProduse.Add(catToAdd);
                }
            }
            Produs.CategorieProduse = newProdus.CategorieProduse;
            _context.Produs.Add(Produs);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Produse/Index");
        }
    }
}
