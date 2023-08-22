using GGEats.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace GGEats.Web.Repositories
{
    public class ProductsRepository
    {
        private ApplicationContext db = new ApplicationContext();

        public List<Productos> All()
        {
            return db.Productos.ToList();
        }

        public Productos FindById(string id)
        {
            return db.Productos.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public void Add(Productos productos)
        {
            db.Add(productos);
            db.SaveChanges();
        }

        public void Update(Productos productos)
        {
            db.Update(productos);
            db.SaveChanges();
        }

        public void Delete(Productos productos)
        {
            db.Remove(productos);
            db.SaveChanges();
        }
    }
}