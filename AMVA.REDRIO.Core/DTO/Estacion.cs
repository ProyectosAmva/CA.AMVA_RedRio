using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("ESTACIONES")]
    public class Estacion
    {
        [Key]
        [JsonProperty("ID_ESTACION")]
        [Column("ID_ESTACION")]
        public int IdEstacion { get; set; }

        [Required]
        [JsonProperty("CODIGO")]
        [Column("CODIGO")]
        public string codigo { get; set; }

        [Required]
        [JsonProperty("NOMBRE_ESTACION")]
        [Column("NOMBRE_ESTACION")]
        public string nombreEstacion { get; set; }

        [Required]
        [JsonProperty("ID_MUNI")]
        [Column("ID_MUNI")]
        public int IdMunicipio { get; set; }

        [JsonProperty("ID_TIPO_FUENTE")]
        [Column("ID_TIPO_FUENTE")]
        public int IdTipoFuente { get; set; }

        [JsonProperty("ELEVACION")]
        [Column("ELEVACION")]
        public Decimal? Elevacion { get; set; }

        [JsonProperty("GRADOS_LATITUD")]
        [Column("GRADOS_LATITUD")]
        public int? Grados_latitud { get; set; }

        [JsonProperty("MINUTOS_LATITUD")]
        [Column("MINUTOS_LATITUD")]
        public int? Minutos_latitud { get; set; }

        [JsonProperty("SEGUNDOS_LATITUD")]
        [Column("SEGUNDOS_LATITUD")]
        public Decimal? Segundos_latitud { get; set; }

        [JsonProperty("GRADOS_LOGITUD")]
        [Column("GRADOS_LOGITUD")]
        public int? Grados_longitud { get; set; }

        [JsonProperty("MINUTOS_LOGITUD")]
        [Column("MINUTOS_LOGITUD")]
        public int? Minutos_longitud { get; set; }

        [JsonProperty("SEGUNDOS_LONGITUD")]
        [Column("SEGUNDOS_LONGITUD")]
        public Decimal? Segundos_longitud { get; set; }

        [JsonProperty("FECHA_CREACION")]
        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; set; }

        [JsonProperty("FECHA_ACTUALIZACION")]
        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; set; }

        [JsonProperty("ID_USUARIO")]
        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }

        public Municipio? Municipio { get; set; }

        public TipoFuente? TipoFuente { get; set; }
    }
}
