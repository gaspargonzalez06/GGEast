

namespace GGEats.UI.ViewModels
{
    public class DetailsDTO : BaseViewModel
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

        private string _idOrden;
        public string IdOrden
        {
            get => _idOrden; set
            {
                _idOrden = value;
                OnPropertyChanged(nameof(IdOrden));
            }

        }

        public string _productId;
        public string ProductId
        {
            get => _productId; set
            {
                _productId = value;
                OnPropertyChanged(nameof(ProductId));
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

        public decimal _impuesto;
        public decimal Impuesto
        {
            get => _impuesto; set
            {
                _impuesto = value;
                OnPropertyChanged(nameof(Impuesto));
            }

        }
        public int _cantidad;
        public int Cantidad
        {
            get => _cantidad; set
            {
                _cantidad = value;
                OnPropertyChanged(nameof(Cantidad));
            }

        }

        private decimal _subTotal;

        public decimal SubTotal
        {
            get => _subTotal; set
            {
                _subTotal = value;
                OnPropertyChanged(nameof(SubTotal));
            }

        }

        public decimal _totalLinea;

        public decimal TotalLinea
        {
            get => _totalLinea; set
            {
                _totalLinea = value;
                OnPropertyChanged(nameof(TotalLinea));
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

        public string _nombre;
        public string Nombre
        {
            get => _nombre; set
            {
                _nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }

        }
    }
}
