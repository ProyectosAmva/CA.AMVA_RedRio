using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("HISTORIAL_EXCEL")]
    public class HistorialExcel
    {
        [Key]
        [JsonProperty("ID_HISTORIAL_EXCEL")]
        [Column("ID_HISTORIAL_EXCEL")]
        public int IdHistorialExcel { get; set; }

        [JsonProperty("FECHA_CARGUE")]
        [Column("FECHA_CARGUE")]
        public DateTime Fecha_cargue { get; set; }

        [JsonProperty("NOMBRE")]
        [Column("NOMBRE")]
        public string? nombre { get; set; }

        [JsonProperty("URL")]
        [Column("URL")]
        public string? Url { get; set; }

        [JsonProperty("ID_CAMPAÑA")]
        [Column("ID_CAMPAÑA")]
        public int? IdCampaña { get; set; }

        [JsonProperty("FECHA_ACTUALIZACION")]
        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; set; }

        [JsonProperty("ID_USUARIO")]
        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }

        public Campaña? Campaña { get; set; }
    }
}
