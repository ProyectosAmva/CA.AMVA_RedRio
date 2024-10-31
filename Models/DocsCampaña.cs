using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
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

        [Column("USUARIO")]
        public string? Usuario {get; set;}

        public Campaña? Campaña { get; set; }
        public Documento? Documento { get; set; }


    }
}
