using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
     /// <summary>
    /// modelo de campaña que tiene un nombre, una descripción, fechas de inicio y fin, 
    /// una fase asociada y un usuario responsable.
    /// </summary>
    [Table("CAMPAÑAS")]
    public class Campaña
    {
        [Key]
        [Column("ID_CAMPAÑA")]
        public int IdCampaña { get; set; }

        [Column("NOMBRE_CAMPAÑA")]
        public string? NombreCampaña { get; set; }

        [Required]
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

        [Required]
        [Column("FECHA_INICIAL")]
        public DateTime  Fecha_inicial {get; set;}

        [Required]
        [Column("FECHA_FINAL")]
        public DateTime  Fecha_final {get; set;}

        [Required]
        [Column("ID_FASE")]
        public int IdFase {get; set;}

        [Column("ID_USUARIO")]
        public int? IdUsuario {get; set;}

        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }

        public Fase? Fase { get; set; }
        // public UsuariosDTO Usuario { get; set; }

    }

}
