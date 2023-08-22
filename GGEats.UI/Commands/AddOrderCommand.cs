using GGEats.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GGEats.UI.Commands
{
    public class AddOrderCommand:BaseCommads
    {
        private OrderViewModel _orderViewModel;
        public AddOrderCommand(OrderViewModel orderViewModel)
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

                foreach (var orden in _orderViewModel.Orders)
                {
                    _orderViewModel.ToInsert.Add(orden);
                }
                _orderViewModel.Window.DialogResult = true;

            }
            catch (Exception) { }

            _orderViewModel.Window.Close();
        }

    }
}
