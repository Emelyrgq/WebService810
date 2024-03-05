using Microsoft.EntityFrameworkCore;

namespace APIMonedas.Models
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
    }
}
