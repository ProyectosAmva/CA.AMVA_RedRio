using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("METALES_SEDIMENTO")]
    public class MetalSedimental
    {
        [Key]
        [JsonProperty("ID_METAL_SEDIMENTO")]
        [Column("ID_METAL_SEDIMENTO")]
        public int IdMetalSedimental { get; set; }

        [JsonProperty("CADMIO_SEDIMENTABLE")]
        [Column("CADMIO_SEDIMENTABLE")]
        public decimal? Cadmio_sedimentable { get; set; }

        [JsonProperty("COBRE_SEDIMENTABLE")]
        [Column("COBRE_SEDIMENTABLE")]
        public decimal? Cobre_sedimentable { get; set; }

        [JsonProperty("CROMO_SEDIMENTABLE")]
        [Column("CROMO_SEDIMENTABLE")]
        public decimal? Cromo_sedimentable { get; set; }

        [JsonProperty("MERCURIO_SEDIMENTABLE")]
        [Column("MERCURIO_SEDIMENTABLE")]
        public decimal? Mercurio_sedimentable { get; set; }

        [JsonProperty("PLOMO_SEDIMENTABLE")]
        [Column("PLOMO_SEDIMENTABLE")]
        public decimal? Plomo_sedimentable { get; set; }

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
