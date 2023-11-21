using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vicol_Lorena_Proiect.Data;
using Vicol_Lorena_Proiect.Models;

namespace Vicol_Lorena_Proiect.Pages.Echipe
{
    public class EditModel : ListeAngajatiPageModel
    {
        private readonly Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext _context;

        public EditModel(Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Echipa Echipa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Echipa == null)
            {
                return NotFound();
            }

            Echipa =  await _context.Echipa
                .Include(b => b.ListeAngajati).ThenInclude(b => b.Angajat)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            
            if (Echipa == null)
            {
                return NotFound();
            }

            PopulateAssignedAngajatData(_context, Echipa);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedAngajati)
        {
            if (id == null)
            {
                return NotFound();
            }

            var echipaToUpdate = await _context.Echipa
            .Include(i => i.ListeAngajati)
            .ThenInclude(i => i.Angajat)
            .FirstOrDefaultAsync(s => s.ID == id);
            
            if (echipaToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Echipa>(
            echipaToUpdate,
            "Echipa",
            i => i.EchipaNume))
            {
                UpdateListeAngajati(_context, selectedAngajati, echipaToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateListeAngajati(_context, selectedAngajati, echipaToUpdate);
            PopulateAssignedAngajatData(_context, echipaToUpdate);
            return Page();
        }
    }

 }

