using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
    [Table("DOCUMENTOS")]
    public class Documentos
    {
        [Key]
        [Column("ID_DOCUMENTO")]
        public int Id_Documento { get; set; }

        [Column("NOMBRE")]
        public string? Nombre { get; set; }

        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }

        [Column("ESTADO")]
        public Boolean Estado {get; set;}

    }
}
