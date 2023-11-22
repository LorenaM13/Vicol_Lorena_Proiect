using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vicol_Lorena_Proiect.Data;
using Vicol_Lorena_Proiect.Models;
using Vicol_Lorena_Proiect.ViewModels;

namespace Vicol_Lorena_Proiect.Pages.Echipe
{
    public class IndexModel : PageModel
    {
        private readonly Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext _context;

        public IndexModel(Vicol_Lorena_Proiect.Data.Vicol_Lorena_ProiectContext context)
        {
            _context = context;
        }

        public IList<Echipa> Echipa { get;set; } = default!;
        
        public EchipaData EchipaD { get; set; }

        public EchipaIndexData EchipaData1 { get; set; }
        public int EchipaID { get; set; }
        public int AngajatID { get; set; }
        public int ProdusID { get; set; }


        public async Task OnGetAsync(int? id, int? produsID)
        {
            EchipaD = new EchipaData();

            EchipaD.Echipe = await _context.Echipa
            .Include(b => b.ListeAngajati)
            .ThenInclude(b => b.Angajat)
            .AsNoTracking()
            .OrderBy(b => b.EchipaNume)
            .ToListAsync();

            EchipaData1 = new EchipaIndexData();

            EchipaData1.Echipe = await _context.Echipa
                .Include(i => i.Produse)
                .OrderBy(i => i.EchipaNume)
                .ToListAsync();

            if (id != null)
            {
                EchipaID = id.Value;

                Echipa echipa = EchipaD.Echipe
                .Where(i => i.ID == id.Value).Single();
                EchipaD.Angajati = echipa.ListeAngajati.Select(s => s.Angajat);

                Echipa echipa1 = EchipaData1.Echipe
                .Where(i => i.ID == id.Value).Single();
                EchipaData1.Produse = echipa1.Produse;
            }
        }
    }
}
