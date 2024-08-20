using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediPal.Models;

namespace MediPal.Data
{
    public class MediPalContext : DbContext
    {
        public MediPalContext (DbContextOptions<MediPalContext> options)
            : base(options)
        {
        }

        public DbSet<MediPal.Models.SymptomList> SymptomList { get; set; } = default!;
    }
}
