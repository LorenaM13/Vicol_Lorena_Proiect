using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vicol_Lorena_Proiect.Data;
using Vicol_Lorena_Proiect.Models;

namespace Vicol_Lorena_Proiect.Pages.Produse
{
    public class EditModel : CategorieProdusePageModel
    {
        private readonly Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext _context;

        public EditModel(Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produs Produs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produs == null)
            {
                return NotFound();
            }

            Produs =  await _context.Produs
                .Include(b => b.Echipa)
                .Include(b => b.CategorieProduse).ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Produs == null)
            {
                return NotFound();
            }

            PopulateAssignedCategorieData(_context, Produs);

            ViewData["EchipaID"] = new SelectList(_context.Echipa, "ID", "EchipaNume");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategorii)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produsToUpdate = await _context.Produs
            .Include(i => i.Echipa)
            .Include(i => i.CategorieProduse)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (produsToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Produs>(
            produsToUpdate,
            "Produs",
            i => i.Nume,
            i => i.Pret, i => i.EchipaID))
            {
                UpdateCategorieProduse(_context, selectedCategorii, produsToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Produse/Index");
            }

            UpdateCategorieProduse(_context, selectedCategorii, produsToUpdate);
            PopulateAssignedCategorieData(_context, produsToUpdate);
            return Page();
        }

    }
}
