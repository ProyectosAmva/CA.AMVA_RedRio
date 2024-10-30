using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
    [Table("FISICOS")]
    public class Fisico
    {
        [Key]
        [Column("ID_FISICO")]
        public int IdFisico { get; set; }

        [Column("CAUDAL")]
        public decimal? Caudal { get; set; }

        [Column("CLASIFICACION_CAUDAL")]
        public decimal? ClasificacionCaudal { get; set; }

        [Column("NUMERO_DE_VERTICALES")]
        public int? NumeroDeVerticales { get; set; }

        [Column("COLOR_VERDADERO")]
        public decimal? ColorVerdaderoUPC { get; set; }

        [Column("COLOR_TRIESTIMULAR_436NM")]
        public decimal? ColorTriestimular436nm { get; set; }

        [Column("COLOR_TRIESTIMULAR_525NM")]
        public decimal? ColorTriestimular525nm { get; set; }

        [Column("COLOR_TRIESTIMULAR_620NM")]
        public decimal? ColorTriestimular620nm { get; set; }

        [Column("SOLIDOS_SUSPENDIDOS_TOTALES")]
        public decimal? SolidosSuspendidosTotales { get; set; }

        [Column("SOLIDOS_TOTALES")]
        public decimal? SolidosTotales { get; set; }

        [Column("SOLIDOS_VOLATILES_TOTALES")]
        public decimal? SolidosVolatilesTotales { get; set; }

        [Column("SOLIDOS_DISUELTOS_TOTALES")]
        public decimal? SolidosDisueltosTotales { get; set; }

        [Column("SOLIDOS_FIJOS_TOTALES")]
        public decimal? SolidosFijosTotales { get; set; }

        [Column("SOLIDOS_SEDIMENTABLES")]
        public decimal? SolidosSedimentables { get; set; }

        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }

        [Column("FECHA_MUESTRA")]
        public DateTime? Fecha_Muestra { get;  set; }

    }
}
