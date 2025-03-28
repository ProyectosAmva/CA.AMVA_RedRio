using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("NUTRIENTE")]
    public class Nutriente
    {
        [Key]
        [JsonProperty("ID_NUTRIENTE")]
        [Column("ID_NUTRIENTE")]
        public int IdNutriente { get; set; }

        [JsonProperty("NITROGENO_TOTAL_KJELDAHL")]
        [Column("NITROGENO_TOTAL_KJELDAHL")]
        public decimal? Nitrogeno_total_kjeldahl { get; set; }

        [JsonProperty("FOSFORO_ORGANICO")]
        [Column("FOSFORO_ORGANICO")]
        public decimal? Fosforo_organico { get; set; }

        [JsonProperty("NITRATOS")]
        [Column("NITRATOS")]
        public decimal? Nitratos { get; set; }

        [JsonProperty("FOSFORO_TOTAL")]
        [Column("FOSFORO_TOTAL")]
        public decimal? Fosforo_total { get; set; }

        [JsonProperty("NITROGENO_ORGANICO")]
        [Column("NITROGENO_ORGANICO")]
        public decimal? Nitrogeno_organico { get; set; }

        [JsonProperty("NITRITOS")]
        [Column("NITRITOS")]
        public decimal? Nitritos { get; set; }

        [JsonProperty("FOSFATO")]
        [Column("FOSFATO")]
        public decimal? Fosfato { get; set; }

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
