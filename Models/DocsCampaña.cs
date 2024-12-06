using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
     /// <summary>
    /// modelo para relacion  entre una campaña y un documento cargado en el sistema. 
    /// Incluye información sobre el estado del documento, fechas de carga y actualización, 
    /// y el usuario que realiza la operación.
    /// </summary>
    [Table("DOCS_CAMPAÑA")]
    public class DocsCampaña
    {
        [Key]
        [Column("ID_DOC_CAMPAÑA")]
        public int Id_DocsCampaña { get; set; }

        [Column("ID_CAMPAÑA")]
        public int? IdCampaña { get; set; }

        [Column("ID_DOCUMENTO")]
        public int Id_Documento {get; set;}

        [Column("FECHA_CARGUE")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }

        [Column("ESTADO")]
        public string? Estado {get; set;}

        [Column("ID_USUARIO")]
        public int? IdUsuario {get; set;}

        public Campaña? Campaña { get; set; }
        public Documento? Documento { get; set; }


    }
}
