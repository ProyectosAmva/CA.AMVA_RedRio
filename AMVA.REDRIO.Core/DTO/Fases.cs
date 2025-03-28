using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("FASES")]
    public class Fase
    {
        [Key]
        [JsonProperty("ID_FASE")]
        [Column("ID_FASE")]
        public int IdFase { get; set; }

        [Required]
        [JsonProperty("NOMBRE_FASE")]
        [Column("NOMBRE_FASE")]
        public string NombreFase { get; set; }

        [Required]
        [JsonProperty("AÑO")]
        [Column("AÑO")]
        public int Año { get; set; }

        [Required]
        [JsonProperty("ID_TIPO_FASE")]
        [Column("ID_TIPO_FASE")]
        public int IdTipoFase { get; set; }

        public TipoFase? TipoFase { get; set; }

        [JsonProperty("FECHA_CREACION")]
        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; set; }

        [JsonProperty("FECHA_ACTUALIZACION")]
        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; set; }

        [JsonProperty("ID_USUARIO")]
        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }
    }
}
