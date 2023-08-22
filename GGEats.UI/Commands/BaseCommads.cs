using GGEats.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GGEats.UI.Commands
{
    public abstract class BaseCommads : ICommand
    {

        public event EventHandler CanExecuteChanged;
        private OrderViewModel _orderViewModel;


        public virtual bool CanExecute(object parameter)
        {
            return true;
        }


        public abstract void Execute(object parameter);


        protected void OnCanExecuteChanged()
        {

            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public void OnChanged(object sender, PropertyChangedEventArgs args)
        {
            // nameof(_userViewModel.Email) retornar string 'Email'
            if (CheckProp(args, nameof(_orderViewModel.Orders)))
            {
                OnCanExecuteChanged();
            }
        }


        private bool CheckProp(PropertyChangedEventArgs args, string prop)
        {
            return args.PropertyName.Equals(prop);
        }

    }
}
