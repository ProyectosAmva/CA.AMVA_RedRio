using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("RESULTADOS_CAMPO")]
    public class ResultadoCampo
    {
        [Key]
        [JsonProperty("ID_RESULTADO_CAMPO")]
        [Column("ID_RESULTADO_CAMPO")]
        public int IdCampo { get; set; }

        [JsonProperty("HORA")]
        [Column("HORA")]
        public string? Hora { get; set; } 

        [JsonProperty("TEMP_AMBIENTE")]
        [Column("TEMP_AMBIENTE")]
        public decimal? TempAmbiente { get; set; } 

        [JsonProperty("TEMP_AGUA")]
        [Column("TEMP_AGUA")]
        public decimal? TempAgua { get; set; } 

        [JsonProperty("PH")]
        [Column("PH")]
        public decimal? Ph { get; set; } 

        [JsonProperty("OD")]
        [Column("OD")]
        public decimal? Od { get; set; } 

        [JsonProperty("COND")]
        [Column("COND")]
        public decimal? Cond { get; set; } 

        [JsonProperty("ORP")]
        [Column("ORP")]
        public decimal? Orp { get; set; } 

        [JsonProperty("TURB")]
        [Column("TURB")]
        public decimal? Turb { get; set; } 

        [JsonProperty("TIEMPO")]
        [Column("TIEMPO")]
        public string? Tiempo { get; set; } 

        [JsonProperty("APARIENCIA")]
        [Column("APARIENCIA")]
        public string? Apariencia { get; set; } 

        [JsonProperty("COLOR")]
        [Column("COLOR")]
        public string? Color { get; set; } 

        [JsonProperty("OLOR")]
        [Column("OLOR")]
        public string? Olor { get; set; } 

        [JsonProperty("ALTURA")]
        [Column("ALTURA")]
        public string? Altura { get; set; } 
        
        [JsonProperty("H1")]
        [Column("H1")]
        public string? H1 { get; set; } 

        [JsonProperty("H2")]
        [Column("H2")]
        public string? H2 { get; set; } 

        [JsonProperty("OBSERVACION")]
        [Column("OBSERVACION")]
        public string? Observacion { get; set; }

        [JsonProperty("FECHA_CREACION")]
        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; set; }

        [JsonProperty("FECHA_ACTUALIZACION")]
        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; set; }

        [JsonProperty("FECHA_MUESTRA")]
        [Column("FECHA_MUESTRA")]
        public DateTime? Fecha_Muestra { get; set; }

        [JsonProperty("ID_USUARIO")]
        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }
    }
}
