using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediPal.Shared.Models;

namespace MediPal.Shared.Data
{
    public class MediPalContext : DbContext
    {
        public MediPalContext (DbContextOptions<MediPalContext> options)
            : base(options)
        {
        }

        public DbSet<MediPal.Shared.Models.Symptom> Symptoms { get; set; } = default!;
    }
}
