using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace GGEats.Web.Models
{
    public class ApplicationContext : DbContext
    {

        private string _connectionString;

        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Detalles> Detalles { get; set; }
        public DbSet<Productos> Productos { get; set; }

        public ApplicationContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["GGEats"].ConnectionString;
        }

        public ApplicationContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Configura el conector a SQL Server.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}