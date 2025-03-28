using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("MUNICIPIO")]
    public class Municipio
    {
        [Key]
        [JsonProperty("ID_MUNI")]
        [Column("ID_MUNI")]
        public int IdMunicipio { get; set; }

        [Required]
        [JsonProperty("NOMBRE")]
        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [JsonProperty("CODIGO")]
        [Column("CODIGO")]
        public string? Codigo { get; set; }

        [Required]
        [JsonProperty("ID_DEPTO")]
        [Column("ID_DEPTO")]
        public int Id_Departamento { get; set; }

        public Departamento? Departamento { get; set; }
    }
}
