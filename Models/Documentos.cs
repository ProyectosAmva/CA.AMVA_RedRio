using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
    [Table("DOCUMENTOS")]
    public class Documento
    {
        [Key]
        [Column("ID_DOCUMENTO")]
        public int Id_Documento { get; set; }

        [Column("NOMBRE")]
        public string? Nombre { get; set; }

        [Column("URL")]
        public string? Url {get; set;}


        [Column("FECHA_CARGUE")]
        public DateTime Fecha_cargue { get; set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get;  set; }

        [Column("ESTADO")]
        public string? Estado {get; set;}

    }
}
