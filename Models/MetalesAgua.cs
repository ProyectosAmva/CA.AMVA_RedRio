using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
    [Table("METAL_AGUA")]
    public class MetalAgua
    {
        [Key]
        [Column("ID_METAL_AGUA")]
        public int IdMetalAgua { get; set; }

        [Column("CADMIO")]
        public decimal?  Cadmio { get; set; }

        [Column("NIQUEL")]
        public decimal?  Niquel {get; set;}

        [Column("COBRE")]
        public decimal?  Cobre { get; set; }

        [Column("MERCURIO")]
        public decimal?  Mercurio {get; set;}   
        
        [Column("CROMO")]
        public decimal?  Cromo {get; set;}   

        [Column("PLOMO")]
        public decimal?  Plomo {get; set;}
        
        [Column("CROMO_HEXAVALENTE")]
        public decimal?  Cromo_hexavalente {get; set;}  

        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }

        [Column("FECHA_MUESTRA")]
        public DateTime? Fecha_Muestra { get;  set; }

        }
}
