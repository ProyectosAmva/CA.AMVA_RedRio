using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("TIPO_FUENTE")]
    public class TipoFuente
    {
        [Key]
        [JsonProperty("ID_TIPO_FUENTE")]
        [Column("ID_TIPO_FUENTE")]
        public int IdTipoFuente { get; set; }

        [Required]
        [JsonProperty("NOMBRE_TIPO_FUENTE")]
        [Column("NOMBRE_TIPO_FUENTE")]
        public string NombreTipoFuente { get; set; } = string.Empty;

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
