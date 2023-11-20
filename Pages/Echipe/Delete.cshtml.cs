using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vicol_Lorena_Proiect.Data;
using Vicol_Lorena_Proiect.Models;

namespace Vicol_Lorena_Proiect.Pages.Echipe
{
    public class DeleteModel : PageModel
    {
        private readonly Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext _context;

        public DeleteModel(Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext context)
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

            var echipa = await _context.Echipa.FirstOrDefaultAsync(m => m.ID == id);

            if (echipa == null)
            {
                return NotFound();
            }
            else 
            {
                Echipa = echipa;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Echipa == null)
            {
                return NotFound();
            }
            var echipa = await _context.Echipa.FindAsync(id);

            if (echipa != null)
            {
                Echipa = echipa;
                _context.Echipa.Remove(Echipa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
