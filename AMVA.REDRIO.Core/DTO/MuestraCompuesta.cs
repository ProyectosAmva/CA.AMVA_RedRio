using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("MUESTRA_COMPUESTA")]
    public class MuestraCompuesta
    {
        [Key]
        [JsonProperty("ID_MUESTRA_COMPUESTA")]
        [Column("ID_MUESTRA_COMPUESTA")]
        public int IdMuestraCompuesta { get; set; }

        [JsonProperty("ID_INSITU")]
        [Column("ID_INSITU")]
        public int? IdInsitu { get; set; }

        [JsonProperty("ID_NUTRIENTE")]
        [Column("ID_NUTRIENTE")]
        public int? IdNutriente { get; set; }

        [JsonProperty("ID_QUIMICO")]
        [Column("ID_QUIMICO")]
        public int? IdQuimico { get; set; }

        [JsonProperty("ID_FISICO")]
        [Column("ID_FISICO")]
        public int? IdFisico { get; set; }

        [JsonProperty("ID_METAL_AGUA")]
        [Column("ID_METAL_AGUA")]
        public int? IdMetalAgua { get; set; }

        [JsonProperty("ID_METAL_SEDIMENTO")]
        [Column("ID_METAL_SEDIMENTO")]
        public int? IdMetalSedimental { get; set; }

        [JsonProperty("ID_BIOLOGICO")]
        [Column("ID_BIOLOGICO")]
        public int? IdBiologico { get; set; }

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

        public Insitu? Insitu { get; set; }
        public Nutriente? Nutriente { get; set; }
        public Quimico? Quimico { get; set; }
        public Fisico? Fisico { get; set; }
        public MetalAgua? MetalAgua { get; set; }
        public MetalSedimental? MetalSedimental { get; set; }
        public Biologico? Biologico { get; set; }
    }
}
