using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
      /// <summary>
    /// Modelo de resultados de campo obtenidos durante las mediciones de calidad de agua o sedimentos.
    /// </summary>
    [Table("RESULTADOS_CAMPO")]
    public class ResultadoCampo
    {
        [Key]
        [Column("ID_RESULTADO_CAMPO")]
        public int IdCampo { get; set; }

        [Column("HORA")]
        public string? Hora { get; set; } 

        [Column("TEMP_AMBIENTE")]
        public decimal? TempAmbiente { get; set; } 

        [Column("TEMP_AGUA")]
        public decimal? TempAgua { get; set; } 

        [Column("PH")]
        public decimal? Ph { get; set; } 

        [Column("OD")]
        public decimal? Od { get; set; } 

        [Column("COND")]
        public decimal? Cond { get; set; } 

        [Column("ORP")]
        public decimal? Orp { get; set; } 

        [Column("TURB")]
        public decimal? Turb { get; set; } 

        [Column("TIEMPO")]
        public string? Tiempo { get; set; } 

        [Column("APARIENCIA")]
        public string? Apariencia { get; set; } 

        [Column("COLOR")]
        public string? Color { get; set; } 

        [Column("OLOR")]
        public string? Olor { get; set; } 

         [Column("ALTURA")]
        public string? Altura { get; set; } 
        
         [Column("H1")]
        public string? H1 { get; set; } 

         [Column("H2")]
        public string? H2 { get; set; } 

         [Column("OBSERVACION")]
        public string? Observacion { get; set; }

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
