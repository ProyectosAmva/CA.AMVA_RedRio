using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
     /// <summary>
    /// Modelo que representa los tipos de fases en el sistema.
    /// </summary>
    [Table("TIPO_FASE")]
    public class TipoFase
    {
        [Key]
        [Column("ID_TIPO_FASE")]
        public int IdTipoFase { get; set; }

        [Required]
        [Column("NOMBRE_TIPO_FASE")]
        public string NombreTipoFase { get; set; }

        [Column("ID_USUARIO")]
        public int? IdUsuario {get; set;}
    }
}
