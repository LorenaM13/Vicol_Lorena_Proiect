using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vicol_Lorena_Proiect.Data;
//using Vicol_Lorena_Proiect.Migrations;
using Vicol_Lorena_Proiect.Models;

namespace Vicol_Lorena_Proiect.Pages.Echipe
{
    public class CreateModel : ListeAngajatiPageModel
    {
        private readonly Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext _context;

        public CreateModel(Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var echipa = new Echipa();
            echipa.ListeAngajati = new List<ListaAngajati>();
            PopulateAssignedAngajatData(_context, echipa);

            return Page();
        }

        [BindProperty]
        public Echipa Echipa { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync(string[] selectedAngajati)
        {
            var newEchipa = new Echipa();
            if (selectedAngajati != null)
            {
                newEchipa.ListeAngajati = new List<ListaAngajati>();
                foreach (var cat in selectedAngajati)
                {
                    var catToAdd = new ListaAngajati
                    {
                        AngajatID = int.Parse(cat)
                    };
                    newEchipa.ListeAngajati.Add(catToAdd);
                }
            }
            Echipa.ListeAngajati = newEchipa.ListeAngajati;
            _context.Echipa.Add(Echipa);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
