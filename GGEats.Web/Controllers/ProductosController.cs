using GGEats.Web.Models;
using GGEats.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GGEats.Web.Controllers
{
    public class ProductosController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Ordenes
        public ActionResult Productos()
        {
            ProductsRepository repository = new ProductsRepository();

          

            List<Productos> productos = repository.All();

            return View(productos); // Pasar la lista de órdenes a la vista
        }

        public ActionResult AgregarProducto()
        {
     
            return View(); // Retorna la vista con la lista de órdenes actualizada
        }

        [HttpPost]
        public ActionResult AddProduct(Productos product)
        {

            Productos producto = new Productos
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = product.Nombre,
                Sku = product.Sku,
                Precio = product.Precio
            };
            ProductsRepository productsRepository = new ProductsRepository();
            productsRepository.Add(producto);


            return RedirectToAction("Productos");
        }


    }
}