using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
     /// <summary>
    /// Modelo de Insitu,
    /// incluyendo parámetros como ORP, oxígeno disuelto, turbidez, temperatura del agua, temperatura ambiente, 
    /// conductividad eléctrica, pH, y las fechas asociadas a la medición.
    /// </summary>
    [Table("INSITU")]
    public class Insitu
    {
        [Key]
        [Column("ID_INSITU")]
        public int IdInsitu { get; set; }

        [Column("ORP")]
        public decimal?  OrpInsitu { get; set; }

        [Column("OXIGENO_DISUELTO")]
        public decimal?  Oxigeno_disuelto {get; set;}

        [Column("TURBIEDAD")]
        public decimal?  Turbiedad { get; set; }

        [Column("TEMP_AGUA")]
        public decimal?  Tem_agua {get; set;}    

        [Column("TEMP_AMBIENTE")]
        public decimal?  Temp_ambiente {get; set;}

        [Column("CONDUCTIVIDAD_ELECTRICA")]
        public decimal?  Conductiviidad_electrica { get; set; }

        [Column("PH")]
        public decimal?  PhInsitu {get; set;}    

        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }

        [Column("FECHA_MUESTRA")]
        public DateTime? Fecha_Muestra { get;  set; }
        
        [Column("ID_USUARIO")]
        public int? IdUsuario {get; set;}


        }
}
