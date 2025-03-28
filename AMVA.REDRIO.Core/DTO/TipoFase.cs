using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("TIPO_FASE")]
    public class TipoFase
    {
        [Key]
        [JsonProperty("ID_TIPO_FASE")]
        [Column("ID_TIPO_FASE")]
        public int IdTipoFase { get; set; }

        [Required]
        [JsonProperty("NOMBRE_TIPO_FASE")]
        [Column("NOMBRE_TIPO_FASE")]
        public string NombreTipoFase { get; set; }

        [JsonProperty("ID_USUARIO")]
        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }
    }
}
