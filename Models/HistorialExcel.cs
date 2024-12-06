using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
    /// <summary>
    /// Modelo de informacion histórica relacionada con los archivos de Excel cargados,
    /// incluyendo detalles sobre el archivo, fecha de carga, la campaña asociada y la última actualización.
    /// </summary>
    [Table("HISTORIAL_EXCEL")]
    public class HistorialExcel
    {
        [Key]
        [Column("ID_HISTORIAL_EXCEL")]
        public int IdHistorialExcel { get; set; }

        [Column("FECHA_CARGUE")]
        public DateTime Fecha_cargue { get; set; }


        [Column("NOMBRE")]
        public string? nombre {get; set;}

        [Column("URL")]
        public string? Url {get; set;}

        [Column("ID_CAMPAÑA")]
        public int? IdCampaña {get; set;}


        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }

        [Column("ID_USUARIO")]
        public int? IdUsuario {get; set;}



        public Campaña? Campaña { get; set; }


    }
}
