using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
    [Table("DOCS_CAMPAÑA")]
    public class DocsCampaña
    {
        [Key]
        [Column("ID_DOCUMENTO")]
        public int Id_DocsCampaña { get; set; }

        [Column("ID_CAMPAÑA")]
        public string? IdCampaña { get; set; }

        [Column("ID_DOCUMENTO")]
        public int Id_Documento {get; set;}

        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }

        [Column("ESTADO")]
        public Boolean Estado {get; set;}

        [Column("USUARIO")]
        public string? Usuario {get; set;}

    }
}
