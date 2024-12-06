using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
      /// <summary>
    /// Modelo  de metales sedimentables ,
    /// incluyendo Cadmio, Cobre, Cromo, Mercurio y Plomo, así como las fechas de muestra, 
    /// creación y actualización de los datos.
    /// </summary>
    [Table("METALES_SEDIMENTO")]
    public class MetalSedimental
    {
        [Key]
        [Column("ID_METAL_SEDIMENTO")]
        public int IdMetalSedimental { get; set; }

        [Column("CADMIO_SEDIMENTABLE")]
        public decimal?  Cadmio_sedimentable { get; set; }

        [Column("COBRE_SEDIMENTABLE")]
        public decimal?  Cobre_sedimentable { get; set; }
        
        [Column("CROMO_SEDIMENTABLE")]
        public decimal?  Cromo_sedimentable {get; set;}   

        [Column("MERCURIO_SEDIMENTABLE")]
        public decimal?  Mercurio_sedimentable {get; set;}   

        [Column("PLOMO_SEDIMENTABLE")]
        public decimal?  Plomo_sedimentable {get; set;}

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
