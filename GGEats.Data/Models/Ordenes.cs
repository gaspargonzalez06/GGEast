using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GGEats.Data.Models
{
    public class Ordenes
    {
        [Key]
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("fecha")]
        public string Fecha { get; set; }

        [DataType("numeric(10,2)")]
        [JsonProperty("total")]
        public decimal Total { get; set; }

        [DataType("numeric(10,2)")]
        [JsonProperty("subtotal")]
        public decimal SubTotal { get; set; }

        [DataType("numeric(10,2)")]
        [JsonProperty("impuesto")]
        public decimal Impuesto { get; set; }

        [JsonProperty("num_orden")]
        public string Product_Id { get; set; }

        [JsonProperty("importado")]
        public bool Importado { get; set; }

        [JsonProperty("procesada")]
        public bool Procesada { get; set; }


        public List<Detalles> Detalles { get; set; }
    }
}
