using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("REPORTES_LABORATORIO")]
    public class ReportesLaboratorio
    {
        [Key]
        [JsonProperty("ID_REPORTE_LABORATORIO")]
        [Column("ID_REPORTE_LABORATORIO")]
        public int IdReporte { get; set; }

        [JsonProperty("ID_RESULTADO_CAMPO")]
        [Column("ID_RESULTADO_CAMPO")]
        public int? IdResultadoCampo { get; set; }

        [JsonProperty("ID_CAMPAÑA")]
        [Column("ID_CAMPAÑA")]
        public int? IdCampaña { get; set; }

        [JsonProperty("ID_ESTACION")]
        [Column("ID_ESTACION")]
        public int? IdEstacion { get; set; }

        [JsonProperty("ID_MUESTRA_COMPUESTA")]
        [Column("ID_MUESTRA_COMPUESTA")]
        public int? IdMuestraCompuesta { get; set; }

        [JsonProperty("FECHA_CREACION")]
        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; set; }

        [JsonProperty("FECHA_ACTUALIZACION")]
        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; set; }

        [JsonProperty("ID_USUARIO")]
        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }

        public Campaña? Campaña { get; set; }
        public ResultadoCampo? ResultadoCampo { get; set; }
        public Estacion? Estacion { get; set; }
        public MuestraCompuesta? MuestraCompuesta { get; set; }
    }
}
