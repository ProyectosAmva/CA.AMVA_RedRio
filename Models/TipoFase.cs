using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
    [Table("TIPO_FASE")]
    public class TipoFase
    {
        [Key]
        [Column("ID_TIPO_FASE")]
        public int IdTipoFase { get; set; }

        [Required]
        [Column("NOMBRE_TIPO_FASE")]
        public string NombreTipoFase { get; set; }
    }
}
