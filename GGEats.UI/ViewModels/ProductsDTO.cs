using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGEats.UI.ViewModels
{
    public class ProductsDTO:BaseViewModel
    {
        private string _id;
        public string Id
        {
            get => _id; set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }

        }

        private string _nombre;

        public string Nombre
        {
            get => _nombre; set
            {
                _nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }

        }
        public string _sku;
        public string Sku
        {
            get => _sku; set
            {
                _sku = value;
                OnPropertyChanged(nameof(Sku));
            }

        }

        public decimal _precio;
        public decimal Precio
        {
            get => _precio; set
            {
                _precio = value;
                OnPropertyChanged(nameof(Precio));
            }

        }

    }
}
