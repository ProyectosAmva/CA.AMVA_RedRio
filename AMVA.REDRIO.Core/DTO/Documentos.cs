using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    /// <summary>
    /// Modelo documento cargado en el sistema, incluyendo información sobre su nombre, 
    /// URL, fechas de carga y actualización, y su estado actual.
    /// </summary>
    [Table("DOCUMENTOS")]
    public class Documento
    {
        [Key]
        [JsonProperty("ID_DOCUMENTO")]
        [Column("ID_DOCUMENTO")]
        public int Id_Documento { get; set; }

        [JsonProperty("NOMBRE")]
        [Column("NOMBRE")] 
        public string? Nombre { get; set; }

        [JsonProperty("URL")]
        [Column("URL")]  
        public string? Url { get; set; }

        [JsonProperty("FECHA_CARGUE")]
        [Column("FECHA_CARGUE")] 
        public DateTime Fecha_cargue { get; set; }

        [JsonProperty("FECHA_ACTUALIZACION")]
        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; set; }

        [JsonProperty("ESTADO")]
        [Column("ESTADO")]  
        public string? Estado { get; set; }
    }
}
