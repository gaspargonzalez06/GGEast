using GGEats.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGEats.Data
{
    public class QueryHandler
    {
        public GGEatsAppDataContext InitDb()
        {
            return new GGEatsAppDataContext(GGEatsConfig.ConnectionStringSimphony);
        }

        /// <summary>
        ///  Transforma las ordenes leidas del api y las ingresa a la base de datos 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="orders"></param>


        public void InsertOrdenes(GGEatsAppDataContext db, List<Ordenes> orders)
        {
            foreach (Ordenes order in orders)
            {
                Ordene exist = db.Ordenes.FirstOrDefault(ex => ex.Id == order.Id);

                if (exist != null)
                {
                    continue;
                }

                Ordene newOrder = new Ordene
                {
                    Id = order.Id,
                    Fecha = order.Fecha,
                    Importado = order.Importado,
                    Procesada = order.Procesada,
                    Impuesto = order.Impuesto,
                    SubTotal = order.SubTotal,
                    Total = order.Total,
                    Detalles = new EntitySet<Detalle>()
                };

                foreach (Detalles detalle in order.Detalles)
                {
                    Detalle newDetalle = new Detalle
                    {
                        Id = detalle.Id,
                        Precio = detalle.Precio,
                        Impuesto = detalle.Impuesto,
                        Cantidad = detalle.Cantidad,
                        Total_Linea = detalle.Total_Linea,
                        SubTotal = detalle.SubTotal,
                        Sku = detalle.Producto.Sku,
                        Nombre = detalle.Producto.Nombre
                    };

                    newOrder.Detalles.Add(newDetalle);
                }

                db.Ordenes.InsertOnSubmit(newOrder);
                db.SubmitChanges();
            }
        }


        public void DeleteOrder(GGEatsAppDataContext db, string selectedid)
        {
            Ordene ordersToRemove = db.Ordenes.FirstOrDefault(o => o.Id == selectedid);
            List<Detalle> detailsToRemove = db.Detalles.Where(o => o.OrdenId == selectedid).ToList();
            // Eliminar las órdenes filtradas de la lista original
            foreach (Detalle det in detailsToRemove)
            {
                db.Detalles.DeleteOnSubmit(det);

            }

            db.Ordenes.DeleteOnSubmit(ordersToRemove);

            db.SubmitChanges();


        }
    }
}
