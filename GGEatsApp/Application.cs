using EMC.Data.Sql;
using GGEats.Data;
using GGEats.Data.Models;
using GGEats.UI;
using GGEats.UI.ViewModels;
using Micros.Ops;
using Micros.Ops.Extensibility;
using Micros.PosCore.Extensibility;
using Newtonsoft.Json;
using SimphonyUtilities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GGEatsApp
{
    public class Application : OpsExtensibilityApplication
    {


        private readonly string baseurl = "http://192.168.1.104:53688/api/";

        private Task _task;
        private  static bool _whileBool=true;
        public Application(IExecutionContext context) : base(context)
        {
            GGEatsConfig.ConnectionStringDelivery = Getconnectionstring("CheckPostingDB");
            GGEatsConfig.ConnectionStringSimphony = Getconnectionstring("GGEats");
     
             _task = CargarBaseDatosBG() ;
        }



        [ExtensibilityMethod]

        public async Task VerVentana()
        {
       
            try
            {
                MainWindow window = new MainWindow();
                OrderViewModel viewModel = (OrderViewModel)window.DataContext;

                if (window.ShowDialog() != true)
                {
                    return;
                }



                using (DBGGEatsAppDataContext db = new DBGGEatsAppDataContext(GGEatsConfig.ConnectionStringDelivery))
                {
                    // se cargan las ordenes que estan en base de datos
                    var toInsert = viewModel.ToInsert;
                  
                    // se procesan las ordenes y se homologan los items para su debido pago
                    foreach (OrderDTO ord in toInsert)
                    {
                        OpsContext.ProcessCommand(new OpsCommand(OpsCommandType.BeginCheck));

                        foreach (DetailsDTO det in ord.Details)
                        {
                            // Se hace join de las tablas necesarias para homologar los items
                            var obj = db.MENU_ITEM_MASTERs
                                .Join(
                                    db.EXTENSION_DATA_VALUEs, // Primer Parametro = Tabla en Linq
                                    mim => mim.MenuItemMasterID, // Segundo Parametro = Key en la tabla principal
                                    edv => edv.DataElementID, // Tercer Parametro = Key en la tabla secundaria
                                    (mim, edv) => new // Cuarto Parametro = Lambda del Resultado
                                    {
                                        MenuItems = mim,
                                        ExtensionDataValues = edv,
                                    }
                                .Join(
                                    db.EXTENSION_DATA_PROPERTies, // Primer Parametro = Tabla en Linq
                                    x => x.ExtensionDataValues.ExtensionDataPropertyID, // Segundo Parametro = Key en la tabla principal
                                    edp => edp.ExtensionDataPropertyID, // Tercer Parametro = Key en la tabla secundaria
                                    (x, edp) => new // Cuarto Parametro = Lambda del Resultado
                                    {
                                        ExtensionDataProperty = edp,
                                        MenuItems = x.MenuItems,
                                        ExtensionDataValues = x.ExtensionDataValues,
                                    }
                                )
                                .Where(data => data.ExtensionDataProperty.Name.Equals("Item_Gaspar")
                                    && data.ExtensionDataValues.XMLProperties.Equals(det.Sku));

                            string query = obj.ToString();
                            var resultSet = obj.FirstOrDefault();

                            if (resultSet == null)
                            {
                                OpsContext.ShowError("No se encontro un producto homologado.");
                                return;
                            }

                            int? objectNumber = resultSet.MenuItems.ObjectNumber;

                            OpsContext.ProcessCommand(new OpsCommand(OpsCommandType.MenuItem)
                            {
                                Text =det.Cantidad.ToString(),
                                Number = (int)objectNumber,

                            });

                        }
                        await Task.Delay(TimeSpan.FromSeconds(7));

                        // Se paga la cuenta.
                        OpsContext.ProcessCommand(new OpsCommand(OpsCommandType.Payment)
                        {
                            Arguments = $"Cash:Cash *",
                            Number = 1,
                        });

                        QueryHandler handler = new QueryHandler();
                        OrderDTO selectedid = ord;
                        // se elimina la orden despues de pagada 
                        using (GGEatsAppDataContext db2 = handler.InitDb())
                        {
                            handler.DeleteOrder(db2, selectedid.Id.ToString());
                            MainWindow window2 = new MainWindow();
                            OrderViewModel viewmodel = new OrderViewModel(window2);
                            viewmodel.CargarData();
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                OpsContext.ShowException(ex, "Ha ocurrido un error inesperado.");
            }
        }

        public string Getconnectionstring(string catalog)
        {
            DatabaseSettings settings = DatabaseSettings.GetDbSettings(DatabaseSettings.DatabaseAlias.CPServiceDb);

            // guardamos el catalogo original para evitar que el pos no funcione.
            string originalcatalog = settings.DBCatalog;

            // setteamos al catalogo que deseamos.
            settings.DBCatalog = catalog;

            // generamos el connection string que requerimos.
            string connectionstring = DatabaseConnection.GetConnectionString(settings);

            // setteamos al catalogo original del dbsettings.
            settings.DBCatalog = originalcatalog;

            return connectionstring;
        }


      
        public async Task CargarBaseDatosBG()
        {
            while ( true)
            {
                /*
                List<Ordenes> ordenes = await OrderRequest();


                QueryHandler handler = new QueryHandler();

                using (GGEatsAppDataContext db = handler.InitDb())
                    
                {
                    handler.InsertOrdenes(db, ordenes);
                }
                */
                await CargarBaseDatos();
                await Task.Delay(TimeSpan.FromSeconds(60));
            }
        }

        [ExtensibilityMethod]
        public async Task CargarBaseDatos()
        {
            try
            {
                List<Ordenes> ordenes = await OrderRequest();

                QueryHandler handler = new QueryHandler();

                using (GGEatsAppDataContext db = handler.InitDb())
                {

                    try
                    {
                        handler.InsertOrdenes(db, ordenes);
                    }
                    catch (Exception ex)
                    {
                        OpsContext.ShowException(ex, "Ha ocurrido un error inesperado.");
                    }

                }
            }
            catch (Exception ex)
            {
                OpsContext.ShowException(ex, "Ha ocurrido un error inesperado.");
            }
        }
        public async Task<List<Ordenes>> OrderRequest()
        {

            List<Ordenes> ordenes = new List<Ordenes>();

            try
            {
                using (HttpClient client = new HttpClient())
                {

                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(baseurl + "OrderApi");

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string ResponseString = await response.Content.ReadAsStringAsync();
                     
                        List<Ordenes> ResponseObject = JsonConvert.DeserializeObject<List<Ordenes>>(ResponseString);



                        return ResponseObject;
                    }

                    return ordenes;

                }
            }
            catch (Exception ex)
            {
                OpsContext.ShowException(ex, "Algo ha salido mal");
                return ordenes;

            }

        }
    }

}
