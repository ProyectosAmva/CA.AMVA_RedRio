using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
     /// <summary>
    /// Modelo  de fase dentro de un proceso, incluyendo información como 
    /// el nombre de la fase, año, tipo de fase y fechas de creación y actualización.
    /// </summary>
    [Table("FASES")]
    public class Fase
    {
        [Key]
        [Column("ID_FASE")]
        public int IdFase { get; set; }

        [Required]
        [Column("NOMBRE_FASE")]
        public string NombreFase { get; set; }

        [Required]
        [Column("AÑO")]
        public int Año {get; set;}

        [Required]
        [Column("ID_TIPO_FASE")]
        public int IdTipoFase {get; set;}

        public TipoFase? TipoFase { get; set; }

        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }

        [Column("ID_USUARIO")]
        public int? IdUsuario {get; set;}


    }
}
