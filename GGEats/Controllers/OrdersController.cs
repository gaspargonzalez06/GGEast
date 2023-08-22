
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GGEats.Controllers
{
    public class OrdersController : Controller
    {

        public ActionResult MostrarOrdenes()
        {
            /*
            QueryHandler handler = new QueryHandler();

            GGEatsWebDataContext db = handler.InitDb();
            List<Ordenes> ordenes = handler.SelectOrdenes(db);
            */

            //List<Ordenes> ordenes2 = ordenes.ConvertAll(o => new Ordenes
            //{
            //    Id = o.Id,
            //    Fecha = o.Fecha,
            //    Total = o.Total,
            //    SubTotal = o.SubTotal,
            //    Impuesto = o.Impuesto,
            //    Product_Id = o.Product_Id,
            //    Importado = o.Importado,
            //    Procesada = o.Procesada
            //});

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();  
        }
       
    }
}
