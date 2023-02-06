using Microsoft.EntityFrameworkCore;
using PatientsWeb.Models;

namespace PatientsWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
