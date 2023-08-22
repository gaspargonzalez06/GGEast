using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGEats.UI.ViewModels
{
    public class OrderDTO : BaseViewModel
    {
        private string _selected;
        public string Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
            }

        }
        private string _id;

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }

        }
        private string _fecha;

        public string Fecha
        {
            get => _fecha;
            set
            {
                _fecha = value;
                OnPropertyChanged(nameof(Fecha));
            }

        }

        private decimal _impuesto;

        public decimal Impuesto
        {
            get => _impuesto;
            set
            {
                _impuesto = value;
                OnPropertyChanged(nameof(Impuesto));
            }

        }

        private decimal _subTotal;

        public decimal SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                OnPropertyChanged(nameof(SubTotal));
            }

        }

        private decimal _total;

        public decimal Total
        {
            get => _total;
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }

        }

        private ObservableCollection<DetailsDTO> _details;

        public IList<DetailsDTO> Details => _details;

        public OrderDTO()
        {
            _details = new ObservableCollection<DetailsDTO>();
        }


    }
}
