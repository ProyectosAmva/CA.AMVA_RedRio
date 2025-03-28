using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("DEPARTAMENTOS")]
    public class Departamento
    {
        [Key]
        [JsonProperty("ID_DEPTO")]
        [Column("ID_DEPTO")]
        public int IdDepartamento { get; set; }

        [Required]
        [JsonProperty("NOMBRE")]
        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [JsonProperty("CODIGO")]
        [Column("CODIGO")]
        public string? Codigo { get; set; }

        [JsonProperty("FECHA_CREACION")]
        [Column("FECHA_CREACION")]
        public DateTime? FechaCreacion { get; set; }

        [JsonProperty("FECHA_ACTUALIZACION")]
        [Column("FECHA_ACTUALIZACION")]
        public DateTime? FechaActualizacion { get; set; }
    }
}
