using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vicol_Lorena_Proiect.Data;
using Vicol_Lorena_Proiect.Models;

namespace Vicol_Lorena_Proiect.Pages.Comenzi
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext _context;

        public CreateModel(Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {


        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
        ViewData["ProdusID"] = new SelectList(_context.Produs, "ID", "Nume");
            return Page();
        }

        [BindProperty]
        public Comanda Comanda { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Comanda == null || Comanda == null)
            {
                return Page();
            }

            _context.Comanda.Add(Comanda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
