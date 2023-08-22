using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGEats.Migrador
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Iniciando migracion.");
            // Cargando migracion a la base de datos 
            using (GGEatsDataContext db = new GGEatsDataContext("Data Source=192.168.1.143,50196;Initial Catalog=GGEats;User ID=sa;Password=#1mymicros;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
            {
                db.Database.Migrate();
                Console.WriteLine("Se migro la base de datos.");
            }
            Console.ReadLine();
        }
    }
}
