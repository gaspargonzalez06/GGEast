using GGEats.Web.Models;
using GGEats.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GGEats.Web.Controllers
{
    public class OrdenesController : Controller
    {
        private ApplicationContext db = new ApplicationContext();


        [HttpGet]
        public ActionResult VerOrdenes()
        {
            OrderRepository repository = new OrderRepository();


            List<Ordenes> ordenes = repository.All();

            return View(ordenes); // Retorna la vista con la lista de órdenes actualizada
        }

        [HttpPost]
        public ActionResult AgregarOrden(List<Detalles> detalles)
        {
            OrderRepository repository = new OrderRepository();
            var det = detalles;

            Ordenes orden = new Ordenes
            {
                Id = Guid.NewGuid().ToString(),
                Fecha = DateTime.Now.ToString(),
                Total = 0,
                SubTotal = 0,
                Impuesto = 0,
                Product_Id = "", // ¿Necesitas asignar un valor específico aquí?
                Importado = false,
                Procesada = false,
                Detalles = new List<Detalles>()
            };

            foreach (var detalle in detalles)
            {
                detalle.Id = Guid.NewGuid().ToString();
                detalle.Order_Id = orden.Id;
                detalle.Product_Id = detalle.Product_Id;  // El producto se asignará más tarde
                detalle.Precio = detalle.Precio;
                // Calcula el impuesto de linea al 7%

                // Calcula el total de la línea (precio * cantidad)
                detalle.Total_Linea = detalle.Precio * detalle.Cantidad;
                detalle.Impuesto = Math.Round(detalle.Total_Linea * 0.07m, 2);
                detalle.SubTotal = detalle.Total_Linea;
                detalle.Total_Linea += detalle.Impuesto;

                // Actualiza el subtotal de la orden
                orden.SubTotal += detalle.Total_Linea;
                // Actualiza el impuesto de la orden
                orden.Impuesto += detalle.Impuesto;

                // Agrega el detalle a la lista de detalles de la orden
                orden.Detalles.Add(detalle);
            }


            // Calcula el total de la orden
            orden.Total = orden.SubTotal + orden.Impuesto;

            repository.Add(orden);  // Agrega la orden al repositorio

            List<Ordenes> ordenes = repository.All();

            return RedirectToAction("VerOrdenes"); // Retorna la vista con la lista de órdenes actualizada
        }


        [HttpPost]
        public ActionResult PagarOrden(string id_orden)
        {
            OrderRepository repository = new OrderRepository();
            repository.Update(id_orden);
            List<Ordenes> ordenes = repository.All();
            return RedirectToAction("VerOrdenes"); // Retorna la vista con la lista de órdenes actualizada
        }
    }
}