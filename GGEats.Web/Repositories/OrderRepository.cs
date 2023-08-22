using GGEats.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace GGEats.Web.Repositories
{
    public class OrderRepository
    {
        private ApplicationContext db = new ApplicationContext();

        public List<Ordenes> All()
        {
            return db.Ordenes.ToList();
        }

        public Ordenes FindById(string id)
        {
            return db.Ordenes.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public void Add(Ordenes ordenes)
        {
            db.Add(ordenes);
            db.SaveChanges();
        }

        public void Update(string id_ordenes)
        {
            Ordenes orden = db.Ordenes.FirstOrDefault(o => o.Id == id_ordenes);
            if (orden != null)
            {
                orden.Procesada = true;
                db.SaveChanges();
            }
        }
        public void Delete(Ordenes ordenes) 
        {
            db.Remove(ordenes);
            db.SaveChanges();
        }
    }
}