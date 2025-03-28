using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("QUIMICO")]
    public class Quimico
    {
        [Key]
        [JsonProperty("ID_QUIMICO")]
        [Column("ID_QUIMICO")]
        public int IdQuimico { get; set; }

        [JsonProperty("SUST_ACTIVA_AZUL_METILENO")]
        [Column("SUST_ACTIVA_AZUL_METILENO")]
        public decimal? sustanciaActivaAzulMetileno { get; set; }

        [JsonProperty("GRASA_ACEITE")]
        [Column("GRASA_ACEITE")]
        public decimal? Grasa_Aceite { get; set; }

        [JsonProperty("DB05")]
        [Column("DB05")]
        public decimal? Db05 { get; set; }

        [JsonProperty("DQ0")]
        [Column("DQ0")]
        public decimal? Dq0 { get; set; }

        [JsonProperty("HIERRO_TOTAL")]
        [Column("HIERRO_TOTAL")]
        public decimal? HierroTotal { get; set; }

        [JsonProperty("SULFATOS")]
        [Column("SULFATOS")]
        public decimal? Sulfatos { get; set; }

        [JsonProperty("SULFUROS")]
        [Column("SULFUROS")]
        public decimal? Sulfuros { get; set; }

        [JsonProperty("CLORUROS")]
        [Column("CLORUROS")]
        public decimal? Cloruros { get; set; }

        [JsonProperty("FECHA_CREACION")]
        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; set; }

        [JsonProperty("FECHA_ACTUALIZACION")]
        [Column("FECHA_ACTUALIZACION")]
        public DateTime Fecha_actualizacion { get; set; }

        [JsonProperty("FECHA_MUESTRA")]
        [Column("FECHA_MUESTRA")]
        public DateTime? Fecha_Muestra { get; set; }

        [JsonProperty("ID_USUARIO")]
        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }
    }
}
