﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vicol_Lorena_Proiect.Data;
using Vicol_Lorena_Proiect.Models;

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

        public async Task OnGetAsync()
        {
            if (_context.Categorie != null)
            {
                Categorie = await _context.Categorie.ToListAsync();
            }
        }
    }
}
