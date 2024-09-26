using MediPal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace MediPal.Data
{
    //public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole, string>(options)
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        //Add Dbset for each model

        public DbSet<Symptom> Symptoms { get; set; } // Creating the table for symptoms to be added when using context to code-first migration
        public DbSet<Note> Notes { get; set; } // Creating the table for notes to be added when using context to code-first migration

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Symptom>()
                .HasOne(s => s.User)
                .WithMany(u => u.Symptoms)
                .HasForeignKey(s => s.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }


    }
}

