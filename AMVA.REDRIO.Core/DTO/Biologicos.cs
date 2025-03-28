using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;



namespace AMVA.REDRIO.Core.DTO;

      /// <summary>
    /// modelo  de registro componente biológico, incluyendo diversos parámetros.
    /// </summary>
    public class Biologico
    {
        [Key]
        [JsonProperty("ID_BIOLOGICO")]
        public int IdBiologico { get; set; }

        [JsonProperty("ESCHERICHIA_COLI_NPM")]
        public decimal?  Escherichia_coli_npm { get; set; }

        [JsonProperty("ESCHERICHIA_COLI_UFC")]
        public decimal?  Escherichia_coli_ufc {get; set;}

        [JsonProperty("INDICE_BIOLOGICO")]
        public decimal?  Indice_biologico { get; set; }

        [JsonProperty("COLIFORMES_TOTALES_UFC")]
        public decimal?  Coliformes_totales_ufc {get; set;}   
        
        [JsonProperty("COLIFORMES_TOTALES_NPM")]
        public decimal?  Coliformes_totales_npm {get; set;}   

        [JsonProperty("RIQUEZAS_ALGAS")]
        public decimal?  Riquezas_algas {get; set;}   

        [JsonProperty("CLASIFICACION_INDICE_BMWP")]
        public string?  ClasificacionIBiologico {get; set;}   

        [JsonProperty("OBSERVACIONES")]
        public string?  Observaciones {get; set;}   

        [JsonProperty("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get;  set; }

        [JsonProperty("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get;  set; }

        [JsonProperty("FECHA_MUESTRA")]
        public DateTime? Fecha_Muestra { get;  set; }

        }

