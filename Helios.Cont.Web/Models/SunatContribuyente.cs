using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Helios.Cont.Web.Models
{
    public partial class SunatContribuyente
    {
        [JsonProperty("ruc")]
        public long Ruc { get; set; }

        [JsonProperty("nombre_o_razon_social")]
        public string NombreORazonSocial { get; set; }

        [JsonProperty("estado_del_contribuyente")]
        public string EstadoDelContribuyente { get; set; }

        [JsonProperty("condicion_de_domicilio")]
        public string CondicionDeDomicilio { get; set; }

        [JsonProperty("ubigeo")]
        public int Ubigeo { get; set; }

        [JsonProperty("tipo_de_via")]
        public string TipoDeVia { get; set; }

        [JsonProperty("nombre_de_via")]
        public string NombreDeVia { get; set; }

        [JsonProperty("codigo_de_zona")]
        public string CodigoDeZona { get; set; }

        [JsonProperty("tipo_de_zona")]
        public string TipoDeZona { get; set; }

        [JsonProperty("numero")]
        public int Numero { get; set; }

        [JsonProperty("interior")]
        public string Interior { get; set; }

        [JsonProperty("lote")]
        public string Lote { get; set; }

        [JsonProperty("dpto")]
        public string Dpto { get; set; }

        [JsonProperty("manzana")]
        public string Manzana { get; set; }

        [JsonProperty("kilometro")]
        public string Kilometro { get; set; }

        [JsonProperty("direccion")]
        public string Direccion { get; set; }
    }
}