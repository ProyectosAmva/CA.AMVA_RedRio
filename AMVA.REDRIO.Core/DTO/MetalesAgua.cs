using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("METAL_AGUA")]
    public class MetalAgua
    {
        [Key]
        [JsonProperty("ID_METAL_AGUA")]
        [Column("ID_METAL_AGUA")]
        public int IdMetalAgua { get; set; }

        [JsonProperty("CADMIO")]
        [Column("CADMIO")]
        public decimal? Cadmio { get; set; }

        [JsonProperty("NIQUEL")]
        [Column("NIQUEL")]
        public decimal? Niquel { get; set; }

        [JsonProperty("COBRE")]
        [Column("COBRE")]
        public decimal? Cobre { get; set; }

        [JsonProperty("MERCURIO")]
        [Column("MERCURIO")]
        public decimal? Mercurio { get; set; }

        [JsonProperty("CROMO")]
        [Column("CROMO")]
        public decimal? Cromo { get; set; }

        [JsonProperty("PLOMO")]
        [Column("PLOMO")]
        public decimal? Plomo { get; set; }

        [JsonProperty("CROMO_HEXAVALENTE")]
        [Column("CROMO_HEXAVALENTE")]
        public decimal? Cromo_hexavalente { get; set; }

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
