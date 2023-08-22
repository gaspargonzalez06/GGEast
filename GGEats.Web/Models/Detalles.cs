using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GGEats.Web.Models
{
    public class Detalles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonIgnore]
        public Ordenes Orden { get; set; }

        [JsonIgnore]
        [JsonProperty("order_id")]
        public string Order_Id { get; set; }

        [JsonIgnore]
        [JsonProperty("product_id")]
        public string Product_Id { get; set; }

        [DataType("numeric(10,2)")]
        [JsonProperty("precio")]
        public decimal Precio { get; set; }

        [DataType("numeric(10,2)")]
        [JsonProperty("impuesto")]
        public decimal Impuesto { get; set; }

        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }

        [DataType("numeric(10,2)")]
        [JsonProperty("total_linea")]
        public decimal Total_Linea { get; set; }

        [DataType("numeric(10,2)")]
        [JsonProperty("subtotal")]
        public decimal SubTotal { get; set; }

        [JsonProperty("producto")]
        public Productos Producto { get; set; }
    }
}