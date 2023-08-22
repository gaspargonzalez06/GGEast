using GGEats.UI.ViewModels;
using GGEats.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGEats.UI.Commands
{
    internal class AddOneOrderCommand:BaseCommads
    {
        private OrderViewModel _orderViewModel;

        public AddOneOrderCommand(OrderViewModel orderViewModel)
        {
            _orderViewModel = orderViewModel;
           
        }

        /// <summary>
        /// Explicar funcionamiento de boton.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            try
            {
                _orderViewModel.ToInsert = new List<OrderDTO>();

                OrderDTO orderDTO = parameter as OrderDTO;
                _orderViewModel.ToInsert.Add(orderDTO); 

                _orderViewModel.Window.DialogResult = true;

            }
            catch (Exception) { }

            _orderViewModel.Window.Close();
        }



    }
}
