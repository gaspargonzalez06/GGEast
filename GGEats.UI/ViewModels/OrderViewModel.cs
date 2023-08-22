using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using GGEats.Data;
using GGEats.UI.Commands;
using System.Security.Cryptography;

namespace GGEats.UI.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        protected ObservableCollection<OrderDTO> _orders;

        public IList<OrderDTO> Orders
        {
            get => _orders;
            set
            {
                _orders = (ObservableCollection<OrderDTO>)value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        bool _selected = false;




        public List<OrderDTO> ToInsert;


        public MainWindow Window { get; set; }

        // Llamado para comando de agregar ordenes
        public ICommand AddOrderCommand { get; set; }
        public ICommand AddOneOrderCommand { get; set; }
        // Llamado para comando de eliminar odenes
        public ICommand DeleteOrderCommand { get; set; }

        public OrderViewModel(MainWindow window)
        {
            Window = window;
            AddOrderCommand = new AddOrderCommand(this);
            DeleteOrderCommand = new DeleteOrderCommand(this);
            AddOneOrderCommand = new AddOneOrderCommand(this);  
            _orders = new ObservableCollection<OrderDTO>();
            CargarData();
        }



        public void CargarData()
        {
            try
            {

                // Limpiar la lista de ordenes.
                _orders.Clear();

                // Llamar a la base de datos.
                QueryHandler handler = new QueryHandler();

                using (GGEatsAppDataContext db = handler.InitDb())
                {
                    //if(number == 2)
                    //{
                    //    List<Ordene> orderslist = db.Ordenes.ToList();
                    //}else if(number == 1) 
                    //{

                    //    Ordene orden= db.
                    //}
                    List<Ordene> orderslist = db.Ordenes.ToList();
                    // Para convertir Ordenes a ordenDTO y Detalles a DetailDTO

                    foreach (Ordene order in orderslist)
                    {
                        List<Detalle> detailsList = db.Detalles.Where(det => det.OrdenId == order.Id).ToList();

                        OrderDTO orden = new OrderDTO
                        {
                            Id = order.Id,
                            Fecha = order.Fecha,
                            Impuesto = order.Impuesto,
                            SubTotal = order.SubTotal,
                            Total = order.Total,
                        };

                        foreach (Detalle detalle in detailsList)
                        {
                            orden.Details.Add(new DetailsDTO
                            {
                                Id = detalle.Id,
                                Impuesto = detalle.Impuesto,
                                SubTotal = detalle.SubTotal,
                                TotalLinea = detalle.Total_Linea,
                                IdOrden = detalle.OrdenId,
                                Cantidad = detalle.Cantidad,                        
                                Precio = detalle.Precio,
                                Sku = detalle.Sku,
                                Nombre = detalle.Nombre,    
                                

                            });
                        }
                        // Agregando orden para ser usada en ui
                        _orders.Add(orden);
                        OnPropertyChanged(nameof(Orders));
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }




}

