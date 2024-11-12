using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
    [Table("NUTRIENTES")]
    public class Nutriente
    {
        [Key]
        [Column("ID_NUTRIENTE")]
        public int IdNutriente { get; set; }

        [Column("NITROGENO_TOTAL_KJELDAHL")]
        public decimal?  Nitrogeno_total_kjeldahl { get; set; }

        [Column("FOSFORO_ORGANICO")]
        public decimal?  Fosforo_organico {get; set;}

        [Column("NITRATOS")]
        public decimal?  Nitratos { get; set; }

        [Column("FOSFORO_TOTAL")]
        public decimal?  Fosforo_total {get; set;}   
        
        [Column("NITROGENO_ORGANICO")]
        public decimal?  Nitrogeno_organico {get; set;}  
        
        [Column("NITRITOS")]
        public decimal?  Nitritos {get; set;}  

        [Column("FOSFATO")]
        public decimal?  Fosfato {get; set;}  

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
