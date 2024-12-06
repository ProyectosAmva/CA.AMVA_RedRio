using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
     /// <summary>
    /// Modelo de reporte de laboratorio relacionado con los resultados de campo, campañas, estaciones y muestras compuestas.
    /// </summary>
    [Table("REPORTES_LABORATORIO")]
    public class ReportesLaboratorio
    {
        [Key]
        [Column("ID_REPORTE_LABORATORIO")]
        public int IdReporte { get; set; }

        
        [Column("ID_RESULTADO_CAMPO")]
        public int? IdResultadoCampo { get; set; }

        
        [Column("ID_CAMPAÑA")]
        public int? IdCampaña { get; set; }

        
        [Column("ID_ESTACION")]
        public int? IdEstacion { get; set; }

        [Column("ID_MUESTRA_COMPUESTA")]
        public int? IdMuestraCompuesta { get; set; }

        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }

        [Column("ID_USUARIO")]
        public int? IdUsuario {get; set;}

        

         public Campaña? Campaña { get; set; }
         public ResultadoCampo? ResultadoCampo { get; set; }
        public Estacion? Estacion { get; set; }
        public MuestraCompuesta? MuestraCompuesta { get; set; }
        

    }
}
