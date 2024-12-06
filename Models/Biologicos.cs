using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
      /// <summary>
    /// modelo  de registro componente biológico, incluyendo diversos parámetros.
    /// </summary>
    [Table("BIOLOGICOS")]
    public class Biologico
    {
        [Key]
        [Column("ID_BIOLOGICO")]
        public int IdBiologico { get; set; }

        [Column("ESCHERICHIA_COLI_NPM")]
        public decimal?  Escherichia_coli_npm { get; set; }

        [Column("ESCHERICHIA_COLI_UFC")]
        public decimal?  Escherichia_coli_ufc {get; set;}

        [Column("INDICE_BIOLOGICO")]
        public decimal?  Indice_biologico { get; set; }

        [Column("COLIFORMES_TOTALES_UFC")]
        public decimal?  Coliformes_totales_ufc {get; set;}   
        
        [Column("COLIFORMES_TOTALES_NPM")]
        public decimal?  Coliformes_totales_npm {get; set;}   

        [Column("RIQUEZAS_ALGAS")]
        public decimal?  Riquezas_algas {get; set;}   

        [Column("CLASIFICACION_INDICE_BMWP")]
        public string?  ClasificacionIBiologico {get; set;}   

        [Column("OBSERVACIONES")]
        public string?  Observaciones {get; set;}   

        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }

        [Column("FECHA_MUESTRA")]
        public DateTime? Fecha_Muestra { get;  set; }

        }
}
