using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GGEats.Web.Models
{
    public class Productos
    {
        [Key]

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [DataType("numeric(10,2)")]

        [JsonProperty("precio")]
        public decimal Precio { get; set; }
    }
}