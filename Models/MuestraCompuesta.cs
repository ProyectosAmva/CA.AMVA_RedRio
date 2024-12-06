using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
     /// <summary>
    /// Modelo de muestra compuesta que incluye diferentes foraneas de
    /// fisicoquímicos, biológicos y metálicos, permitiendo almacenar y asociar varias propiedades 
    /// relacionadas con los parámetros de la muestra.
    /// </summary>
    [Table("MUESTRA_COMPUESTA")]
    public class MuestraCompuesta
    {
        [Key]
        [Column("ID_MUESTRA_COMPUESTA")]
        public int IdMuestraCompuesta { get; set; }

        [Column("ID_INSITU")]
        public int? IdInsitu { get; set; }

        
        [Column("ID_NUTRIENTE")]
        public int? IdNutriente { get; set; }

        
        [Column("ID_QUIMICO")]
        public int? IdQuimico { get; set; }

        
        [Column("ID_FISICO")]
        public int? IdFisico { get; set; }

        
        [Column("ID_METAL_AGUA")]
        public int? IdMetalAgua { get; set; }

        [Column("ID_METAL_SEDIMENTO")]
        public int? IdMetalSedimental { get; set; }

        
        [Column("ID_BIOLOGICO")]
        public int? IdBiologico { get; set; }
  
        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }

        [Column("FECHA_MUESTRA")]
        public DateTime? Fecha_Muestra { get;  set; }

        [Column("ID_USUARIO")]
        public int? IdUsuario {get; set;}


        
         public Insitu? Insitu { get; set; }
         public Nutriente? Nutriente { get; set; }
         public Quimico? Quimico { get; set; }
         public Fisico? Fisico { get; set; }
         public MetalAgua? MetalAgua { get; set; }
        public MetalSedimental? MetalSedimental { get; set; }

         public Biologico? Biologico { get; set; }


    }
}
