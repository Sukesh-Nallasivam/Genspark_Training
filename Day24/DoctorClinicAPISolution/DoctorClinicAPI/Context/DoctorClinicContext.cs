using DoctorClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicAPI.Context
{
    public class DoctorClinicContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=.\\SQLEXPRESS;Integrated security=true ;Initial Catalog : DoctorClinicDB2;");
        }

        public DbSet<Doctor> Doctors { get; set; }
    }
}
