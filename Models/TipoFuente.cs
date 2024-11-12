using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
    [Table("TIPO_FUENTE")]
    public class TipoFuente
    {
        [Key]
        [Column("ID_TIPO_FUENTE")]
        public int IdTipoFuente { get; set; }

        [Required]
        [Column("NOMBRE_TIPO_FUENTE")]
        public string NombreTipoFuente { get; set; } =string.Empty;
        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }

        [Column("ID_USUARIO")]
        public int? IdUsuario {get; set;}

    }
}
