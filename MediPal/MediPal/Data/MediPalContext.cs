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
        public MediPalContext(DbContextOptions<MediPalContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Symptom>().HasData(
                new Symptom { SymptomID = 1, SymptomName = "Headache", PainLevel = 4, Date = DateOnly.FromDateTime(DateTime.Now), Activity = "Post physical training session" },
                new Symptom { SymptomID = 2, SymptomName = "Chills", PainLevel = 2, Date = DateOnly.FromDateTime(DateTime.Now), Activity = "Sleeping" },
                new Symptom { SymptomID = 3, SymptomName = "Body aches", PainLevel = 6, Date = DateOnly.FromDateTime(DateTime.Now), Activity = "Showering" }
                );
        }

        //Add Dbset for each model
        public DbSet<MediPal.Models.Symptom> Symptoms { get; set; } = default!;
    }
}
