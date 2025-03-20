using Clinic_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic_System.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .Property(p => p.Dateofbirth)
                .HasColumnType("date"); 
        }
        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}