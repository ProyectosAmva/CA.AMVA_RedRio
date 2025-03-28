using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("FISICOS")]
    public class Fisico
    {
        [Key]
        [JsonProperty("ID_FISICO")]
        [Column("ID_FISICO")]
        public int IdFisico { get; set; }

        [JsonProperty("CAUDAL")]
        [Column("CAUDAL")]
        public decimal? Caudal { get; set; }

        [JsonProperty("CLASIFICACION_CAUDAL")]
        [Column("CLASIFICACION_CAUDAL")]
        public decimal? ClasificacionCaudal { get; set; }

        [JsonProperty("NUMERO_DE_VERTICALES")]
        [Column("NUMERO_DE_VERTICALES")]
        public int? NumeroDeVerticales { get; set; }

        [JsonProperty("COLOR_VERDADERO")]
        [Column("COLOR_VERDADERO")]
        public decimal? ColorVerdaderoUPC { get; set; }

        [JsonProperty("COLOR_TRIESTIMULAR_436NM")]
        [Column("COLOR_TRIESTIMULAR_436NM")]
        public decimal? ColorTriestimular436nm { get; set; }

        [JsonProperty("COLOR_TRIESTIMULAR_525NM")]
        [Column("COLOR_TRIESTIMULAR_525NM")]
        public decimal? ColorTriestimular525nm { get; set; }

        [JsonProperty("COLOR_TRIESTIMULAR_620NM")]
        [Column("COLOR_TRIESTIMULAR_620NM")]
        public decimal? ColorTriestimular620nm { get; set; }

        [JsonProperty("SOLIDOS_SUSPENDIDOS_TOTALES")]
        [Column("SOLIDOS_SUSPENDIDOS_TOTALES")]
        public decimal? SolidosSuspendidosTotales { get; set; }

        [JsonProperty("SOLIDOS_TOTALES")]
        [Column("SOLIDOS_TOTALES")]
        public decimal? SolidosTotales { get; set; }

        [JsonProperty("SOLIDOS_VOLATILES_TOTALES")]
        [Column("SOLIDOS_VOLATILES_TOTALES")]
        public decimal? SolidosVolatilesTotales { get; set; }

        [JsonProperty("SOLIDOS_DISUELTOS_TOTALES")]
        [Column("SOLIDOS_DISUELTOS_TOTALES")]
        public decimal? SolidosDisueltosTotales { get; set; }

        [JsonProperty("SOLIDOS_FIJOS_TOTALES")]
        [Column("SOLIDOS_FIJOS_TOTALES")]
        public decimal? SolidosFijosTotales { get; set; }

        [JsonProperty("SOLIDOS_SEDIMENTABLES")]
        [Column("SOLIDOS_SEDIMENTABLES")]
        public decimal? SolidosSedimentables { get; set; }

        [JsonProperty("FECHA_CREACION")]
        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; set; }

        [JsonProperty("FECHA_ACTUALIZACION")]
        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; set; }

        [JsonProperty("FECHA_MUESTRA")]
        [Column("FECHA_MUESTRA")]
        public DateTime? Fecha_Muestra { get; set; }

        [JsonProperty("ID_USUARIO")]
        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }
    }
}
