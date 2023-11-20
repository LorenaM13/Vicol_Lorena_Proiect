using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vicol_Lorena_Proiect.Models;

namespace Vicol_Lorena_Proiect.Data
{
    public class Vicol_Lorena_ProiectContext : DbContext
    {
        public Vicol_Lorena_ProiectContext (DbContextOptions<Vicol_Lorena_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Vicol_Lorena_Proiect.Models.Produs> Produs { get; set; } = default!;

        public DbSet<Vicol_Lorena_Proiect.Models.Echipa>? Echipa { get; set; }

        public DbSet<Vicol_Lorena_Proiect.Models.Categorie>? Categorie { get; set; }
    }
}
