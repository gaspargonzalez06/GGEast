using GGEats.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGEats.Migrador
{
    internal class GGEatsDataContext:DbContext

    {

        private string _connectionString;

        /// <summary>
        /// Definicion de lista de detalles para migracion
        /// </summary>
   
        /// <summary>
        /// Definicion de lista de ordenes para migracion
        /// </summary>
        public DbSet<Ordenes> Ordenes { get; set; }
        
        public DbSet<Detalles> Detalles { get; set; }
        
        //public DbSet<Productos> Productos { get; set; }
        
        public GGEatsDataContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["GGEats"].ConnectionString;
        }

        public GGEatsDataContext(string connectionString)
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

        /// <summary>
        /// Para definir relaciones en las tablas y demas.
        /// </summary>
        /// <param name="modelBuilder"></param>
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Ordenes>()
        //        .HasMany(x => x.Detalles)
        //        .WithOne(x => x.Orden)
        //        .HasForeignKey(x => x.OrdenesId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}

