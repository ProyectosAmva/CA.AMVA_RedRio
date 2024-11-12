using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
    [Table("QUIMICOS")]
    public class Quimico
    {
        [Key]
        [Column("ID_QUIMICO")]
        public int IdQuimico { get; set; }

        [Column("SUST_ACTIVA_AZUL_METILENO")]
        public decimal?  sustanciaActivaAzulMetileno { get; set; }

        [Column("GRASA_ACEITE")]
        public decimal?  Grasa_Aceite {get; set;}

        [Column("DB05")]
        public decimal?  Db05 { get; set; }

        [Column("DQ0")]
        public decimal?  Dq0 {get; set;}    

        [Column("HIERRO_TOTAL")]
        public decimal?  HierroTotal {get; set;} 

        [Column("SULFATOS")]
        public decimal?  Sulfatos {get; set;} 

        [Column("SULFUROS")]
        public decimal?  Sulfuros {get; set;} 

        [Column("CLORUROS")]
        public decimal?  Cloruros {get; set;} 

        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime Fecha_actualizacion { get; internal set; }

        [Column("FECHA_MUESTRA")]
        public DateTime? Fecha_Muestra { get;  set; }

        [Column("ID_USUARIO")]
        public int? IdUsuario {get; set;}

        }
}
