using GGEats.Data;
using GGEats.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGEats.UI.Commands
{
    public class DeleteOrderCommand:BaseCommads
    {
        private OrderViewModel _orderViewModel;

        public DeleteOrderCommand(OrderViewModel orderViewModel)
        {
            _orderViewModel = orderViewModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            OrderDTO orderDTO = parameter as OrderDTO;

            // Eliminar orden con el query handler
            QueryHandler handler = new QueryHandler();
            using (GGEatsAppDataContext db = handler.InitDb())
            {
                handler.DeleteOrder(db, orderDTO.Id);
            }

            // Recargar ordenes.
            _orderViewModel.CargarData();
        }
    }
}
