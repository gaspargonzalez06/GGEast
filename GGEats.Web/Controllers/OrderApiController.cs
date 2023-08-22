using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GGEats.Web.Models;

namespace GGEats.Web.Controllers
{
    public class OrderApiController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();


        // GET api/<controller>/5
        [HttpGet]
        public List<Ordenes> Get()
        {
            List<Ordenes> ordenes = db.Ordenes.Where(x => x.Importado == false && x.Procesada == true).ToList();
            ordenes.ForEach(x => { x.Importado = true; });
            db.SaveChanges();
            for (int i = 0; i < ordenes.Count; i++)
            {
                List<Detalles> detalles = db.Detalles
                    .Where(x => x.Order_Id.Equals(ordenes[i].Id))
                    .Join(db.Productos,
                        detalle => detalle.Product_Id,
                        producto => producto.Id,
                        (detalle, producto) => new Detalles
                        {
                            Id = detalle.Id,
                            Order_Id = detalle.Order_Id,
                            Product_Id = detalle.Product_Id,
                            Precio = detalle.Precio,
                            Impuesto = detalle.Impuesto,
                            Cantidad = detalle.Cantidad,
                            Total_Linea = detalle.Total_Linea,
                            SubTotal = detalle.SubTotal,
                            Producto = producto
                        })
                .ToList();

                ordenes[i].Detalles = detalles;
            }
            return ordenes;
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}