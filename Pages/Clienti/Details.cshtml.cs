using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vicol_Lorena_Proiect.Data;
using Vicol_Lorena_Proiect.Models;

namespace Vicol_Lorena_Proiect.Pages.Clienti
{
    public class DetailsModel : PageModel
    {
        private readonly Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext _context;

        public DetailsModel(Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext context)
        {
            _context = context;
        }

      public Client Client { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }
            else 
            {
                Client = client;
            }
            return Page();
        }
    }
}
