using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vicol_Lorena_Proiect.Data;
using Vicol_Lorena_Proiect.Models;

namespace Vicol_Lorena_Proiect.Pages.Comenzi
{
    public class DeleteModel : PageModel
    {
        private readonly Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext _context;

        public DeleteModel(Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Comanda Comanda { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Comanda == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comanda.FirstOrDefaultAsync(m => m.ID == id);

            if (comanda == null)
            {
                return NotFound();
            }
            else 
            {
                Comanda = comanda;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Comanda == null)
            {
                return NotFound();
            }
            var comanda = await _context.Comanda.FindAsync(id);

            if (comanda != null)
            {
                Comanda = comanda;
                _context.Comanda.Remove(Comanda);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
