using APIMonedas.Models;
using Microsoft.EntityFrameworkCore;

namespace WebService810.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {

        }
        public DbSet<TasaCambio> TasasCambio { get; set; }

        public DbSet<IndiceInflacion> IndicesInflacion { get; set; }

        public DbSet<SaludFinanciera> SaludFinanciera { get; set; }

        public DbSet<HistorialCrediticio> HistorialCrediticio { get; set; }

        //public DbSet<WebServiceUsage> WebServiceUsage { get; set; }
    }
}
